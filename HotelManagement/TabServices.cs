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
    public partial class TabServices : UserControl
    {
        public TabServices()
        {
            InitializeComponent();
            AddControlsToPanel(new OrderFoodControl());
        }

        private void lblFood_Click(object sender, EventArgs e)
        {
            ActiveTab(lblFood, true);
            ActiveTab(lblService, false);
            AddControlsToPanel(new OrderFoodControl());
        }

        private void lblService_Click(object sender, EventArgs e)
        {
            ActiveTab(lblFood, false);
            ActiveTab(lblService, true);
            AddControlsToPanel(new OrderServiceControl());
        }
        private void ActiveTab(Control lblTab)
        {
            lineTab.Width = lblTab.Width;
            lineTab.Left = lblTab.Left;
            lblTab.ForeColor = Color.Black;
        }
        private void DeactiveTab(Control lblTab)
        {
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
            contain.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(contain);
        }
    }
}
