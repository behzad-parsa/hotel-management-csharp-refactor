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
    public partial class EditAccount : Form
    {
        public bool completeFlag = false;
        public int accountID;
        public EditAccount()
        {
            InitializeComponent();
        }

        private void EditAccount_Load(object sender, EventArgs e)
        {
            if (HotelDatabase.Account.SearchAccount(accountID))
            {
                txtAccountName.Text = HotelDatabase.Account.AccountName;
                txtBank.Text = HotelDatabase.Account.Bank;
                txtBalance.Text = HotelDatabase.Account.Balance.ToString();
                txtAccountNumber.Text = HotelDatabase.Account.AccountNumber;
                if (HotelDatabase.Account.Description != null)
                {
                    txtDescription.Text = HotelDatabase.Account.Description;

                }


            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text == "Description")
            {
                txtDescription.Text = null;
            }

            var result = HotelDatabase.Account.Update(accountID, txtAccountName.Text, txtAccountNumber.Text, txtBank.Text, Convert.ToDouble(txtBalance.Text), txtDescription.Text);
            if (result )
            {
                PanelStatus("Action Completed Successfuly", Status.Green);
                this.Dispose();
                //    Thread.Sleep(3000);
                //    this.Dispose();
                completeFlag = true;
            }

            else
            {
                PanelStatus("Unable to Complete Action", Status.Red);
            }
        }


        private enum Status
        {
            Green,
            Red,
            blue
        };
        private void PanelStatus(string text, Status status)
        {
            panelCustStatus.Visible = true;
            lblCustError.Text = text;
            if (status == Status.Red)
            {
                prgbCustError.ProgressColor = Color.Red;
                lblCustError.ForeColor = Color.Red;
                //lblCustError.Text = text;

            }
            else if (status == Status.Green)
            {

                prgbCustError.ProgressColor = Color.Green;
                lblCustError.ForeColor = Color.Green;
                //lblCustError.Text = text;

            }
            else
            {
                prgbCustError.ProgressColor = Color.Blue;
                lblCustError.ForeColor = Color.Blue;

            }




        }
    }
}
