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
    public partial class TabBill : UserControl
    {
        public TabBill()
        {
            InitializeComponent();
        }
        private void ActiveTab(Control lblTab)
        {

            //lblTab.Enabled = true;
            lineTab.Width = lblTab.Width;
            lineTab.Left = lblTab.Left;
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

        private void lblInvoice_Click(object sender, EventArgs e)
        {
            ActiveTab(lblInvoice, true);
            ActiveTab(lblAccount, false);
            ActiveTab(lblTransact, false);
            //this.AutoScroll = true;
            panelContainer.AutoScroll = true;
            AddControlsToPanel(new Invoice());
        }

        private void lblAccount_Click(object sender, EventArgs e)
        {
            ActiveTab(lblInvoice, false);
            ActiveTab(lblAccount, true);
            ActiveTab(lblTransact, false);
            //this.AutoScroll = false;
            panelContainer.AutoScroll = false ;
            AddControlsToPanel(new CardAccounts());
        }

        private void lblNewUser_Click(object sender, EventArgs e)
        {
            ActiveTab(lblInvoice, false);
            ActiveTab(lblAccount, false);
            ActiveTab(lblTransact, true);
            panelContainer.AutoScroll = false ;
            //this.AutoScroll = false;

            AddControlsToPanel(new CardTransact());
        }

        private void TabBill_Load(object sender, EventArgs e)
        {
            AddControlsToPanel(new Invoice());
            panelContainer.AutoScroll = true;
        }
    }
}
