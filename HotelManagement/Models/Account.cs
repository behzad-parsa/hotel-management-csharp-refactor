using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Account
    {
        public int ID { get; set; }
        public int BranchID { get; set; }
        public string Bank { get; set; }
        public double Balance { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string Description { get; set; }

    }
}
