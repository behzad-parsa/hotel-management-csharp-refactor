using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Room
    {
        public int ID { get; set; }
        public int BranchID { get; set; }
        public int RoomNumberID { get; set; }
        public int RoomTypeID { get; set; }
        public bool IsEmpty { get; set; }
        public int Floor { get; set; }
        public int Capacity { get; set; }
        public int Price { get; set; } //Per Day
        public string Description { get; set; }

    }
}
