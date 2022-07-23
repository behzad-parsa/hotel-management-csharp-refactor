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
using Stimulsoft.Report.Components;
using Stimulsoft.Report;
using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement
{
    public partial class OrderServiceControl : UserControl
    {
        private readonly ServiceService _serviceService;
        private readonly OrderServiceService _orderServiceService;
        Dictionary<BunifuMetroTextbox, string> txtBoxList = new Dictionary<BunifuMetroTextbox, string>();
        int ResID = -10;
        int ServiceID = -10;
        int OrderID = -10;

        public OrderServiceControl()
        {
            InitializeComponent();

            _serviceService = new ServiceService();
            _orderServiceService = new OrderServiceService();
        }

        //------ Queries And Fill DGV ------------------------
        DataTable serviceData;
        private void LoadServiceData()
        {
            string query = "Select * From Service";
            var data = serviceData = HotelDatabase.Database.Query(query);

            if (data != null)
            {
                lblEmptyService.Visible = false;
                dgvService.DataSource = data;
                dgvService.Columns["ID"].Visible = false;
            }
            else
            {
                lblEmptyService.Visible = true;
                dgvService.DataSource = null;
            }
        }


        private void LoadBookingData()
        {
            string query = "Select  res.id As ResID,  rn.Title As RoomNo , Firstname + ' ' + Lastname As Name  ,StartDate as CheckIn , EndDate as CheckOut , res.DateModified as Date " +
                " From Reservation res , Room r , RoomNumber rn , Customer cus , Actor a  " +
                " Where res.RoomID = r.ID And r.RoomNumberID = rn.ID And res.CustomerID = cus.ID And cus.ActID = a.ID  And " +
                " res.startDate <= '" + DateTime.Now.Date + "' And res.EndDate >= '" + DateTime.Now.Date + "' And res.CancelDate IS Null And r.BranchID = " + Current.CurrentUser.BranchID + "  AND res.ID Not IN(Select b.ResID From Bill b) ";

            var bookingData = _bookingData = HotelDatabase.Database.Query(query);

            if (bookingData != null)
            {
                lblbookingEmpty.Visible = false;
                dgvBooking.DataSource = bookingData;

                dgvBooking.Columns["ResID"].Visible = false;
            }
            else
            {
                lblbookingEmpty.Visible = true;
                dgvBooking.DataSource = null;
            }
        }

        private void LoadOrderData()
        {
            string query = "Select Distinct os.ID as OrderID , Firstname + ' ' + Lastname +' - '+ rn.Title AS BookDetail  , s.Title  , Count As Qty  , s.Price , Total , os.DateModified As Date " +
                " From OrderService os , Service s   , Reservation res , Customer cus , Actor a , Room r , RoomNumber rn " +
                " Where os.ServiceID = s.ID And res.CustomerID = cus.ID And cus.ActID = a.ID And res.RoomID = r.ID And r.RoomNumberID = rn.ID And os.ResID = res.ID  And r.BranchID = " + Current.CurrentUser.BranchID;
            var data = _orderData = HotelDatabase.Database.Query(query);

            if (data != null)
            {
                lblOrderListEmpty.Visible = false;

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
                lblOrderListEmpty.Visible = true;
                dgvOrder.DataSource = null;
            }
        }

        DataTable _bookingData;
        DataTable _orderData;

        private void OrderService_Load(object sender, EventArgs e)
        {

            LoadBookingData();
            LoadServiceData();
            LoadOrderData();

        }



        //------- Click Events ---------------------------------------------------
        bool doubleClickServiceFlag = false;
        bool doubleClickBookFlag = false;


        private void dgvService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvService.CurrentRow != null)
            {
                ServiceID = Convert.ToInt32(dgvService["ID", dgvService.CurrentRow.Index].Value);
            }
        }

        int price;
        private void dgvService_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            doubleClickServiceFlag = true;

            lblService.Text = dgvService["Title", dgvService.CurrentRow.Index].Value.ToString();
            price = Convert.ToInt32(dgvService["Price", dgvService.CurrentRow.Index].Value);
            lblPrice.Text = price.ToString();
            lblTotal.Text = (price * numQuantity.Value).ToString();

            panelStatusOrder.Visible = false;
        }

        private void dgvBooking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBooking.CurrentRow != null)
            {
                ResID = Convert.ToInt32(dgvBooking["ResID", dgvBooking.CurrentRow.Index].Value);
            }
        }

        private void dgvBooking_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            doubleClickBookFlag = true;

            lblFor.Text = dgvBooking["Name", dgvBooking.CurrentRow.Index].Value.ToString() + " - " + dgvBooking["RoomNo", dgvBooking.CurrentRow.Index].Value.ToString();

            panelStatusOrder.Visible = false;   
        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrder.CurrentRow!=null)
            {
                OrderID = Convert.ToInt32(dgvOrder["OrderID", dgvOrder.CurrentRow.Index].Value);
            }
        }

        private void numQuantity_ValueChange(object sender, EventArgs e)
        {
            lblTotal.Text = (price * numQuantity.Value).ToString();
        }

        // Sideways Mehtods ---------------------------------------------------
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

        private void txtEmpNationalCode_OnValueChanged(object sender, EventArgs e)
        {
            _bookingData.DefaultView.RowFilter = string.Format("RoomNo LIKE '{0}%'", txtEmpNationalCode.Text);
        }

        //Card Service Methods => ADD DELETE UPDATE ------------------------------

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

                using (ActionSerivce actionService = new ActionSerivce(ActionSerivce.Action.Add))
                {
                    //actionFood.FoodID = FoodID;
                    actionService.ShowDialog();
                    if (actionService.completeActionFlag)
                    {
                        LoadServiceData();
                        dgvService.ClearSelection();
                        Current.CurrentUser.Activities.Add(
                            new Activity("Submit New Service", "New Service has been submited by " + Current.CurrentUser.Firstname + " " + Current.CurrentUser.Lastname)
                            );

                    }
                }
            }   
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ServiceID < 0)
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

                    using (ActionSerivce actionService = new ActionSerivce(ActionSerivce.Action.Edit))
                    {
                        actionService.ServiceID = ServiceID;
                        actionService.ShowDialog();

                        if (actionService.completeActionFlag)
                        {
                            LoadServiceData();
                            int rowIndex = -1;

                            Current.CurrentUser.Activities.Add(
                                new Activity("Edit Service", 
                                "Service's information has been edited by " + Current.CurrentUser.Firstname + " " + Current.CurrentUser.Lastname));

                            DataGridViewRow row = dgvService.Rows
                                .Cast<DataGridViewRow>()
                                .Where(r => r.Cells["ID"].Value.ToString().Equals(ServiceID.ToString()))
                                .First();

                            rowIndex = row.Index;

                            dgvService.ClearSelection();
                            dgvService.Rows[rowIndex].Selected = true;
                        }
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ServiceID < 0)
            {
                MessageBox.Show("Please Select Row");
            }
            else
            {
                var dialogResult = MessageBox.Show("Are You Sure You Want To Delete This Record ?", "Delete", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    var resultDelete = _serviceService.DeleteService(ServiceID);
                    if (resultDelete)
                    {
                        LoadServiceData();
                        dgvService.ClearSelection();
                        Current.CurrentUser.Activities.Add(
                            new Activity("Delete Service","a Service has been deleted by " + 
                            Current.CurrentUser.Firstname + " " + Current.CurrentUser.Lastname));
                    }
                    else
                    {
                        MessageBox.Show("Unable TO Compelete Action ", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (doubleClickBookFlag && doubleClickServiceFlag)
            {
                var orderService = new OrderService()
                {
                    ID = ServiceID,
                    ResID = ResID,
                    Count = numQuantity.Value,
                    DateModified = DateTime.Now,
                    Total = Convert.ToInt32(lblTotal.Text)
                };
                var resultInsert = _orderServiceService.InsertOrderService(orderService);
                if (resultInsert)
                {
                    PanelStatus(panelStatusOrder, "Action Completed", Status.Green);
                    LoadOrderData();
                    dgvService.ClearSelection();
                    dgvBooking.ClearSelection();
                    dgvOrder.ClearSelection();
                    Current.CurrentUser.Activities.Add
                        (new Activity("Submit New Service Order",
                        "New Service order has been submited by " + Current.CurrentUser.Firstname + " " + Current.CurrentUser.Lastname)
                        );
                }
                else
                {
                    PanelStatus(panelStatusOrder, "Unable To Complete Action", Status.Red);
                }
            }
            else if (!doubleClickServiceFlag)
            {
                PanelStatus(panelStatusOrder, "Service Not Selected", Status.Red);
            }
            else if (!doubleClickBookFlag)
            {
                PanelStatus(panelStatusOrder, "Book Not Selected", Status.Red);
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (OrderID < 0)
            {
                MessageBox.Show("Please Select Row");
            }
            else
            {
                var dialogResult = MessageBox.Show(
                    "Are You Sure You Want To Delete This Record ?", "Delete", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    var resultDelete = _orderServiceService.DeleteOrderService(OrderID);
                    if (resultDelete)
                    {
                        LoadOrderData();
                        dgvOrder.ClearSelection();
                        Current.CurrentUser.Activities.Add(
                            new Activity("Delete Service Order",
                            "an Order from Services List has been deleted by " + 
                            Current.CurrentUser.Firstname + " " + Current.CurrentUser.Lastname));
                    }
                    else
                    {
                        MessageBox.Show("Unable TO Compelete Action ", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnServiceReport_Click(object sender, EventArgs e)
        {
            if (serviceData != null)
            {
                Current.CurrentUser.Activities.Add(
                    new Activity("Creat New Report", 
                    "A List of Services Report has been created by " + Current.CurrentUser.Firstname + " " + Current.CurrentUser.Lastname)
                    );

                StiReport report = new StiReport();
                report.Load("Report/FoodReport.mrt");
                StiText txtTitle = new StiText();
                txtTitle = report.GetComponentByName("txtTitle") as StiText;
                txtTitle.Text = "List Of Services";

                Report.SetHotelComponents(report, Current.CurrentUser.Branch);
                report.RegBusinessObject("Food", serviceData);
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
