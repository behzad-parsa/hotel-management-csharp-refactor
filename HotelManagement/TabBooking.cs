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
    public partial class TabBooking : UserControl
    {
        public TabBooking()
        {
            InitializeComponent();
        }

        private void TabBooking_Load(object sender, EventArgs e)
        {
            AddControlsToPanel(new NewBook());
        }


        private void AddControlsToPanel(Control contain)
        {
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(contain);
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

        private void ActiveTab(Control lblTab , bool flag)
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

        private void lblNewBook_Click(object sender, EventArgs e)
        {
            ActiveTab(lblNewBook, true);
            ActiveTab(lblBookList, false);
            AddControlsToPanel(new NewBook());
        }

        private void lblBookList_Click(object sender, EventArgs e)
        {
            ActiveTab(lblBookList , true);
            ActiveTab(lblNewBook, false);
            AddControlsToPanel(new BookList());
        }


    }
}
