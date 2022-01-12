using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagement.Services;
using HotelManagement.Models;

namespace HotelManagement
{
    public partial class EditAccount : Form
    {
        private readonly AccountService _accountService;
        public bool completeFlag = false;
        public int accountID;
        public EditAccount()
        {
            InitializeComponent();

            _accountService = new AccountService(); 
        }
        private void EditAccount_Load(object sender, EventArgs e)
        {
            var account = _accountService.GetAccount(accountID);
            //if (HotelDatabase.Account.SearchAccount(accountID))
            if (account != null)
            {
                txtAccountName.Text = account.AccountName;
                txtBank.Text = account.Bank;
                txtBalance.Text = account.Balance.ToString();
                txtAccountNumber.Text = account.AccountNumber;
                if (account.Description != null)
                    txtDescription.Text = account.Description;
                
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

            //var result = HotelDatabase.Account.Update(accountID, txtAccountName.Text, txtAccountNumber.Text, txtBank.Text, Convert.ToDouble(txtBalance.Text), txtDescription.Text);
            var account = new Account()
            {
                ID = accountID,
                AccountName = txtAccountName.Text,
                AccountNumber = txtAccountNumber.Text,
                Bank = txtBank.Text,
                Balance = Convert.ToDouble(txtBalance.Text),
                Description = txtDescription.Text
            };
            var resultUpdate = _accountService.UpdateAccount(account);
            if (resultUpdate)
            {
                PanelStatus("Action Completed Successfuly", Status.Green);
                this.Dispose();
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
            }
            else if (status == Status.Green)
            {
                prgbCustError.ProgressColor = Color.Green;
                lblCustError.ForeColor = Color.Green;
            }
            else
            {
                prgbCustError.ProgressColor = Color.Blue;
                lblCustError.ForeColor = Color.Blue;
            }
        }
    }
}
