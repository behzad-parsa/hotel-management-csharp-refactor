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
using HotelManagement.Services;
using HotelManagement.Models;

namespace HotelManagement
{
    public partial class CardGuestDetail : UserControl
    {
        Dictionary<BunifuMetroTextbox, string> txtBoxList = new Dictionary<BunifuMetroTextbox, string>();
        BunifuImageButton btnBack;
        BunifuImageButton btnNext;
        private Panel panelContainerInside;

        private readonly GuestService _guestService;
        private readonly ActorService _actorService;

        private enum Status
        {
            Green,
            Red,
            blue
        };
        public CardGuestDetail()
        {
            InitializeComponent();

            _guestService = new GuestService();
            _actorService = new ActorService();
        }

        private void CardGuestDetail_Load(object sender, EventArgs e)
        {
            NewBook.statusFlag = 2;
            NewBook.backFalg = 1;
            btnBack = (this.Parent.Parent as NewBook).Controls["btnBack"] as BunifuImageButton;
            btnNext = (this.Parent.Parent as NewBook).Controls["btnNext"] as BunifuImageButton;

            btnBack.Visible = true;
            btnNext.Visible = true;
            panelContainerInside = (this.Parent.Parent as NewBook).Controls["panelContainerInside"] as Panel;


            lblBitrh.Text = NewBook.customerInfo.Birthday.Date.ToString("MM / dd / yyyy");
            lblGender.Text = NewBook.customerInfo.Gender;
            lblName.Text = NewBook.customerInfo.Firstname + " " + NewBook.customerInfo.Lastname;
            lblNC.Text = NewBook.customerInfo.NationalCode;
            lblStateCity.Text = NewBook.customerInfo.State + "," + NewBook.customerInfo.City;


            dataTable.Columns.Add("NC");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Date");

            LoadGuestData();

        }

        public static List<Guest> guestsAssignToCustomer; 

        private void LoadGuestData()
        {

            guestsAssignToCustomer = new List<Guest>();
            //var query = "Select ActID ,  NationalCode AS NC ,  Firstname +' '+Lastname As Name  , DateModified AS Date , Gender , Birthday , Mobile  " +
            //    "From Actor a , Guest g  " +
            //    "Where " +
            //    "a.id = g.ActID And g.CustomerID = " + NewBook.customerInfo.ID + " And g.DateModified = '" +DateTime.Now.Date + "'";

            //var data = HotelDatabase.Database.Query(query);

            var data = _guestService.GetAllGuestsAssignToSingleCustomer(NewBook.customerInfo.ID);

            if (data != null)
            {
                dataTable = data;
                dgvGuestList.DataSource = data;
                dgvGuestList.Columns["ActID"].Visible = false;
                dgvGuestList.Columns["Gender"].Visible = false;
                dgvGuestList.Columns["Birthday"].Visible = false;
                dgvGuestList.Columns["Mobile"].Visible = false;
                dgvGuestList.ClearSelection();
                guestsAssignToCustomer.Clear(); //*******************************
                foreach (DataRow item in data.Rows)
                {
                    string[] name = item["Name"].ToString().Split(' ');
                    Actor actor = new Actor()
                    {
                        ID = Convert.ToInt32(item["ActID"]),
                        Firstname = name[0],
                        Lastname = name[1],
                        NationalCode = item["NC"].ToString(),
                        Gender = item["Gender"].ToString() , 
                        Birthday = Convert.ToDateTime(item["Birthday"]) ,
                        Mobile = item["Mobile"].ToString()
                    };
                    
                    //Guest guest = new Guest(Convert.ToInt32(item["ActID"]), Convert.ToDateTime( item["Date"] ), name[0] , name[1] , item["NC"].ToString()  , item["Gender"].ToString(), Convert.ToDateTime( item["Birthday"] ), item["Mobile"].ToString());
                    Guest guest = new Guest(NewBook.customerInfo.ID , Convert.ToDateTime(item["Date"]), actor);
                    guestsAssignToCustomer.Add(guest);

                }
            }
            else
            {
                //Empty List
            }
 

        }
        private void AddGuestToDGV(Guest guest)
        {
            DataRow dr = dataTable.NewRow();
            dr["NC"] = guest.NationalCode;
            dr["Name"] = guest.Firstname + " " + guest.Lastname;
            dr["Date"] = DateTime.Now.Date.ToString("MM / dd / yyyy");

            dataTable.Rows.Add(dr);
            dgvGuestList.DataSource = dataTable;
            dgvGuestList.ClearSelection();
        }

