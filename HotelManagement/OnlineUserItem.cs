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
    public partial class OnlineUserItem : UserControl
    {
        public User user;
        public OnlineUserItem()
        {
            InitializeComponent();
        }
        public OnlineUserItem(User user)
        {
            InitializeComponent();
            this.user = user;
            lblName.Text = user.Name;
            lblBranchName.Text = user.Branch;
            picProfile.Image = Image.FromStream(new MemoryStream(user.Image));
            this.Cursor = Cursors.Hand;
        }
    }
}
