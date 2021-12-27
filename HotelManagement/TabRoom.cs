using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class TabRoom : UserControl
    {
        public TabRoom()
        {
            InitializeComponent();
        }

        private void TabRoom_Load(object sender, EventArgs e)
        {

            AddControlsToPanel(new NewRoom());

        }


        private void ActiveTab(Control lblTab)
        {

            //lblTab.Enabled = true;
            lineTab.Height = lblTab.Height;
            lineTab.Top = lblTab.Top;
            lblTab.ForeColor = Color.Black;
        }
        private void DeactiveTab(Control lblTab)
        {

            //lblTab.Enabled = false;

            lblTab.ForeColor = Color.DarkGray;
        }

        private void ActiveTab(Control lblTab, bool flag)
        {
            if (flag)
            {
                ActiveTab(lblTab);
            }
            else
            {
                DeactiveTab(lblTab);
            }




        }
        private void AddControlsToPanel(Control contain)
        {

            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(contain);
        }

        private void lblNewRoom_Click(object sender, EventArgs e)
        {
            ActiveTab(lblNewRoom, true);

            ActiveTab(lblRoomList, false);
            AddControlsToPanel(new NewRoom());
        }

        private void lblRoomList_Click(object sender, EventArgs e)
        {
            ActiveTab(lblNewRoom, false);

            ActiveTab(lblRoomList, true);
        }
    }
}