        private void TextBoxEnter(object sender, EventArgs e)
        {
            var txtBox = sender as BunifuMetroTextbox;

            if (txtBox != txtNCSearch)
            {
                txtBox.BorderColorIdle = Color.FromArgb(231, 228, 228);

            }   
            txtBox.ForeColor = Color.Black;
            if (!txtBoxList.ContainsKey(txtBox))
            {
                txtBoxList.Add(txtBox, txtBox.Text);
            }
            txtBoxList.TryGetValue(txtBox, out string defualtText);
            if (txtBox.Text == defualtText)
            {
                txtBox.Text = null;
            }


        }
        private void TextBoxLeave(object sender, EventArgs e)
        {
            var txtBox = sender as BunifuMetroTextbox;

            if (txtBox.Text == null || txtBox.Text == "")
            {
                txtBoxList.TryGetValue(txtBox, out string defualtText);
                txtBox.Text = defualtText;
                txtBox.ForeColor = Color.Gray;
            }


        }
        private string RadioButtonResult(RadioButton rdb1, RadioButton rdb2) => (rdb1.Checked) ? rdb1.Text : rdb2.Text;


        private int txtCount = 0;
        private bool ValidationFlag = false;
        private void TextBoxColor(BunifuMetroTextbox txtBox, Status status)
        {
            if (status == Status.Red)
            {
                txtBox.BorderColorIdle = Color.Red;


            }
            else if (status == Status.Green)
            {

                txtBox.BorderColorIdle = Color.FromArgb(231, 228, 228);
            }
            else
            {
                txtBox.BorderColorIdle = Color.FromArgb(128, 128, 128);
            }

        }
        private bool TextBoxCheck(BunifuMetroTextbox txtBox, string txt)
        {
            if (txtBox.Text == txt || txtBox.Text == "")
            {
                TextBoxColor(txtBox, Status.Red);
                return false;
            }

            else
            {
                TextBoxColor(txtBox, Status.Green);
                txtCount++;
                return true;

            }
        }

        private void TextBoxClearBorderColor()
        {

            TextBoxColor(txtFname, Status.Green);
            TextBoxColor(txtLname, Status.Green);
            TextBoxColor(txtMobile, Status.Green);


        }



        private void btnGuestSearch_Click(object sender, EventArgs e)
        {
        }


        private void btnGuestSubmit_Click(object sender, EventArgs e)
        {
        }


        private bool searchFlag = false;
        private int  ActID = -10;
        private bool isFindGuest = false;
        //private bool isFindActor = false;
        private void btnNCSearch_Click(object sender, EventArgs e)
        {
            Reset();

            if (txtNCSearch.Text != "National Code" && txtNCSearch.Text != "")
            {
                searchFlag = true;
                var actor = _actorService.GetActor(txtNCSearch.Text);
                if (actor != null)//HotelDatabase.Actor.SearchActor(txtNCSearch.Text))
                {
                    if (txtNCSearch.Text != NewBook.customerInfo.NationalCode)
                    {   
                        
                        var search = guestsAssignToCustomer.Find(x => x.NationalCode == txtNCSearch.Text);

                        if (search == null)
                        {
                            isFindGuest = true;

                            ActID = actor.ID;
                            txtFname.Text = actor.Firstname;
                            txtLname.Text = actor.Lastname;
                            txtMobile.Text = actor.Mobile;
                            if (actor.Gender == "Male") rdbMale.Checked = true;
                            else rdbFemale.Checked = true;
                            dateBirth.Value = actor.Birthday;

                            PanelStatus(panelStatusGuest, "Guest Was successfully Found", Status.Green);                            
                        }
                        else
                        {
                            isFindGuest = false;
                            panelBasic.Enabled = false;
                            searchFlag = false;
                            PanelStatus(panelStatusGuest, "The Guest Has Already Been Added", Status.Red);
                        }
                    }
                    else
                    {
                        isFindGuest = false;
                        panelBasic.Enabled = false;
                        searchFlag = false;
                        PanelStatus(panelStatusGuest , "Customer And Guest Is Same", Status.Red);
                    }

                }
                else
                {

                    isFindGuest = false;
                    Reset();
                    panelBasic.Enabled = true;
                    PanelStatus(panelStatusGuest, "No Person Found", Status.Red);
                }
            }

        }

