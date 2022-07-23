using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Bill
    {
        public int ID { get; set; }
        public int ResID { get; set; }
        public int TransactionID { get; set; }
        public string BillNo { get; set; }
        public int RoomCharge { get; set; }
        public int FoodCharge { get; set; }
        public int ServiceCharge { get; set; }
        public int TotalCharge { get; set; }
        public double Discount { get; set; }
        public DateTime DateModified { get; set; }
        public string Description { get; set; }
    }
}
