using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Guest : Actor
    {
        public int ActID { get; set; }
        public int CustomerID { get; set; }
        public DateTime DateModified { get; set; }

        public Guest()
        {

        }
        public Guest(Actor actor):base(actor)
        {
            ActID = actor.ID;

        }
        public Guest(int customerID , DateTime dateModified ,Actor actor):base(actor)
        {
            ActID = actor.ID;
            this.CustomerID = customerID;
            this.DateModified = dateModified;

        }
    }
}