        private void Reset()
        {

            txtFname.Text = "Firstname";
            txtFname.ForeColor = Color.Gray;

            txtLname.Text = "Lastname";
            txtLname.ForeColor = Color.Gray;

            txtMobile.Text = "Mobile Phone";
            txtMobile.ForeColor = Color.Gray;

            dateBirth.Value = DateTime.Now.Date;
            TextBoxClearBorderColor();

            panelBasic.Enabled = false;

            panelStatusGuest.Visible = false;

            isFindGuest = false;

            ActID = -1;

            updateFlag = false;

            btnAdd.Text = "Add";
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

        DataTable dataTable = new DataTable();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Actor actor = new Actor()
            {
                ID = ActID,
                Firstname = txtFname.Text,
                Lastname = txtLname.Text,
                NationalCode = txtNCSearch.Text,
                Gender = RadioButtonResult(rdbMale, rdbFemale),
                Birthday = dateBirth.Value.Date,
                Mobile = txtMobile.Text,
                
                
            };
            if (isFindGuest)
            {
                //GuestSecond guest = new GuestSecond(ActID, DateTime.Now.Date, txtFname.Text, txtLname.Text, txtNCSearch.Text, RadioButtonResult(rdbMale, rdbFemale), dateBirth.Value.Date, txtMobile.Text);
               
        
                Guest guest = new Guest(NewBook.customerInfo.ID, DateTime.Now.Date, actor);

                if (!updateFlag)
                {
                    //var res = HotelDatabase.Guest.Insert(ActID, NewBook.customerInfo.ID);
                    var res = _guestService.InsertGuest(guest);
                    if (res)
                    {
                        guestsAssignToCustomer.Add(guest);
                        AddGuestToDGV(guest);
                        panelBasic.Enabled = false;
                        isFindGuest = false;
                        PanelStatus(panelStatusGuest, "Action Completed Successfuly", Status.Green);
                        searchFlag = false;

                    }
                    else
                    {
                        PanelStatus(panelStatusGuest, "Unable to Complete Action ", Status.Red);

                    }


                }
                //On UpdateMode
                else
                {


                    //var res = HotelDatabase.Actor.UpdateGuest(ActID , txtFname.Text , txtLname.Text , dateBirth.Value.Date , txtNCSearch.Text , txtMobile.Text , RadioButtonResult(rdbMale , rdbFemale) );
                    var res = _guestService.UpdateGuest(actor);

                    //Guest guest = new Guest(ActID, DateTime.Now.Date, txtFname.Text, txtLname.Text, txtNCSearch.Text, RadioButtonResult(rdbMale, rdbFemale), dateBirth.Value.Date, txtMobile.Text);

                    if (res)
                    {
                        updateFlag = false;
                        panelUpdate.Visible = false;
                        panelBasic.Enabled = false;
                        btnAdd.Text = "Add";

                        PanelStatus(panelStatusGuest, "Information Changed Successfully", Status.Green);

                        var search = guestsAssignToCustomer.Find(x => x.ID == ActID);
                        if (search != null)
                        {
                            guestsAssignToCustomer.Remove(search);
                            guestsAssignToCustomer.Add(guest);
                            isFindGuest = false;
                            selectedGuest = null;
                            LoadGuestData();

                        }
                    }
                    else
                    {
                        PanelStatus(panelStatusGuest, "Unable to Complete Action ", Status.Red);
                    }
                }
            }
            else if (searchFlag) 
            {
                TextBoxCheck(txtFname, "Firstname");
                TextBoxCheck(txtLname, "Lastname");
                TextBoxCheck(txtMobile, "Mobile Phone");


                if (txtCount == 3 & txtNCSearch.Text != "" && txtNCSearch.Text != "National Code")
                {
                    if (dateBirth.Value.Date != DateTime.Now.Date)
                    {

                        ValidationFlag = true;
                    }
                    else
                    {
                        PanelStatus(panelStatusGuest, "Choose Birthday", Status.Red);
                    }
                }
                else
                {

                    PanelStatus(panelStatusGuest, "Please Fill The Blank", Status.Red);
                }
                txtCount = 0;


                if (ValidationFlag)
                {
                    ValidationFlag = false;

                    //var result = HotelDatabase.Actor.InsertAll(txtFname.Text, txtLname.Text, dateBirth.Value.Date, txtNCSearch.Text, "Not Available", "Not Available", "Not Available", txtMobile.Text, RadioButtonResult(rdbMale, rdbFemale), "Not Available", "Not Available", "Not Available");
                    actor = new Actor()
                    {
                        Firstname = txtFname.Text,
                        Lastname = txtLname.Text,
                        NationalCode = txtNCSearch.Text,
                        Gender = RadioButtonResult(rdbMale, rdbFemale),
                        Birthday = dateBirth.Value.Date,
                        Mobile = txtMobile.Text,
                        Address = "Not Available",
                        City = "Not Available",
                        Email = "Not Available",
                        Nationality = "Not Available",
                        State = "Not Available",
                        Tel = "Not Available"
                    };
                    var resultInsertActor = _actorService.InsertActor(actor);
                    actor.ID = _actorService.LastInsertedId;
                    if (resultInsertActor)
                    {
                        Guest guest = new Guest(NewBook.customerInfo.ID, DateTime.Now.Date, actor);
                        var resultInsertGuest = _guestService.InsertGuest(guest);
                        if (resultInsertGuest)//HotelDatabase.Guest.Insert(result, NewBook.customerInfo.ID) > 0)
                        {

                            PanelStatus(panelStatusGuest, "Action Completed Successfuly", Status.Green);
                            //GuestSecond guest = new GuestSecond(ActID , DateTime.Now.Date, txtFname.Text, txtLname.Text, txtNCSearch.Text, RadioButtonResult(rdbMale, rdbFemale), dateBirth.Value.Date, txtMobile.Text);
                            guestsAssignToCustomer.Add(guest);
                            AddGuestToDGV(guest);

                            panelBasic.Enabled = false;
                            searchFlag = false;
                        }
                        else
                        {
                            PanelStatus(panelStatusGuest, "Unable to Complete Action (Maybe National Code Exist Already)", Status.Red);
                        }
                    }
                }
            }
            else
            {
                PanelStatus(panelStatusGuest, "Use Search Bar To Find Person", Status.blue);
            }
        }


