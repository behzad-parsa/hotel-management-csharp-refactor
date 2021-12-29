using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public int ActID { get; set; }
        public int BranchID { get; set; }
        public DateTime HireDate { get; set; }
        public string Education { get; set; }
        public int Salary { get; set; }

    }
}
