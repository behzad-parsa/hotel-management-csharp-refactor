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
using Stimulsoft.Report;
using Stimulsoft.Base;
using Stimulsoft.Report.Components;

namespace HotelManagement
{
    public partial class OrderFood : UserControl
    {
        Dictionary<BunifuMetroTextbox, string> txtBoxList = new Dictionary<BunifuMetroTextbox, string>();
        public OrderFood()
        {
            InitializeComponent();
        }

        int ResID = -10;
        int FoodID = -10;
        DataTable foodData;
        private void LoadFoodData()
        {
            string query = "Select * From Food";
            var data = foodData = HotelDatabase.Database.Query(query);

            if (data != null)
            {
                lblEmptyFood.Visible = false;
                dgvFood.DataSource = data;
                dgvFood.Columns["ID"].Visible = false;
            }
            else
            {
                lblEmptyFood.Visible = true;
               dgvFood.DataSource = null;

            }
        }

        private void LoadBookingData()
        {
            string query = "Select  res.id As ResID,  rn.Title As RoomNo , Firstname + ' ' + Lastname As Name  ,StartDate as CheckIn , EndDate as CheckOut , res.DateModified as Date " +
              " From Reservation res , Room r , RoomNumber rn , Customer cus , Actor a  " +
              " Where res.RoomID = r.ID And r.RoomNumberID = rn.ID And res.CustomerID = cus.ID And cus.ActID = a.ID  And " +
              " res.startDate <= '" + DateTime.Now.Date + "' And res.EndDate >= '" + DateTime.Now.Date + "' And res.CancelDate IS Null And r.BranchID = " + Current.User.BranchID + " AND res.ID Not IN (Select b.ResID From Bill b)";

            var bookingData = _bookingData  = HotelDatabase.Database.Query(query);

            if (bookingData != null)
            {
                lblEmptyBooking.Visible = false;
                dgvBooking.DataSource = bookingData;
                dgvBooking.Columns["ResID"].Visible = false;
            }
            else
            {
                lblEmptyBooking.Visible = true;
                dgvBooking.DataSource = null;
            }    
        }


