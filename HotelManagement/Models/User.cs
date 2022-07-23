using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class User
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int RoleID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Activate { get; set; }
        public byte[] Image { get; set; }
    }
}
