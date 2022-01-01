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


namespace HotelManagement
{

    public partial class frmMain : Form
    {   
        bool isCollapsed;
        public frmMain()
        {
            InitializeComponent();
            isCollapsed = true;
        }

        Timer refreshOnlineList;
        private void frmMain_Load(object sender, EventArgs e)
        {          
            Current.User.SearchUser("behzad75");
            HotelDatabase.Branch.SearchBranchWithID(Current.User.BranchID);
            lblTopName.Text ="Hello, "+ Current.User.Firstname ;
            lblBranchName.Text = HotelDatabase.Branch.BranchName + "  Hotel";
            picProfileTop.Image = Image.FromStream(new MemoryStream(Current.User.Image));
    
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
                ChatForm.chat.sndMcg(ChatInfo.SendType.OnlineListRequest, null, null, DateTime.MinValue);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

  
        private void panelLeftSlide_Paint(object sender, PaintEventArgs e)
        {
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
            if (Current.User.AccessLevel.Contains("Booking"))
            {
                MoveSidePanel(btnBooking);
                TabBooking tabBooing = new TabBooking();
                AddControlsToPanel(tabBooing);
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
            if (Current.User.AccessLevel.Contains("Room"))
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
            if (Current.User.AccessLevel.Contains("Billing"))
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
            if (Current.User.AccessLevel.Contains("Services"))
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
            if (Current.User.AccessLevel.Contains("User"))
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
            if (Current.User.AccessLevel.Contains("Message"))
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

            if (Current.User.AccessLevel.Contains("Message"))
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

        private byte[] ConvertPicToByte(Image img)
        {
            MemoryStream Ms = new MemoryStream();
            img.Save(Ms, img.RawFormat);
            return Ms.GetBuffer();
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

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
