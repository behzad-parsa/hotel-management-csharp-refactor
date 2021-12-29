using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Branch
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Owner { get; set; }
        public string BranchName { get; set; }
        public string Rate { get; set; }
        public byte[] Logo { get; set; }
        public string Tel { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
