using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement
{
    public partial class frmInvoiceEdit : Form
    {
        public double Discount { get; private set; }
        public string Description { get; private set; }

        private readonly BillService _billService;

        public frmInvoiceEdit()
        {
            InitializeComponent();

            _billService = new BillService();
        }

        private void frmInvoiceEdit_Load(object sender, EventArgs e)
        {
            // HotelDatabase.Bill.SearchBill(InvoiceDetail.ResID);
            var bill = _billService.GetBill(null, InvoiceDetail.ResID);
            txtDis.Text = bill.Discount.ToString();

            if (bill.Description != null)
            {
                txtDes.Text = bill.Description.ToString();
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
            Discount = Convert.ToDouble(txtDis.Text.Trim());
            if (txtDes.Text != null)
            {
                Description = txtDes.Text;
            }
            this.Dispose(); 
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
