using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int CustomerID { get; set; }
        public int RoomID { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalPayDueDate { get; set; }
        public DateTime CancelDate { get; set; }
    }
}
