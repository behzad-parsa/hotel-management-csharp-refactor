using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using User = HotelManagement.ChatInfo.User;
using System.IO;

namespace HotelManagement
{
    public partial class PVItem : UserControl
    {
        public User user;
        //public string lastTime;
        //public string lastMsg;
        //Timer timer = new Timer();
        public PVItem()
        {
            InitializeComponent();
            //lblCounter.Parent = ovalPictureBox2;
            //bunifuCustomLabel4.Parent = pictureBox1;
            this.Cursor = Cursors.Hand;

        }
        public PVItem(User user)
        {
            InitializeComponent();
            this.Cursor = Cursors.Hand;
            this.user = user;
            lblName.Text = user.Name;
            picProfile.Image = Image.FromStream(new MemoryStream(user.Image));
            if (user.Message.Count != 0)
            {

                user.Message = user.Message.OrderByDescending(x => x.Date).ToList();
                lblLastMessage.Text = user.Message[0].Text.ToString();
                lblTime.Text = user.Message[0].Date.ToString("hh:mm tt");
            }



            //timer.Interval = 1;
            //timer.Tick += Timer_Tick;
            //timer.Start();
        }

        //private void Timer_Tick(object sender, EventArgs e)
        //{
        //    if(!string.IsNullOrEmpty(lastTime) && !string.IsNullOrEmpty(lastMsg))
        //    {

        //        lblLastMessage.Text = lastMsg;
        //        lblTime.Text = lastTime;
        //        this.Refresh();

        //    }
        //}


        private void PanelPV_Load(object sender, EventArgs e)
        {
            
        }



        private void lblName_MouseEnter(object sender, EventArgs e)
        {
            //this.MouseEnter += ();
        }

        //private void Parent_MouseEnter(object sender, EventArgs e)
        //{
        //    this.BackColor = Color.Aqua;
        //}
    }
}
