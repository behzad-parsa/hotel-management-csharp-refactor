using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace HotelManagement
{
   
    public class GuestSecond : ActorSecond
    {
        //public string Firstname { get; set; }
        //public string NationalCode { get; set; }
        //public string Lastname { get; set; }
        //public string MobilePhone { get; set; }
        //public DateTime Birthday { get; set; }
        //public string Gender { get; set; }

        public int ActID { get; set; }
        public int CustomerID { get; set; }

        public DateTime DateModified { get; set; }

      
        public GuestSecond(int actID , int customerID , DateTime modifiedDate , string fname , string lname , string nationalCode , string gender , DateTime birth , string mobile  ) 
            : base(  fname,lname , nationalCode , gender , birth , mobile)
        {
            this.CustomerID = customerID;
            this.ActID = actID;
            this.DateModified = modifiedDate;
        }

        public GuestSecond( int actID , DateTime dateModified , string fname, string lname, string nationalCode, string gender, DateTime birth, string mobile)
          : base( actID ,fname, lname, nationalCode, gender, birth, mobile)
        {
            this.DateModified = dateModified;
        }



    }

}
