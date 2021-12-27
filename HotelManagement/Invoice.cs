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
    public partial class Invoice : UserControl
    {
        public Invoice()
        {
            InitializeComponent();
        }

        //private void panelEmpLeft_Paint(object sender, PaintEventArgs e)
        //{

        //}

        private void Invoice_Load(object sender, EventArgs e)
        {

            panelContainer.Controls.Add(new CardInvoice());

        }
    }
}