        private Guest selectedGuest;
        private void dgvGuestList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGuestList.CurrentRow != null)
            {
                string nc = dgvGuestList["NC", dgvGuestList.CurrentRow.Index].Value.ToString();
                selectedGuest = guestsAssignToCustomer.Find(x => x.NationalCode == nc);
                ActID = selectedGuest.ID;
            }
        }
        private void btnDeleteGuest_Click(object sender, EventArgs e)
        {
            if (selectedGuest == null)
            {
                MessageBox.Show("Please Select Row");
            }
            else
            {

                var res = MessageBox.Show("Are You Sure You Want To Delete '" + selectedGuest.Firstname + ' ' + selectedGuest.Lastname + "' ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    var guest = new Guest()
                    {
                        ActID = selectedGuest.ActID,
                        DateModified = selectedGuest.DateModified,
                        CustomerID = NewBook.customerInfo.ID
                    };
                    var resultDeleteGuest = _guestService.DeleteGuest(guest);
                    if (resultDeleteGuest)//HotelDatabase.Guest.Delete(selectedGuest.ID, NewBook.customerInfo.ID, selectedGuest.DateModified))
                    {
                        guestsAssignToCustomer.Remove(selectedGuest);
                        LoadGuestData();
                        dgvGuestList.ClearSelection();
                    }
                    else
                    {
                        MessageBox.Show("Unable To Compelete Action ", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                selectedGuest = null;

            }
        }
        private bool updateFlag = false;
        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (isFindGuest)
            {
                panelUpdate.Visible = true;
                btnAdd.Text = "Save";
                updateFlag = true;
                panelBasic.Enabled = true;
            }
        }

        private void dgvGuestList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEditList_Click(object sender, EventArgs e)
        {
            if (selectedGuest == null)
            {
                MessageBox.Show("Please Select Row");
            }
            else
            {

                isFindGuest = true;
                panelUpdate.Visible = true;
                btnAdd.Text = "Save";
                updateFlag = true;
                panelBasic.Enabled = true;

                txtNCSearch.Text = selectedGuest.NationalCode;
                txtFname.Text = selectedGuest.Firstname;
                txtLname.Text = selectedGuest.Lastname;
                dateBirth.Value = selectedGuest.Birthday;
                if (selectedGuest.Gender == "Male") rdbMale.Checked = true;
                else rdbFemale.Checked = true;
                txtMobile.Text = selectedGuest.Mobile;

                txtBoxList.Clear();

            }
        }
    }
}
