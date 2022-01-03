using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Bunifu.Framework.UI;
using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement
{
    public partial class CardBookDetail : UserControl
    {
        private readonly BranchService _branchService;

        BunifuImageButton btnDone;
        BunifuImageButton btnNext;
        private static Communication communication;
        private Panel panelContainerInside;

        private enum Status
        {
            Green,
            Red,
            blue
        };

        public CardBookDetail()
        {
            InitializeComponent();

            _branchService = new BranchService();

        }

     
        private void PanelStatus(Control Panel, string text, Status status)
        {
            BunifuCircleProgressbar prgb = null;
            BunifuCustomLabel lbl = null;
            Panel.Visible = true;
            foreach (Control item in Panel.Controls)
            {
                if (item is BunifuCustomLabel)
                {
                    lbl = item as BunifuCustomLabel;

                }
                else
                {
                    prgb = item as BunifuCircleProgressbar;

                }
            }

            lbl.Text = text;
            if (status == Status.Red)
            {
                prgb.ProgressColor = Color.Red;
                lbl.ForeColor = Color.Red;
            }
            else if (status == Status.Green)
            {
                prgb.ProgressColor = Color.Green;
                lbl.ForeColor = Color.Green;
            }
            else
            {
                prgb.ProgressColor = Color.Blue;
                lbl.ForeColor = Color.Blue;
            }
        }

        private readonly object _lock = new object();
        private readonly object _lockSms = new object();
        private static bool isStartThread = false;
        private void LoadFreeRoom(DateTime checkin , DateTime checkout)
        {
            lblNothing.Visible = false;
          
            string query = "Declare @checkin datetime = '" + checkin  +"' " +
                "Declare @checkout datetime = '"+  checkout    +"' " +
                "SELECT r.ID , rn.Title as No , Capacity As CPY , Floor , Price  , rt.Title as Type From Room as r , RoomNumber as rn , RoomTypeRel rtl, RoomType rt  " +
                "Where  r.BranchID = "+Current.User.BranchID +" And  rn.id = r.RoomNumberID And r.Id = rtl.RoomID And rtl.RoomTypeID = rt.id " +
            "AND r.ID NOT IN(  " +

            "Select Distinct res1.RoomID  From Room r, Reservation res1 Where  res1.CancelDate IS null ANd  r.id = res1.RoomID  " +
            "AND(   " +
            "(@checkout <= res1.EndDate And  @checkout >= res1.StartDate)  " +

            "OR(@checkin <= res1.EndDate And  @checkin >= res1.StartDate)  " +

            "OR(@checkout >= res1.EndDate And  @checkin <= res1.StartDate)  " +

           " OR(@checkout <= res1.EndDate And  @checkin >= res1.StartDate)  " +
            " )  " +
           " ) ";

            var data = HotelDatabase.Database.Query(query);

            if (data != null)
            {
                lblNothing.Visible = false;

                data.Columns.Add("Facilities");

                var facilityData = HotelDatabase.Database.Query("Select DISTINCT r.id , f.Title From Room as r , facilities f , RoomFacilities rf Where r.BranchID = " + Current.User.BranchID + " And r.id = rf.RoomID ANd  f.id = rf.FacilitiesID ORder BY r.id ASC");

                string d = null;
                int i_val;
                int j_val;
                for (int i = 0, j = i + 1; i < facilityData.Rows.Count; i++, j++)
                {
                    i_val = Convert.ToInt32(facilityData.Rows[i]["id"]);
                    if (j < facilityData.Rows.Count)
                    {
                        j_val = Convert.ToInt32(facilityData.Rows[j]["id"]);
                    }
                    else
                    {
                        j_val = -1;
                    }

                    d += "- " + facilityData.Rows[i]["Title"].ToString() + "\n";

                    if (i_val != j_val)
                    {
                        foreach (DataRow dr in data.Rows) // search whole table
                        {
                            if (Convert.ToInt32(dr["ID"]) == i_val) // if id==2
                            {
                                dr["Facilities"] = d; //change the name
                                break;
                                //break; break or not depending on you
                            }
                        }
                        d = null;
                    }

                }

                dgvRoom.DataSource = data;
                dgvRoom.Columns["id"].Visible = false;
                dgvRoom.Columns["No"].HeaderText = "No.";
                dgvRoom.Columns["Facilities"].HeaderText = "Facil";
            }
            else
            {
                dgvRoom.DataSource = null;
                lblNothing.Visible = true;

            }        
        }
        private void CardBookDetail_Load(object sender, EventArgs e)
        {
            dateStart.Value = DateTime.Now;
            dateEnd.Value = DateTime.Now.AddDays(1);

            if (!isStartThread)
            {
                isStartThread = true;
                communication = new Communication();
                communication.StartThread();
            }


            panelContainerInside = (this.Parent.Parent as NewBook).Controls["panelContainerInside"] as Panel;


            btnNext = (this.Parent.Parent as NewBook).Controls["btnNext"] as BunifuImageButton;
            btnNext.Visible = false;

            btnDone = (this.Parent.Parent as NewBook).Controls["btnDone"] as BunifuImageButton;
            //btnDone.Click += BtnDone_Click;
            NewBook.backFalg = 2;
            


        }

        private int ID = -1;

        private int totalPrice;
       

        private void dateStart_onValueChanged(object sender, EventArgs e)
        {
            if (dateStart.Value <DateTime.Now)
            {
                dateStart.Value = DateTime.Now;

            }
            if (dateStart.Value >= dateEnd.Value)
            {
                dateEnd.Value = dateStart.Value.AddDays(1);

            }


            LoadFreeRoom(dateStart.Value, dateEnd.Value);

            CalculateRoomCharge(dateStart.Value, dateEnd.Value);
        }

        private void dateEnd_onValueChanged(object sender, EventArgs e)
        {
            if (dateEnd.Value <= dateStart.Value)
            {
                dateEnd.Value = dateStart.Value.AddDays(1); 

            }
            LoadFreeRoom(dateStart.Value, dateEnd.Value);
            CalculateRoomCharge(dateStart.Value, dateEnd.Value);
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            
        }

        private void CalculateRoomCharge(DateTime sDate , DateTime eDate)
        {

            TimeSpan day = dateEnd.Value.Date - dateStart.Value.Date;
            int days = day.Days;

           

            totalPrice = price * days;
            lblPay.Text = totalPrice.ToString();


        }
        int price;
        
        private void dgvRoom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(dgvRoom["ID", e.RowIndex].Value);
            lblRoom.Text = dgvRoom["No", e.RowIndex].Value.ToString() + " - " + dgvRoom["Type", e.RowIndex].Value.ToString();
            TimeSpan day = dateEnd.Value.Date - dateStart.Value.Date;
            int days = day.Days;


            price = Convert.ToInt32(dgvRoom["Price", e.RowIndex].Value);

            totalPrice = price * days;

            lblPay.Text = totalPrice.ToString();

        }

        private void btnBook_Click_1(object sender, EventArgs e)
        {
            if (ID > 0)
            {
                int result = HotelDatabase.Reservation.Insert(Current.User.ID, NewBook.customerInfo.ID, ID, dateStart.Value, dateEnd.Value, totalPrice);
                if (result > 0)
                {
                    LoadFreeRoom(dateStart.Value, dateEnd.Value);
                    dgvRoom.ClearSelection();
                    ID = -1;
                    PanelStatus(panelStatusBook , "Action Completed Successfuly", Status.Green);
                    Current.User.Activities.Add(
                        new Activity(
                            "Submit New Book", NewBook.customerInfo.Firstname+ " " + 
                            NewBook.customerInfo.Lastname + "'s booking has been submited by " + 
                            Current.User.Firstname + " " + Current.User.Lastname)
                        );



                    //Sending Mail

                    string emailMsg = "Dear ,  " + NewBook.customerInfo.Firstname + " " + NewBook.customerInfo.Lastname + " \n\n " +
                        "Thank you for booking Room in our hotel \n\n" +
                        "Your Bookin Detail : \n\n" +
                        "Room : " + lblRoom.Text + "\n" +
                        "Guest : ";
                    for (int i = 0; i < CardGuestDetail.guestsAssignToCustomer.Count ; i++)
                    {
                        var guest = CardGuestDetail.guestsAssignToCustomer[i];
                        emailMsg += guest.Firstname + " " + guest.Lastname + " | ";
                    }
                    emailMsg += "\n Check-in/Out : " + dateStart.Value.ToString() + " - " + dateEnd.Value.ToString();
                    emailMsg += "\n Booking Date : " + DateTime.Now.ToString() +"\n\n";

                    var branch = _branchService.GetBranch(Current.User.BranchID);
                    if (branch != null)//HotelDatabase.Branch.SearchBranchWithID(Current.User.BranchID))
                    {
                        emailMsg += branch.BranchName + " - " + branch.Tel + " - " + 
                            branch.State + " , " + branch.City + " , " + branch.Address;

                    }
                    //emailMsg += HotelDatabase.Branch.BranchName + " - " + HotelDatabase.Branch.Tel + " - " + HotelDatabase.Branch.State + " , " + HotelDatabase.Branch.City + " , " + HotelDatabase.Branch.Address;


                    Email email = new Email(NewBook.customerInfo.Email, NewBook.customerInfo.Firstname + " " + NewBook.customerInfo.Lastname, "Booking Detail", emailMsg);
                    lock (_lock)
                    {
                        communication.queueEmail.Enqueue(email);

                    }
                    //Communication.SendMail(NewBook.customerInfo.Email , NewBook.customerInfo.Firstname+" " +NewBook.customerInfo.Lastname  , "Booking Detail" , emailMsg);

                    //Sending SMS
                    string smsMsg = "Dear Customer \n" +
                        "The Room : '" + lblRoom.Text + "' Was Booked For You On " + DateTime.Now.ToString() + "\n" +
                    "Check-in/Out : " + dateStart.Value.ToString() + " - " + dateEnd.Value.ToString();

                    Sms sms = new Sms(NewBook.customerInfo.Mobile, smsMsg);
                    lock (_lockSms) communication.queueSms.Enqueue(sms);

                    //Communication.SendSMS(NewBook.customerInfo.Mobile, smsMsg);

                    btnDone.Visible = true;

                }
                else
                {

                    PanelStatus(panelStatusBook , "Unable To Complete Action", Status.Red);

                }
            }
            else
            {
                PanelStatus( panelStatusBook ,"Please Choose Room", Status.Red);
            }

    
        }
    }
}
