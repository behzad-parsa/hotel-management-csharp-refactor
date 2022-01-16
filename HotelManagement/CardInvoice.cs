using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagement.Services;
using HotelManagement.Models;

namespace HotelManagement
{
    public partial class CardInvoice : UserControl
    {
        private readonly ReservationService _reservationService;
        private readonly BillService _billService;

        Panel panelContainer;
        public CardInvoice()
        {
            InitializeComponent();

            _reservationService = new ReservationService();
            _billService = new BillService();
        }

        private void CardInvoice_Load(object sender, EventArgs e)
        {
            panelContainer = this.Parent.Parent.Controls["panelContainer"] as Panel;

            InvoiceDetail.payFlag = false;

            DataTable data = new DataTable();

            string Query = "Select  res.id AS ResID   , NationalCode  ,  Firstname , Lastname , rn.Title AS Room , StartDate AS CheckIn , EndDate AS CheckOut , CancelDate From Reservation res , Customer c , Room r  , Actor a  , RoomNumber rn Where c.id = res.CustomerID  And c.actID = a.id And res.RoomID = r.id ANd r.RoomNumberID =rn.ID   ";

            data = HotelDatabase.Database.Query(Query);
            data.Columns.Add("InvoiceID", typeof(string)).SetOrdinal(0);
            data.Columns.Add("Status");
            data.Columns.Add("Bill");
            data.Columns.Add("Pay");
            foreach (DataRow item in data.Rows)
            {
                var itemStartDate = Convert.ToDateTime(item["CheckIn"]);
                var itemEndDate = Convert.ToDateTime(item["CheckOut"]);
               if (itemEndDate < DateTime.Now || item["CancelDate"] != DBNull.Value)
                {
                    if (item["CancelDate"] != DBNull.Value)
                    {
                        item["Status"] = "Canceled";
                    }
                    else
                    {
                        item["Status"] = "Finish";
                    }
                    
                    int ResID = Convert.ToInt32(item["ResID"]);
                    string queryBill = "Select * From Reservation res , Bill b Where b.resID = " + ResID;

                    var dataBill = HotelDatabase.Database.Query(queryBill);
                    if (dataBill == null)
                    {
                        item["Bill"] = "No";
                        item["Pay"] = "No";
                    }
                    else
                    {
                        item["Bill"] = "Yes";
                        item["InvoiceID"] = dataBill.Rows[0]["BillNo"].ToString();

                        if (dataBill.Rows[0]["TransactionID"] != DBNull.Value)
                        {
                            item["Pay"] = "Yes";

                        }
                        else
                        {
                            item["Pay"] = "No";

                        }                      
                    }
                }
                else if(itemStartDate > DateTime.Now)
                {
                    item["Status"] = "Booking";
                }
                else
                {
                    item["Status"] = "Check-in";
                }
            }
            dgvInvoice.DataSource = data;
            _data = data;
            dgvInvoice.Columns["ResID"].Visible = false;
        }
        
        int ResID;
        DataTable _data;
        private void dgvInvoice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            ResID = Convert.ToInt32(_data.Rows[e.RowIndex]["ResID"]);
            string name = _data.Rows[e.RowIndex]["Firstname"].ToString() + " " + _data.Rows[e.RowIndex]["Lastname"];
            DataRow dataRow = _data.AsEnumerable()
               .SingleOrDefault(r => r.Field<int>("ResID") == ResID);

