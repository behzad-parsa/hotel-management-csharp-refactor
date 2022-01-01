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
        public PVItem()
        {
            InitializeComponent();
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
        }

        private void PanelPV_Load(object sender, EventArgs e)
        {       
        }
        private void lblName_MouseEnter(object sender, EventArgs e)
        {
        }
    }
}
