using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using Newtonsoft.Json;
using OpenWeatherApi;
using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement
{

    public partial class frmMain : Form
    {   
        bool isCollapsed;
        private readonly BranchService _branchService;


        public frmMain()
        {
            InitializeComponent();
            isCollapsed = true;
            _branchService = new BranchService();
        }

        Timer refreshOnlineList;
        private void frmMain_Load(object sender, EventArgs e)
        {          
            Current.CurrentUser.SearchUser("behzad75");
            //HotelDatabase.Branch.SearchBranchWithID(Current.User.BranchID);
            var branch = _branchService.GetBranch(Current.CurrentUser.BranchID);
            lblTopName.Text ="Hello, "+ Current.CurrentUser.Firstname ;
            lblBranchName.Text = branch.BranchName + "  Hotel";
            picProfileTop.Image = Image.FromStream(new MemoryStream(Current.CurrentUser.Image));
    
            AddControlsToPanel(new Dashboard());
            ChatForm.chat.ConnectToChatServer();
            refreshOnlineList = new Timer();
            refreshOnlineList.Interval = 2000;
            refreshOnlineList.Tick += RefreshOnlineList_Tick;
            refreshOnlineList.Start();

        }

        private void RefreshOnlineList_Tick(object sender, EventArgs e)
        {
            if (ChatForm.chat.IsConnect)
            {
                ChatForm.chat.SendMessage(ChatInfo.SendType.OnlineListRequest, null, null, DateTime.MinValue);
            }
        }

        private const string accessErrorMsg = "Access Denied ,\nYou Don't have Enough Permissions To Access Contents.";

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelLeftSlide.Width += 10;
                if (panelLeftSlide.Width >= 215)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                    btnSlideMenu.Image = Properties.Resources.close;
                }    
            }
            else
            {
                panelLeftSlide.Width -= 10;
                if (panelLeftSlide.Width <= 70)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                    btnSlideMenu.Image = Properties.Resources.menu__3_;
                }
            }

        }

        private void btnSlideMenu_Click(object sender, EventArgs e)
        {
            timer1.Start();          
        }

        private void MoveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height -1;
        }
        private void AddControlsToPanel(Control contain)
        {
            contain.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(contain);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {          
            //if (Current.User.AccessLevel.Contains("Booking"))
            if (Current.CurrentUser.AccessLevel.Select(m => m.Title).Contains("Booking"))
            {
                MoveSidePanel(btnBooking);
                TabBooking tabBooking = new TabBooking();
                AddControlsToPanel(tabBooking);
            }
            else
            {
                MessageBox.Show(accessErrorMsg , "Error" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btnDashboard);
            AddControlsToPanel(new Dashboard());
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            //if (Current.User.AccessLevel.Contains("Room"))
            if (Current.CurrentUser.AccessLevel.Select(m=>m.Title).Contains("Room"))
            {
                MoveSidePanel(btnRoom);
                AddControlsToPanel(new NewRoom());
            }
            else
            {
                MessageBox.Show(accessErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAccounting_Click(object sender, EventArgs e)
        {
            //if (Current.User.AccessLevel.Contains("Billing"))
            if (Current.CurrentUser.AccessLevel.Select(m => m.Title).Contains("Billing"))
            {
                MoveSidePanel(btnAccounting);
                AddControlsToPanel(new TabBill());
            }
            else
            {
                MessageBox.Show(accessErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            //if (Current.User.AccessLevel.Contains("Services"))
            if (Current.CurrentUser.AccessLevel.Select(m => m.Title).Contains("Services"))
            {
                MoveSidePanel(btnService);
                AddControlsToPanel(new TabServices());
            }
            else
            {
                MessageBox.Show(accessErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUser_Click_1(object sender, EventArgs e)
        {
            //if (Current.User.AccessLevel.Contains("User"))
            if (Current.CurrentUser.AccessLevel.Select(m => m.Title).Contains("User"))
            {
                MoveSidePanel(btnUser);
                AddControlsToPanel(new TabUser());
            }
            else
            {
                MessageBox.Show(accessErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMessage_Click(object sender, EventArgs e)
        {
            //if (Current.User.AccessLevel.Contains("Message"))
            if (Current.CurrentUser.AccessLevel.Select(m => m.Title).Contains("Message"))
            {
                MoveSidePanel(btnMessage);
                AddControlsToPanel(new ChatForm());
            }
            else
            {
                MessageBox.Show(accessErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
 
        }

        private void btnBranch_Click(object sender, EventArgs e)
        {

            //if (Current.User.AccessLevel.Contains("Message"))
            if (Current.CurrentUser.AccessLevel.Select(m => m.Title).Contains("Message"))
            {
                MoveSidePanel(btnBranch);
                AddControlsToPanel(new NewBranch());
            }
            else
            {
                MessageBox.Show(accessErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btnSetting);
            AddControlsToPanel(new Setting());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            f.Show();
            this.Hide();
        }

        private void btnSize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                if (panelTop.BackColor == Color.FromArgb(255,255,255))
                {
                    btnSize.Image = Properties.Resources.minB;
                }
                else
                {
                    btnSize.Image = Properties.Resources.minW;
                }
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                if (panelTop.BackColor == Color.FromArgb(255, 255, 255))
                {
                    btnSize.Image = Properties.Resources.maxB;
                }
                else
                {
                    btnSize.Image = Properties.Resources.maxW;
                }
                WindowState = FormWindowState.Normal;
            }
        }

        private void btnPower_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
