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

            //Test

            TransactService transactService = new TransactService();
            var transact = new Transact()
            {
                AccountID = 2,
                DateModified = DateTime.Now,
                Description = "Test",
                Amount = 4555555,
                TransactionNumber = "Na-1234",
                PaymentMethodID = 1,
                TransactionTypeID = 1
            };

            var resultinsert = transactService.InsertTransact(transact);

            transact.ID = transactService.LastInsertedId;
            transact.Description = "Updated Test";
            var resultUpdate = transactService.UpdateTransact(transact);

            var deleteResult = transactService.DeleteTransact(transact.ID);

            var allPayment = transactService.GetAllPaymentMethods();
            var allTransaction = transactService.GetAllTransactionTypes();
        }
        
    }
}
