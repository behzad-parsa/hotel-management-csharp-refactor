using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelManagement
{
    public class Customer : ActorSecond
    {
        public new int ID { get; set; }
        public int ActID { get; set; }


        public List<GuestSecond> LstGuest { get; set; }




        public Customer(string fname, string lname, string nationalCode, string mobile, DateTime birth, string gender, string nationality, string email, string tel, string state, string city, string address)
         : base(fname, lname, nationalCode  , mobile , birth , gender , nationality , email , tel , state , city , address)
        {
            LstGuest = new List<GuestSecond>();
        }

        public Customer(int actID  , string fname, string lname, string nationalCode, string gender, DateTime birth, string mobile)
            : base(fname, lname, nationalCode, gender, birth, mobile)
        {
          
            this.ActID = actID;

            LstGuest = new List<GuestSecond>();
           
        }



        public Customer(int id , int actID, string fname, string lname, string nationalCode, string mobile, DateTime birth, string gender, string nationality, string email, string tel, string state, string city, string address)
         : base(actID ,  fname, lname, nationalCode, mobile, birth, gender, nationality, email, tel, state, city, address)
        {
            this.ID = id;
           // this.ActID = actID;
            LstGuest = new List<GuestSecond>();
        }



    }
}
