using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagement
{
    public class Actor
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public  string Lastname { get; set; }
        public  string NationalCode { get; set; }
        public  string Mobile { get; set; }
        public  DateTime Birthday { get; set; }
        public  string Gender { get; set; }

        public  string Nationality { get; set; }

        public  string Email { get; set; }

        public  string Tel { get; set; }
        public  string State { get; set; }
        public  string City { get; set; }

        public  string Address { get; set; }

        //private  SqlConnection con = new SqlConnection();
        //private  SqlCommand cmd = new SqlCommand();
        //private  SqlDataAdapter adp = new SqlDataAdapter();
        //private  DataTable dataTable = new DataTable();

        public Actor( string fname , string lname , string nationalCode , string mobile , DateTime birth , string gender , string nationality , string email , string tel , string state , string city , string address)
        {
            this.Firstname = fname;
            this.Lastname = lname;
            this.NationalCode = nationalCode;
            this.Nationality = nationality;
            this.Mobile = mobile;
            this.State = state;
            this.Tel = tel;
            this.Gender = gender;
            this.Birthday = birth;
            this.Email = email;
            this.City = city;
            this.Address = address;





        }
        public Actor(string fname, string lname, string nationalCode, string gender, DateTime birth , string mobile)
        {
            this.Firstname = fname;
            this.Lastname = lname;
            this.NationalCode = nationalCode;
            this.Mobile = mobile;
            this.Gender = gender;
            this.Birthday = birth;
            //this.Address = address;





        }


        public Actor( int id, string fname, string lname, string nationalCode, string mobile, DateTime birth, string gender, string nationality, string email, string tel, string state, string city, string address)
        {
            this.ID = id;
            this.Firstname = fname;
            this.Lastname = lname;
            this.NationalCode = nationalCode;
            this.Nationality = nationality;
            this.Mobile = mobile;
            this.State = state;
            this.Tel = tel;
            this.Gender = gender;
            this.Birthday = birth;
            this.Email = email;
            this.City = city;
            this.Address = address;
        }


        public Actor(int id , string fname, string lname, string nationalCode, string gender, DateTime birth, string mobile)
        {
            this.ID = id;
            this.Firstname = fname;
            this.Lastname = lname;
            this.NationalCode = nationalCode;
            this.Mobile = mobile;
            this.Gender = gender;
            this.Birthday = birth;
            //this.Address = address;
        }

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

        //private  void Connect()
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

        //private  void Disconnect()
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

        //public bool InsertAll()
        //{
        //    try
        //    {

        //        MakeConnection();
        //        //dataTable = new DataTable();
        //        cmd.CommandText = "Insert Into \"Actor\" (Firstname , Lastname , Birthday , NationalCode , Nationality , Email , Tel , Mobile , Gender , State , City , Address) Values(@Firstname , @Lastname , @Birthday , @NationalCode , @Nationality , @Email , @Tel , @Mobile , @Gender , @State , @City , @Address)";
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@Firstname", Firstname);
        //        cmd.Parameters.AddWithValue("@Lastname ", Lastname);
        //        cmd.Parameters.AddWithValue("@Birthday", Birthday);
        //        cmd.Parameters.AddWithValue("@NationalCode", NationalCode);
        //        cmd.Parameters.AddWithValue("@Nationality", Nationality);
        //        cmd.Parameters.AddWithValue("@Email", Email);
        //        cmd.Parameters.AddWithValue("@Tel", Tel);
        //        cmd.Parameters.AddWithValue("@Mobile", Mobile);
        //        cmd.Parameters.AddWithValue("@Gender", Gender);
        //        cmd.Parameters.AddWithValue("@State", State);
        //        cmd.Parameters.AddWithValue("@City", City);
        //        cmd.Parameters.AddWithValue("@Address", Address);
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
        //public bool InsertGuest()
        //{
        //    try
        //    {

        //        MakeConnection();
        //        //dataTable = new DataTable();
        //        cmd.CommandText = "Insert Into \"Actor\" (Firstname , Lastname , Birthday , NationalCode , Mobile , Gender ) Values(@Firstname , @Lastname , @Birthday , @NationalCode , @Mobile , @Gender )";
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@Firstname", Firstname);
        //        cmd.Parameters.AddWithValue("@Lastname ", Lastname);
        //        cmd.Parameters.AddWithValue("@Birthday", Birthday);
        //        cmd.Parameters.AddWithValue("@NationalCode", NationalCode);
        //        cmd.Parameters.AddWithValue("@Mobile", Mobile);
        //        cmd.Parameters.AddWithValue("@Gender", Gender);

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
    //public class DBActor
    //{
    //    //Actor act = new Actor();
    //    public static int ID { get; set; }
    //    public static string Firstname { get; set; }
    //    public static string Lastname { get; set; }
    //    public static string NationalCode { get; set; }
    //    public static string Mobile { get; set; }
    //    public static DateTime Birthday { get; set; }
    //    public static string Gender { get; set; }

    //    public static string Nationality { get; set; }

    //    public static string Email { get; set; }

    //    public static string Tel { get; set; }
    //    public static string State { get; set; }
    //    public static string City { get; set; }

    //    public static string Address { get; set; }

    //    private static SqlConnection con = new SqlConnection();
    //    private SqlCommand cmd = new SqlCommand();
    //    private SqlDataAdapter adp = new SqlDataAdapter();
    //    private DataTable dataTable = new DataTable();




    //    private void MakeConnection()
    //    {
    //        try
    //        {
    //            con.ConnectionString = "Data Source = (Local); Initial Catalog = Hotel; Integrated Security = True";
    //            cmd.Connection = con;

    //        }
    //        catch
    //        {

    //            ;
    //        }


    //    }

    //    private void Connect()
    //    {
    //        try
    //        {
    //            if (con.State == ConnectionState.Closed)
    //            {

    //                con.Open();

    //            }


    //        }
    //        catch
    //        {

    //            ;
    //        }

    //    }

    //    private void Disconnect()
    //    {
    //        try
    //        {
    //            if (con.State == ConnectionState.Open)
    //            {
    //                con.Close();

    //            }

    //        }
    //        catch
    //        {

    //            ;
    //        }
    //    }

    //    //public  bool Search()
    //    //{
    //    //    try
    //    //    {


    //    //        MakeConnection();
    //    //        dataTable = new DataTable();

    //    //        cmd.CommandText = "SELECT * FROM \"User\" Where Username = @Username ";
    //    //        cmd.Parameters.Clear();
    //    //        cmd.Parameters.AddWithValue("@Username", Username);


    //    //        adp.SelectCommand = cmd;

    //    //        Connect();
    //    //        adp.Fill(dataTable);
    //    //        Disconnect();

    //    //        if (dataTable.Rows.Count != 0)
    //    //        {
    //    //            ID = Convert.ToInt32(dataTable.Rows[0]["ID"]);
    //    //            Username = dataTable.Rows[0]["Username"].ToString();
    //    //            Password = dataTable.Rows[0]["Password"].ToString();
    //    //            Activate = Convert.ToBoolean(dataTable.Rows[0]["Activate"]);
    //    //            //Image = (byte[])dataTable.Rows[0]["Image"];


    //    //            return true;


    //    //        }
    //    //        else
    //    //        {
    //    //            return false;
    //    //        }




    //    //    }
    //    //    catch
    //    //    {

    //    //        return false;
    //    //    }











    //    //}

    //    public bool InsertAll()
    //    {
    //        try
    //        {

    //            MakeConnection();
    //            //dataTable = new DataTable();
    //            cmd.CommandText = "Insert Into \"Actor\" (Firstname , Lastname , Birthday , NationalCode , Nationality , Email , Tel , Mobile , Gender , State , City , Address) Values(@Firstname , @Lastname , @Birthday , @NationalCode , @Nationality , @Email , @Tel , @Mobile , @Gender , @State , @City , @Address)";
    //            cmd.Parameters.Clear();
    //            cmd.Parameters.AddWithValue("@Firstname", Firstname);
    //            cmd.Parameters.AddWithValue("@Lastname ", Lastname);
    //            cmd.Parameters.AddWithValue("@Birthday", Birthday);
    //            cmd.Parameters.AddWithValue("@NationalCode", NationalCode);
    //            cmd.Parameters.AddWithValue("@Nationality", Nationality);
    //            cmd.Parameters.AddWithValue("@Email", Email);
    //            cmd.Parameters.AddWithValue("@Tel", Tel);
    //            cmd.Parameters.AddWithValue("@Mobile", Mobile);
    //            cmd.Parameters.AddWithValue("@Gender", Gender);
    //            cmd.Parameters.AddWithValue("@State", State);
    //            cmd.Parameters.AddWithValue("@City", City);
    //            cmd.Parameters.AddWithValue("@Address", Address);
    //            // DateTime.Now.ToString("h:mm:ss tt")


    //            Connect();
    //            cmd.ExecuteNonQuery();
    //            Disconnect();

    //            return true;

    //        }
    //        catch
    //        {

    //            return false;
    //        }













    //    }
    //    public bool InsertGuest()
    //    {
    //        try
    //        {

    //            MakeConnection();
    //            //dataTable = new DataTable();
    //            cmd.CommandText = "Insert Into \"Actor\" (Firstname , Lastname , Birthday , NationalCode , Mobile , Gender ) Values(@Firstname , @Lastname , @Birthday , @NationalCode , @Mobile , @Gender )";
    //            cmd.Parameters.Clear();
    //            cmd.Parameters.AddWithValue("@Firstname", Firstname);
    //            cmd.Parameters.AddWithValue("@Lastname ", Lastname);
    //            cmd.Parameters.AddWithValue("@Birthday", Birthday);
    //            cmd.Parameters.AddWithValue("@NationalCode", NationalCode);
    //            cmd.Parameters.AddWithValue("@Mobile", Mobile);
    //            cmd.Parameters.AddWithValue("@Gender", Gender);

    //            // DateTime.Now.ToString("h:mm:ss tt")


    //            Connect();
    //            cmd.ExecuteNonQuery();
    //            Disconnect();

    //            return true;

    //        }
    //        catch
    //        {

    //            return false;
    //        }













    //    }



    //}
}
