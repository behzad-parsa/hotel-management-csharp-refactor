using HotelManagement.Services;
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

namespace HotelManagement
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
            Account account = new Account()
            {
                AccountName = "Maleki",
                AccountNumber = "4444",
                Bank="Sepah",
                Description="Main Account",
                Balance = 2000,
                BranchID = 1
            };
            AccountService accountService = new AccountService();
            accountService.InsertAccount(account);

            var getAccount = accountService.GetAccount(5);
            getAccount.AccountName = "Behzad Parsa";
            var res = accountService.UpdateAccount(getAccount);
            account.ID = accountService.LastInsertedId;
            var delete = accountService.DeleteAccount(account.ID);

            var accounts = accountService.GetAllBranchAccounts(1);

        }
        
    }
}
