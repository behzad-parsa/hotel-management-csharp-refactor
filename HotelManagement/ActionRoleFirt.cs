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
using randz.CustomControls;

namespace HotelManagement
{
    public partial class ActionRoleFirt : Form
    {
        public ActionRoleFirt()
        {
            InitializeComponent();
        }

        private void ActionRole_Load(object sender, EventArgs e)
        {

        }

        private void ActiveTab(Control Tab)
        {
            Tab.BackColor = Color.White;
            foreach (var item in Tab.Controls )
            {
                if (item is BunifuSeparator)
                {
                    var line = item as BunifuSeparator;
                    line.Visible = true;
                }
                if (item is VerticalLabel)
                {
                    var lbl = item as VerticalLabel;
                    lbl.ForeColor = Color.Black;
                }
            }
        }

        private void DeactiveTab(Control Tab)
        {
            Tab.BackColor = Color.FromArgb(245, 249, 252);
            foreach (var item in Tab.Controls)
            {
                if (item is BunifuSeparator)
                {
                    var line = item as BunifuSeparator;
                    line.Visible = false;

                }
                if (item is VerticalLabel)
                {
                    var lbl = item as VerticalLabel;
                    lbl.ForeColor = Color.DarkGray;

                }
            }
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panelNew_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panelEdit_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panelNew_Click(object sender, EventArgs e)
        {
            ActiveTab(panelEdit, false);
            ActiveTab(panelNew, true);
            AddControlsToPanel(new NewRole());
        }

        private void panelEdit_Click(object sender, EventArgs e)
        {
            ActiveTab(panelEdit, true);
            ActiveTab(panelNew, false);
            AddControlsToPanel(new EditRole());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
