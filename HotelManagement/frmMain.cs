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
  
            
            //this.WindowState = FormWindowState.Maximized;
            ///PanelWidth = panelLeftSlide.Width;
            isCollapsed = true;
   

        }
        //public static ChatInfo.Chat chat = new ChatInfo.Chat();
        Timer refreshOnlineList;
        private void frmMain_Load(object sender, EventArgs e)
        {
            


            //Current.User.SearchUser("behzad75");


            HotelDatabase.Branch.SearchBranchWithID(Current.User.BranchID);
            lblTopName.Text ="Hello, "+ Current.User.Firstname ;
            lblBranchName.Text = HotelDatabase.Branch.BranchName + "  Hotel";
            picProfileTop.Image = Image.FromStream(new MemoryStream(Current.User.Image));
    

            AddControlsToPanel(new Dashboard());

            //chat.ConnectToChatServer();
            ChatForm.chat.ConnectToChatServer();

            refreshOnlineList = new Timer();
            refreshOnlineList.Interval = 2000;
            refreshOnlineList.Tick += RefreshOnlineList_Tick;
            refreshOnlineList.Start();


            //var g = gradientPanel2.ColorLeft.A;
            ////Get Weather


            //OpenWeatherAPI openWeather = new OpenWeatherAPI("aa38704926cc24c468c297a525497db3");
            //var weatherDate = openWeather.query("2643743");
            


        }

        private void RefreshOnlineList_Tick(object sender, EventArgs e)
        {

            if (ChatForm.chat.IsConnect)
            {
                ChatForm.chat.sndMcg(ChatInfo.SendType.OnlineListRequest, null, null, DateTime.MinValue);

            }

        }

        private const string accessErrorMsg = "Access Denied ,\nYou Don't have Enough Permissions To Access Contents.";


        //Bitmap Gradient2D(Rectangle r, Color c1, Color c2, Color c3, Color c4)
        //{
        //    Bitmap bmp = new Bitmap(r.Width, r.Height);

        //    float delta12R = 1f * (c2.R - c1.R) / r.Height;
        //    float delta12G = 1f * (c2.G - c1.G) / r.Height;
        //    float delta12B = 1f * (c2.B - c1.B) / r.Height;
        //    float delta34R = 1f * (c4.R - c3.R) / r.Height;
        //    float delta34G = 1f * (c4.G - c3.G) / r.Height;
        //    float delta34B = 1f * (c4.B - c3.B) / r.Height;
        //    using (Graphics G = Graphics.FromImage(bmp))
        //        for (int y = 0; y < r.Height; y++)
        //        {
        //            Color c12 = Color.FromArgb(255, c1.R + (int)(y * delta12R),
        //                  c1.G + (int)(y * delta12G), c1.B + (int)(y * delta12B));
        //            Color c34 = Color.FromArgb(255, c3.R + (int)(y * delta34R),
        //                  c3.G + (int)(y * delta34G), c3.B + (int)(y * delta34B));
        //            using (LinearGradientBrush lgBrush = new LinearGradientBrush(
        //                  new Rectangle(0, y, r.Width, 1), c12, c34, 0f))
        //            { G.FillRectangle(lgBrush, 0, y, r.Width, 1); }
        //        }
        //    return bmp;
        //}

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

            //if (panel3.Width == 100)
            //{

            //    panel3.Visible = false;
            //    panel3.Width = 260;
            //    bunifuTransition1.ShowSync(panel3);

            //}
            //else
            //{
            //    panel3.Visible = false;
            //    panel3.Width = 100;
            //    bunifuTransition1.ShowSync(panel3);
            //}

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
            //contain.Anchor = AnchorStyles;
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
                //TabServices g = new TabServices();
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
                //TabUser tabUser = new TabUser();
                AddControlsToPanel(new TabUser());
            }
            else
            {
                MessageBox.Show(accessErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnMessage_Click(object sender, EventArgs e)
        {
            //if (ChatForm.chat.IsConnect)
            //{
            //    ChatForm.chat.sndMcg(ChatInfo.SendType.OnlineListRequest, null, null, DateTime.MinValue);

            //}
            // var seder = ChatForm.chat.lstOnlineUser;
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
                //NewBranch newBranch = new NewBranch();
                //panelContainer.Controls.Add(newBranch);
                //this.Refresh();
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

            //logo = picLogo.Image;
            //logoFormat = logo.RawFormat;
            // selectPic = false;
            MemoryStream Ms = new MemoryStream();
            img.Save(Ms, img.RawFormat);

            //logo.Save(Ms, logoFormat);

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
            //if (this.WindowState == FormWindowState.Normal)
            //{
            //    this.WindowState = FormWindowState.Maximized;
            //    if (btnSize.Image == Properties.Resources.maxB)
            //    {
            //        btnSize.Image = Properties.Resources.minB;

            //    }
            //    else
            //    {
            //        btnSize.Image = Properties.Resources.minW;
            //    }
            //    //btnSize.Image = Properties.Resources._1954533_64;

            //}
            //else
            //{
            //    if (btnSize.Image == Properties.Resources.minB)
            //    {
            //        btnSize.Image = Properties.Resources.maxB;

            //    }
            //    else
            //    {
            //        btnSize.Image = Properties.Resources.maxW;
            //    }
            //    WindowState = FormWindowState.Normal;
            //    //btnSize.Image = Properties.Resources._1954538_64;
            //}


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
                //if (btnSize.Image == Properties.Resources.maxB)
                //{
                //    btnSize.Image = Properties.Resources.minB;

                //}
                //else
                //{
                //    btnSize.Image = Properties.Resources.minW;
                //}
                //btnSize.Image = Properties.Resources._1954533_64;

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
                //btnSize.Image = Properties.Resources._1954538_64;
            }
        }

        private void btnPower_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
