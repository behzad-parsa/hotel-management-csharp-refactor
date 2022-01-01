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
    public partial class TabUser : UserControl
    {
        public TabUser()
        {
            InitializeComponent();
        }

        private void TabUser_Load(object sender, EventArgs e)
        {
            AddControlsToPanel(new NewEmployee());
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

        private void lblEmployeeList_Click(object sender, EventArgs e)
        {
            ActiveTab(lblNewEmployee, false);
            ActiveTab(lblEmployeeList, true);
            ActiveTab(lblNewUser, false);
            ActiveTab(lblUserList, false);
            AddControlsToPanel(new EmployeeList());
        }

        private void lblNewEmployee_Click(object sender, EventArgs e)
        {
            ActiveTab(lblNewEmployee, true);
            ActiveTab(lblEmployeeList, false);
            ActiveTab(lblNewUser, false);
            ActiveTab(lblUserList, false);
            AddControlsToPanel(new NewEmployee());
        }

        private void lblNewUser_Click(object sender, EventArgs e)
        {
            ActiveTab(lblNewEmployee, false);
            ActiveTab(lblEmployeeList, false);
            ActiveTab(lblNewUser, true);
            ActiveTab(lblUserList, false);
            AddControlsToPanel(new NewUser());
        }

        private void lblUserList_Click(object sender, EventArgs e)
        {
            ActiveTab(lblNewEmployee, false);
            ActiveTab(lblEmployeeList, false);
            ActiveTab(lblNewUser, false);
            ActiveTab(lblUserList, true);
            AddControlsToPanel(new btnReportUser());   
        }
    }
}
