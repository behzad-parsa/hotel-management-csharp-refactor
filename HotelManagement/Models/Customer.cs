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
        //public List<Guest> LstGuest { get; internal set; }

        public Customer()
        {

        }
        public Customer(int id , Actor actor) : base(actor)
        {
            ID = id;
            ActID = actor.ID;
        }          
        public Customer(int id )
        {
            ID = id;
        }       
        public Customer(Actor actor) : base(actor)
        {
            ActID = actor.ID;
        }


    }
}
