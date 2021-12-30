using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Customer : Actor
    {
        public new int ID { get; set; }
        public int ActID { get; set; }
    }
}