        private void LoadOrderData()
        { 
            string query = "Select Distinct orderf.ID as OrderID , Firstname + ' ' + Lastname +' - '+ rn.Title AS BookDetail  , f.Title  , Count As Qty  , f.Price , Total , orderf.DateModified As Date " +
                " From OrderFood orderf  , Food f   , Reservation res , Customer cus , Actor a , Room r , RoomNumber rn " +
                " Where orderf.FoodID = f.ID And res.CustomerID = cus.ID And cus.ActID = a.ID And res.RoomID = r.ID And r.RoomNumberID = rn.ID And orderf.ResID = res.ID  And r.BranchID = " +Current.User.BranchID;
            var data = _orderData = HotelDatabase.Database.Query(query);
            data.DefaultView.Sort = "Date DESC";

            if (data != null)
            {
                lblEmptyList.Visible = false;
                dgvOrder.DataSource = data;
                dgvOrder.Columns["OrderID"].Visible = false;
                dgvOrder.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvOrder.Columns["Qty"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvOrder.Columns["Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvOrder.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvOrder.Columns["BookDetail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvOrder.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvOrder.Columns["BookDetail"].HeaderText = "Book Detail";
            }
            else
            {
                lblEmptyList.Visible = true;
                dgvOrder.DataSource = null;
            }
        }


        DataTable _bookingData;
        DataTable _orderData;
        private void NewFood_Load(object sender, EventArgs e)
        {
            LoadFoodData();
            LoadBookingData();
            LoadOrderData();
        }

        private void txtEmpNationalCode_OnValueChanged(object sender, EventArgs e)
        {
            _bookingData.DefaultView.RowFilter = string.Format("RoomNo LIKE '{0}%'", txtEmpNationalCode.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var bmp = Theme.DarkBack(this.ParentForm);

            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ParentForm.ClientRectangle.Size;
                p.BackgroundImage = bmp;
                this.ParentForm.Controls.Add(p);
                p.BringToFront();

                using (ActionFood actionFood = new ActionFood(ActionFood.Action.Add))
                {
                    actionFood.ShowDialog();
                    if (actionFood.completeActionFlag)
                    {
                        LoadFoodData();
                        dgvFood.ClearSelection();
                        Current.User.Activities.Add(
                            new Activity("Submit New Food", 
                            "New Food has been submited to menu by " + Current.User.Firstname + " " + Current.User.Lastname)
                            );
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (FoodID<0)
            {
                MessageBox.Show("Please Select Row");
            }
            else
            {
                var bmp = Theme.DarkBack(this.ParentForm);

                using (Panel p = new Panel())
                {
                    p.Location = new Point(0, 0);
                    p.Size = this.ParentForm.ClientRectangle.Size;
                    p.BackgroundImage = bmp;
                    this.ParentForm.Controls.Add(p);
                    p.BringToFront();

                    using (ActionFood actionFood = new ActionFood(ActionFood.Action.Edit))
                    {
                        actionFood.FoodID = FoodID;
                        actionFood.ShowDialog();

                        if (actionFood.completeActionFlag)
                        {
                            Current.User.Activities.Add(new Activity("Edit a Food", "a Food has been edited by " + Current.User.Firstname + " " + Current.User.Lastname));

                            LoadFoodData();
                            int rowIndex = -1;

                            DataGridViewRow row = dgvFood.Rows
                                .Cast<DataGridViewRow>()
                                .Where(r => r.Cells["ID"].Value.ToString().Equals(FoodID.ToString()))
                                .First();

                            rowIndex = row.Index;

                            dgvFood.ClearSelection();
                            dgvFood.Rows[rowIndex].Selected = true;
                        }
                    }
                }
            }
            
        }

        private void dgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFood.CurrentRow != null)
            {
                FoodID = Convert.ToInt32(dgvFood["ID", dgvFood.CurrentRow.Index].Value);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (FoodID < 0)
            {
                MessageBox.Show("Please Select Row");
            }
            else
            {
                var res = MessageBox.Show("Are You Sure You Want To Delete This Record ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    if (HotelDatabase.Food.Delete(FoodID))
                    {                       
                        LoadFoodData();
                        dgvFood.ClearSelection();
                        Current.User.Activities.Add(
                            new Activity("Delete a Food", "a Food has been deleted by " + Current.User.Firstname + " " + Current.User.Lastname)
                            );
                    }
                    else
                    {
                        MessageBox.Show("Unable TO Compelete Action ", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }                 
            }
        }
        int price;
        private void dgvFood_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            panelStatusOrder.Visible = false;
            price = Convert.ToInt32(dgvFood["Price", dgvFood.CurrentRow.Index].Value);

            lblPrice.Text = price.ToString();
            lblTotal.Text = (price * numQuantity.Value).ToString();
            lblFood.Text = Convert.ToString(dgvFood["Title", dgvFood.CurrentRow.Index].Value); 

            doubleClickDGVFoodFlag = true;
        }
        private bool doubleClickDGVBookingFlag = false;
        private bool doubleClickDGVFoodFlag = false;
        private void dgvBooking_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            panelStatusOrder.Visible = false;
            lblFor.Text = dgvBooking["Name", dgvBooking.CurrentRow.Index].Value.ToString() + " - " + dgvBooking["RoomNo", dgvBooking.CurrentRow.Index].Value.ToString();
            doubleClickDGVBookingFlag = true;
        }

        private void customeNumeric1_ValueChange(object sender, EventArgs e)
        {
            lblTotal.Text = (price * numQuantity.Value).ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (doubleClickDGVBookingFlag && doubleClickDGVBookingFlag)
            {
                if (HotelDatabase.Food.InsertOrderFood(FoodID, ResID, numQuantity.Value, Convert.ToInt32(lblTotal.Text)) > 0)
                {
                    PanelStatus(panelStatusOrder, "Action Completed", Status.Green);
                    LoadOrderData();
                    dgvFood.ClearSelection();
                    dgvBooking.ClearSelection();
                    dgvOrder.ClearSelection();
                    Current.User.Activities.Add(
                        new Activity("Submit New Food Order", "New Food order has been submited by " + Current.User.Firstname + " " + Current.User.Lastname)
                        );
                }
                else
                {
                    PanelStatus(panelStatusOrder, "Unable To Complete Action", Status.Red);
                }
            }
            else if (!doubleClickDGVFoodFlag)
            {
                PanelStatus(panelStatusOrder, "Food Not Selected", Status.Red);
            }
            else if (!doubleClickDGVBookingFlag)
            {
                PanelStatus(panelStatusOrder, "Book Not Selected", Status.Red);
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
                LoadBookingData();
            }
        }


        private enum Status
        {
            Green,
            Red,
            blue
        };

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

        int OrderFoodID = -10;

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrder.CurrentRow != null)
            {
                OrderFoodID = Convert.ToInt32( dgvOrder["OrderID", dgvOrder.CurrentRow.Index].Value );
            }
        }

        private void dgvOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvBooking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBooking.CurrentRow != null)
            {
                ResID = Convert.ToInt32(dgvBooking["ResID" , dgvBooking.CurrentRow.Index].Value);
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (OrderFoodID < 0)
            {
                MessageBox.Show("Please Select Row");
            }
            else
            {
                var res = MessageBox.Show("Are You Sure You Want To Delete This Record ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    if (HotelDatabase.Food.DeleteOrderFood(OrderFoodID))
                    {
                        LoadOrderData();
                        dgvOrder.ClearSelection();
                        Current.User.Activities.Add(new Activity("Delete Food Order", "an Order from Food List has been deleted by " + Current.User.Firstname + " " + Current.User.Lastname));
                    }
                    else
                    {
                        MessageBox.Show("Unable TO Compelete Action ", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnReportFood_Click(object sender, EventArgs e)
        {
            if (foodData != null)
            {
                Current.User.Activities.Add(
                    new Activity("Creat New Report", 
                    "the report from the dood menu has been created by " + Current.User.Firstname + " " + Current.User.Lastname)
                    );

                StiReport report = new StiReport();
                report.Load("Report/FoodReport.mrt");
                StiText txtTitle = new StiText();
                txtTitle = report.GetComponentByName("txtTitle") as StiText;
                txtTitle.Text = "Food Menu";

                Report.SetHotelComponents(report, Current.User.Branch);
                report.RegBusinessObject("Food", foodData);
                report.Compile();
                report.Show();
            }
            else
            {
                MessageBox.Show("List Is Empty");
            } 
        }       
    }
}
