using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement
{

    public partial class ActionSerivce : Form
    {
        private readonly ServiceService _serviceService;
        private readonly OrderServiceService _orderServiceService;
        
        public int ServiceID;
        public bool completeActionFlag = false;
        private bool addFlag;
        public enum Action
        {
            Add,
            Edit
        }

        public ActionSerivce(Action action)
        {
            InitializeComponent();

            if (action == Action.Add)
            {
                addFlag = true;
                panelTop.BackColor = Color.FromArgb(67, 176, 92);
                btnSave.Text = "Submit";
                btnSave.BackColor = Color.FromArgb(67, 176, 92);
                picIcon.Image = Properties.Resources._392530_48;
                lblTitle.Text = "New";
            }
            else
            {
                addFlag = false;
                panelTop.BackColor = Color.FromArgb(77, 182, 172);
                btnSave.Text = "Save";
                btnSave.BackColor = Color.FromArgb(77, 182, 172);
                picIcon.Image = Properties.Resources._326602_32;
                lblTitle.Text = "Edit";
            }

            _orderServiceService = new OrderServiceService();
            _serviceService = new ServiceService();
        }

        private void ActionSerivce_Load(object sender, EventArgs e)
        {
            //-------------Load Edit ------------------
            if (!addFlag)
            {
                var service = _serviceService.GetService(ServiceID);
                if (service != null)
                {

                    txtTitle.Text = service.Title;
                    txtPrice.Text = service.Price.ToString();
                    txtDecription.Text = service.Description;
                }
                else
                {
                    PanelStatus("Unable To Complete Action", Status.Red);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //------ SideWays Method ----------------------------
        private void TextBoxEnter(object sender, EventArgs e)
        {
            var txtBox = sender as BunifuMetroTextbox;
            txtBox.BorderColorIdle = Color.FromArgb(231, 228, 228);
            txtBox.ForeColor = Color.Black;
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

        private int txtCount = 0;
        private bool validationFlag = false;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            //---Validation----
            TextBoxCheck(txtPrice, "");
            TextBoxCheck(txtTitle, "");

            if (txtCount == 2)
            {
                bool isNumric = int.TryParse(txtPrice.Text, out int num);          
                if (isNumric)
                {
                    validationFlag = true;
                }
                else
                {
                    PanelStatus("Price Must Be Numeric", Status.Red);
                }
            }
            else
            {
                PanelStatus("Please Fill The Blank", Status.Red);
            }
            txtCount = 0;

            if (validationFlag)
            {
                validationFlag = false;

                //-------- Add Part ------------
                if (addFlag)
                {
                    //var res = HotelDatabase.Service.Insert(txtTitle.Text, Convert.ToInt32(txtPrice.Text), txtDecription.Text);
                    var service = new Service()
                    {
                        Title = txtTitle.Text,
                        Price = Convert.ToInt32(txtPrice.Text),
                        Description = txtDecription.Text
                    };
                    var resultInsert = _serviceService.InsertService(service);
                    if (resultInsert)
                    {
                        PanelStatus("Action Completed Successfully", Status.Green);
                        completeActionFlag = true;
                        this.Dispose();
                    }
                    else
                    {
                        completeActionFlag = false;
                        PanelStatus("Unable To Complete Action --- Insert", Status.Red);
                    }
                }
                //---------- This is Edit Part -----------
                else
                {
                    var service = new Service()
                    {
                        ID = ServiceID,
                        Title = txtTitle.Text,
                        Description = txtDecription.Text,
                        Price = Convert.ToInt32(txtPrice.Text)
                    };
                    var resultUpdate = _serviceService.UpdateService(service);
                    if (resultUpdate)
                    {
                        PanelStatus("Action Completed Successfully", Status.Green);
                        completeActionFlag = true;
                        this.Dispose();
                    }
                    else
                    {
                        completeActionFlag = false;
                        PanelStatus("Unable To Complete Action --- Update", Status.Red);
                    }
                }
            }
        }
    }
}