            var reservation = _reservationService.GetReservation(ResID);
            if (reservation == null)
            {
                MessageBox.Show("Problem - reservation Not Found");
                return;
            }
            if (dataRow["Status"].ToString() == "Check-in")
            {

                var dialogResult = MessageBox.Show("Are Sure?\n It will bw Canceld And Bill Created","Warning",
                    MessageBoxButtons.YesNo , MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    reservation.CancelDate = DateTime.Now.Date;
                    reservation.TotalPayDueDate = Convert.ToInt32(reservation.TotalPayDueDate * 0.5 ); 
                    //if (HotelDatabase.Reservation.Update(ResID, DateTime.Now.Date, false ))
                    if (_reservationService.UpdateReservation(reservation))
                    {
                        //var res = HotelDatabase.Bill.Insert(ResID);
                        var bill = new Bill()
                        {
                            ResID = ResID,
                            DateModified = DateTime.Now.Date
                        };
                        var billInsertResult = _billService.InsertBill(bill);
                        if (billInsertResult)
                        {
                            InvoiceDetail.ResID = ResID;
                            panelContainer.Controls.Clear();
                            panelContainer.Controls.Add(new InvoiceDetail());
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
            }
            else if(dataRow["Status"].ToString() == "Finish" || dataRow["Status"].ToString() == "Canceled")
            {
                if (dataRow["Bill"].ToString() =="No")
                {
                    var dialogResult = MessageBox.Show("Create Invoice?", "Noticed", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        // var res = HotelDatabase.Bill.Insert(ResID);
                        var bill = new Bill()
                        {
                            ResID = ResID,
                            DateModified = DateTime.Now.Date
                        };
                        var billInsertResult = _billService.InsertBill(bill);
                        if (billInsertResult)
                        {
                            InvoiceDetail.ResID = ResID;
                            panelContainer.Controls.Clear();

                            panelContainer.Controls.Add(new InvoiceDetail());
                            Current.CurrentUser.Activities.Add(
                                new Activity("Create New Invoice", name+"'s Invoice has been created by " + 
                                Current.CurrentUser.Firstname +" "+ Current.CurrentUser.Lastname));
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }    
                    }
                }
                else
                {
                    if (dataRow["Pay"].ToString()=="Yes")
                    {
                        InvoiceDetail.payFlag = true;

                    }
                    InvoiceDetail.ResID = ResID;
                    panelContainer.Controls.Clear();

                    panelContainer.Controls.Add(new InvoiceDetail());
                }   
            }
            else if (dataRow["Status"].ToString() == "Booking")
            {
                var dialogResult = MessageBox.Show("Are Sure?\n It Will BE Canceld And Bill Created", "Warning", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    //var rs =  HotelDatabase.Reservation.SearchReserveWithID(ResID);
                    //var reservation = _reservationService.GetReservation(ResID);
                    reservation.TotalPayDueDate = Convert.ToInt32(reservation.TotalPayDueDate * 0.5);
                    reservation.CancelDate = DateTime.Now.Date;
                    var reservationUpdateResult = _reservationService.UpdateReservation(reservation);
                    //if (reservation != null && HotelDatabase.Reservation.Update(ResID,HotelDatabase.Reservation.TotalPayDueDate , DateTime.Now.Date))
                    //if (reservation != null && reservationUpdateResult)
                    if (reservationUpdateResult)
                    {
                        var bill = new Bill()
                        {
                            ResID = ResID,
                            DateModified = DateTime.Now.Date
                        };
                        var billInsertResult = _billService.InsertBill(bill);
                        //var res = HotelDatabase.Bill.Insert(ResID);
                        if (billInsertResult)
                        {
                            InvoiceDetail.ResID = ResID;
                            panelContainer.Controls.Clear();

                            panelContainer.Controls.Add(new InvoiceDetail());
                            Current.CurrentUser.Activities.Add(
                                new Activity("Create New Invoice", 
                                name + "'s Invoice has been created by " + 
                                Current.CurrentUser.Firstname + " " + Current.CurrentUser.Lastname));
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
            }
        }

        private void txtEmpNationalCode_OnValueChanged(object sender, EventArgs e)
        {
            if (txtEmpNationalCode.Text != null)
            {
                _data.DefaultView.RowFilter = string.Format("NationalCode LIKE '{0}%'", txtEmpNationalCode.Text);
            }
        }

        private void txtEmpNationalCode_Enter(object sender, EventArgs e)
        {
            txtEmpNationalCode.ForeColor = Color.Black;
            txtEmpNationalCode.Text = "";
        }
    }
}
