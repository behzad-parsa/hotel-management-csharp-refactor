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
   
    public class Guest : Actor
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

      
        public Guest(int actID , int customerID , DateTime modifiedDate , string fname , string lname , string nationalCode , string gender , DateTime birth , string mobile  ) 
            : base(  fname,lname , nationalCode , gender , birth , mobile)
        {
            this.CustomerID = customerID;
            this.ActID = actID;
            this.DateModified = modifiedDate;
        }

        public Guest( int actID , DateTime dateModified , string fname, string lname, string nationalCode, string gender, DateTime birth, string mobile)
          : base( actID ,fname, lname, nationalCode, gender, birth, mobile)
        {


            this.DateModified = dateModified;
         
        }




        //private  SqlConnection con = new SqlConnection();
        //private  SqlCommand cmd = new SqlCommand();
        //private  SqlDataAdapter adp = new SqlDataAdapter();
        //private  DataTable dataTable = new DataTable();

        

        //private void MakeConnection()
        //{
        //    try
        //    {
        //        con.ConnectionString = "Data Source = (Local); Initial Catalog = Hotel; Integrated Security = True";
        //        cmd.Connection = con;

        //    }
        //    catch
        //    {

        //        ;
        //    }

            
        //}

        //private void Connect()
        //{
        //    try
        //    {
        //        if (con.State == ConnectionState.Closed)
        //        {

        //            con.Open();

        //        }


        //    }
        //    catch
        //    {

        //        ;
        //    }

        //}

        //private void Disconnect()
        //{
        //    try
        //    {
        //        if (con.State == ConnectionState.Open)
        //        {
        //            con.Close();

        //        }

        //    }
        //    catch
        //    {

        //        ;
        //    }
        //}


        //public bool Insert()
        //{

        //    try
        //    {
                
        //        MakeConnection();
        //        //dataTable = new DataTable();
        //        cmd.CommandText = "Insert Into \"Guest\" ( ActID , CustomerID , DateModified) Values (@ActID , @CustomerID , @DateModified)";
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@ActID", ActID);
        //        cmd.Parameters.AddWithValue("@CustomerID",CustomerID );
        //        cmd.Parameters.AddWithValue("@DateModified", DateTime.Now.ToString("YYYY-MM-DD"));
        

        //        // DateTime.Now.ToString("h:mm:ss tt")


        //        Connect();
        //        cmd.ExecuteNonQuery();
        //        Disconnect();

        //        return true;

        //    }
        //    catch
        //    {

        //        return false;
        //    }


        //}









    }
    //namespace GuestDatabase
    //{
    //    public  class Guest
    //    {
    //        public  string Firstname { get; set; }
    //        public  string Lastname { get; set; }
    //        public  string NationalCode { get; set; }
    //        public  string MobilePhone { get; set; }
    //        public  DateTime Birthday { get; set; }
    //        public  string Gender { get; set; }



    //        public  int ActID { get; set; }

    //        private  SqlConnection con = new SqlConnection();
    //        private  SqlCommand cmd = new SqlCommand();
    //        private  SqlDataAdapter adp = new SqlDataAdapter();
    //        private  DataTable dataTable = new DataTable();





    //        private  void MakeConnection()
    //        {
    //            try
    //            {
    //                con.ConnectionString = "Data Source = (Local); Initial Catalog = Hotel; Integrated Security = True";
    //                cmd.Connection = con;

    //            }
    //            catch
    //            {

    //                ;
    //            }


    //        }

    //        private  void Connect()
    //        {
    //            try
    //            {
    //                if (con.State == ConnectionState.Closed)
    //                {

    //                    con.Open();

    //                }


    //            }
    //            catch
    //            {

    //                ;
    //            }

    //        }

    //        private  void Disconnect()
    //        {
    //            try
    //            {
    //                if (con.State == ConnectionState.Open)
    //                {
    //                    con.Close();

    //                }

    //            }
    //            catch
    //            {

    //                ;
    //            }
    //        }



    //        public  bool InsertGuestToActor()
    //        {
                
    //            try
    //            {

    //                MakeConnection();
    //                //dataTable = new DataTable();
    //                cmd.CommandText = "Insert Into \"Actor\" ( Firstname , Lastname , NationalCode , Mobile , Birthday , Gender) Values ( @Firstname , @Lastname , @NationalCode , @Mobile , @Birthday , @Gender)";
    //                cmd.Parameters.Clear();
    //                cmd.Parameters.AddWithValue("@Firstname", Firstname );
    //                cmd.Parameters.AddWithValue("@Lastname", Lastname);
    //                cmd.Parameters.AddWithValue("@NationalCode",NationalCode );
    //                cmd.Parameters.AddWithValue("@Mobile", MobilePhone);
    //                cmd.Parameters.AddWithValue("@Birthday", Birthday );
    //                cmd.Parameters.AddWithValue("@Gender", Gender);

    //                // DateTime.Now.ToString("h:mm:ss tt")


    //                Connect();
    //                cmd.ExecuteNonQuery();
    //                Disconnect();

    //                return true;

    //            }
    //            catch
    //            {

    //                return false;
    //            }


    //        }



    //        //public  bool SearchUser()
    //        //{
    //        //    try
    //        //    {


    //        //        MakeConnection();
    //        //        dataTable = new DataTable();

    //        //        cmd.CommandText = "SELECT * FROM \"User\" Where Username = @Username ";
    //        //        cmd.Parameters.Clear();
    //        //        cmd.Parameters.AddWithValue("@Username", Username);


    //        //        adp.SelectCommand = cmd;

    //        //        Connect();
    //        //        adp.Fill(dataTable);
    //        //        Disconnect();

    //        //        if (dataTable.Rows.Count != 0)
    //        //        {
    //        //            ID = Convert.ToInt32(dataTable.Rows[0]["ID"]);
    //        //            Username = dataTable.Rows[0]["Username"].ToString();
    //        //            Password = dataTable.Rows[0]["Password"].ToString();
    //        //            Activate = Convert.ToBoolean(dataTable.Rows[0]["Activate"]);
    //        //            //Image = (byte[])dataTable.Rows[0]["Image"];


    //        //            return true;


    //        //        }
    //        //        else
    //        //        {
    //        //            return false;
    //        //        }




    //        //    }
    //        //    catch
    //        //    {

    //        //        return false;
    //        //    }











    //        //}





    //    }






    //}
}
