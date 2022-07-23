using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Transact
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public int PaymentMethodID { get; set; }
        public int TransactionTypeID { get; set; }
        public string TransactionNumber { get; set; }
        public double Amount { get; set; }
        public DateTime DateModified { get; set; }
        public string Description { get; set; }
    }
}
