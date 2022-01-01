using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class frmInvoiceEdit : Form
    {
        public frmInvoiceEdit()
        {
            InitializeComponent();
        }
        //public double discount { get { return Convert.ToDouble(txtDis.Text.Trim()); } }
        public double discount { get; private set; }
        public string description { get; private set; }
        private void frmInvoiceEdit_Load(object sender, EventArgs e)
        {

            HotelDatabase.Bill.SearchBill(InvoiceDetail.ResID);

            txtDis.Text = HotelDatabase.Bill.Discount.ToString();
            if (HotelDatabase.Bill.Description != null)
            {
                txtDes.Text = HotelDatabase.Bill.Description.ToString();
            }

        }

        private void txtDis_OnValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtDis.Text)>100)
            {
                txtDis.Text = "100";
            }
            else if (Convert.ToDouble(txtDis.Text) < 0)
            {
                txtDis.Text = "0";

            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            discount = Convert.ToDouble(txtDis.Text.Trim());
            if (txtDes.Text != null)
            {
                description = txtDes.Text;
            }

            this.Dispose(); 
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
