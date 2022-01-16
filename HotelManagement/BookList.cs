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
    public partial class BookList : UserControl
    {
        Dictionary<BunifuMetroTextbox, string> txtBoxList = new Dictionary<BunifuMetroTextbox, string>();
        private readonly ReservationService _reservationService;

        public BookList()
        {
            InitializeComponent();

            _reservationService = new ReservationService();
        }

        private void LoadData()
        {
            string query = "Select Distinct  res.id As ResID , u.Username as Employee , NationalCode , Firstname +' '+ Lastname  AS Name   , rn.Title As Room  , StartDate as CheckIn  , EndDate AS CheckOut , CancelDate , res.TotalPayDueDate as Pay ,res.DateModified  " +
                "FRom Reservation res , [User] u , BranchInfo b , Employee e , Actor a , Room r , RoomNumber rn , Customer cus   " +
                "Where res.UserID = u.ID ANd u.EmployeeID = e.ID AND e.BranchID = " + Current.CurrentUser.BranchID +
                " And res.RoomID = r.ID  And r.RoomNumberID = rn.ID ANd res.CustomerID = cus.ID And cus.ActID = a.ID";

            var data = HotelDatabase.Database.Query(query);
           
            dgvBookList.DataSource = data;
            _data = data;
            dgvBookList.Columns["ResID"].Visible = false;
        }
        DataTable _data;
        private void BookList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        int ResID = -10;
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ResID < 0)
            {
                MessageBox.Show("Select Row");
            }
            else
            {
                var dialogResult = MessageBox.Show("Are You Sure You Want To Delete This Record ?", "Delete", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (_reservationService.DeleteReservation(ResID))
                    {
                        PanelStatus("Action Completed Successfuly", Status.Green);

                        LoadData();
                        Current.CurrentUser.Activities.Add(
                            new Activity("Delete a Book", 
                            /*NewBook.customerInfo.Firstname + " " + NewBook.customerInfo.Lastname + "'s*/ "Booking record has been deleted by " + 
                            Current.CurrentUser.Firstname + " " + Current.CurrentUser.Lastname));

                        //int rowIndex = -1;

                        //DataGridViewRow row = dgvBookList.Rows
                        //    .Cast<DataGridViewRow>()
                        //    .Where(r => r.Cells["ResID"].Value.ToString().Equals(ResID.ToString()))
                        //    .First();

                        //rowIndex = row.Index;
                        dgvBookList.ClearSelection();
                        //dgvBookList.Rows[rowIndex].Selected = true;
                        ////transID = -1;
                    }
                    else
                    {
                        PanelStatus("Unable to Complete Action", Status.Red);
                    }
                }
            }
        }

        private enum Status
        {
            Green,
            Red,
            blue
        };
        private void PanelStatus(string text, Status status)
        {
            panelCustStatus.Visible = true;
            lblCustError.Text = text;
            if (status == Status.Red)
            {
                prgbCustError.ProgressColor = Color.Red;
                lblCustError.ForeColor = Color.Red;
            }
            else if (status == Status.Green)
            {
                prgbCustError.ProgressColor = Color.Green;
                lblCustError.ForeColor = Color.Green;
            }
            else
            {
                prgbCustError.ProgressColor = Color.Blue;
                lblCustError.ForeColor = Color.Blue;
            }
        }

        private void dgvBookList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBookList.CurrentRow != null)
            {
                ResID = Convert.ToInt32(dgvBookList["ResID", dgvBookList.CurrentRow.Index].Value);
            }
        }


        private void TextBoxEnter(object sender, EventArgs e)
        {
            var txtBox = sender as BunifuMetroTextbox;
   
            txtBox.BorderColorIdle = Color.FromArgb(231, 228, 228);
            
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
                txtBox.ForeColor = Color.DarkGray;
            }
        }

        private void txtEmpNationalCode_OnValueChanged(object sender, EventArgs e)
        {
            _data.DefaultView.RowFilter = string.Format("NationalCode LIKE '{0}%'", txtEmpNationalCode.Text);
        }
    }
}
