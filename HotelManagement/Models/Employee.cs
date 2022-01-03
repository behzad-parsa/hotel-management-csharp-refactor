using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Employee 
    {
        public new int ID { get; set; }
        public int ActID { get; set; }
        public int BranchID { get; set; }
        public DateTime HireDate { get; set; }
        public string Education { get; set; }
        public int Salary { get; set; } 

        public Employee()
        {

        }
        //public Employee(int id , Actor actor) : base(actor)
        //{
        //    ID = id;
        //    ActID = actor.ID;
        //}
        //public Employee(Actor actor) : base(actor)
        //{
        //    ActID = actor.ID;
        //}
    }
}
