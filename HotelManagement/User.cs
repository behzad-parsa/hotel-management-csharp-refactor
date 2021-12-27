using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using HotelManagement.HotelDatabase;

namespace HotelManagement
{

    namespace Current
    {
        public class User
        {
            
            //-----  User Information  ------
            public static int ID { get; private set; }
            public static int EmployeeID { get; set; }
            public static int RoleID { get; set; }
            public static string RoleTitle { get; set; }
            public static string Username { get; set; }
            public static string Password { get; set; }
            public static bool Activate { get; set; }
            public static byte[] Image { get; set; }

            //-----  Employee Inormation  ------
            
            public static int BranchID { get; set; }
            public static int ActID { get; set; }
            public static string Education { get; set; }
            public static DateTime HireDate { get; set; }
            public static int Salary { get; set; }
            
            //-------- Branch Info  --------------
        

            //------- Personal Info -----------------

            public static string Firstname { get; set; }
            public static string Lastname { get; set; }
            public static string Email { get; set; }
            public static string Mobile { get; set; }
            public static DateTime Birth { get; set; }
            public static string Gender { get; set; }
            public static string NationalCode { get; set; }
            public static Branch Branch { get; set; }
            public static List<string> AccessLevel { get; set; }
            public static List<Activity> Activities { get; set; }


            private static SqlConnection con = new SqlConnection();
            private static SqlCommand cmd = new SqlCommand();
            private static SqlDataAdapter adp = new SqlDataAdapter();
            private static DataTable dataTable = new DataTable();



            private static void MakeConnection()
            {
                try
                {
                    con.ConnectionString = "Data Source = (Local); Initial Catalog = Hotel; Integrated Security = True";
                    cmd.Connection = con;

                }
                catch
                {

                    ;
                }


            }
            private static void Connect()
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {

                        con.Open();

                    }


                }
                catch
                {

                    ;
                }

            }
            private static void Disconnect()
            {
                try
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();

                    }

                }
                catch
                {

                    ;
                }
            }
            public static bool SearchUserEmail(string email)
            {
                try
                {


                    MakeConnection();
                    dataTable = new DataTable();

                    cmd.CommandText = "SELECT * FROM \"User\" u , Employee e , Actor a  " +
                        "Where u.EmployeeID = e.id And e.ActID = a.id And Email = @Email  ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Email", email);


                    adp.SelectCommand = cmd;

                    Connect();
                    adp.Fill(dataTable);
                    Disconnect();

                    if (dataTable.Rows.Count != 0)
                    {
                        ID = Convert.ToInt32(dataTable.Rows[0]["ID"]);
                        EmployeeID = Convert.ToInt32(dataTable.Rows[0]["EmployeeID"]);
                        Username = dataTable.Rows[0]["Username"].ToString();
                        Password = dataTable.Rows[0]["Password"].ToString();
                        RoleID = Convert.ToInt32(dataTable.Rows[0]["RoleID"]);
                        Activate = Convert.ToBoolean(dataTable.Rows[0]["Activate"]);
                        //Image = (byte[])dataTable.Rows[0]["Image"];


                        return true;


                    }
                    else
                    {
                        return false;
                    }




                }
                catch
                {

                    return false;
                }











            }
            public static bool SearchUser(string username)
            {
                try
                {


                    MakeConnection();
                    dataTable = new DataTable();

                    //cmd.CommandText = "SELECT * "+
                    //   " FROM [User] u , Actor a, Employee e , Role r"+
                    //    "Where Username = '@Username' And u.EmployeeID = e.ID And e.ActID = a.ID And u.RoleID = r.id";
                    cmd.CommandText = "SELECT *  FROM [User] u , Actor a, Employee e , Role r " +
                             " Where Username = '"+username +"' And u.EmployeeID = e.ID And e.ActID = a.ID And u.RoleID = r.id";
                    //cmd.Parameters.Clear();
                    //cmd.Parameters.AddWithValue("@Username", username);


                    adp.SelectCommand = cmd;

                    Connect();
                    adp.Fill(dataTable);
                    Disconnect();

                    if (dataTable.Rows.Count != 0)
                    {
                        ID = Convert.ToInt32(dataTable.Rows[0]["ID"]);
                        EmployeeID = Convert.ToInt32(dataTable.Rows[0]["EmployeeID"]);
                        Username = dataTable.Rows[0]["Username"].ToString();
                        Password = dataTable.Rows[0]["Password"].ToString();
                        RoleID = Convert.ToInt32(dataTable.Rows[0]["RoleID"]);
                        Activate = Convert.ToBoolean(dataTable.Rows[0]["Activate"]);
                        Image = (byte[])dataTable.Rows[0]["Image"];
                        BranchID = Convert.ToInt32(dataTable.Rows[0]["BranchID"]);
                        ActID = Convert.ToInt32(dataTable.Rows[0]["ActID"]);
                        Education = dataTable.Rows[0]["Education"].ToString();
                        HireDate = Convert.ToDateTime(dataTable.Rows[0]["HireDate"]).Date;
                        Salary = Convert.ToInt32(dataTable.Rows[0]["Salary"]);
                        Firstname = dataTable.Rows[0]["Firstname"].ToString();
                        Lastname = dataTable.Rows[0]["Lastname"].ToString();
                        RoleTitle = dataTable.Rows[0]["Title"].ToString();
                        Gender = dataTable.Rows[0]["Gender"].ToString();
                        Birth = Convert.ToDateTime(dataTable.Rows[0]["Birthday"]).Date;
                        Mobile = dataTable.Rows[0]["Mobile"].ToString();
                        NationalCode = dataTable.Rows[0]["NationalCode"].ToString();
                        Email = dataTable.Rows[0]["Email"].ToString();


                        //Branch Part
                        if (HotelDatabase.Branch.SearchBranchWithID(BranchID))
                        {
                            string code = HotelDatabase.Branch.Code;
                            string branchName = HotelDatabase.Branch.BranchName;
                            string owner = HotelDatabase.Branch.Owner;
                            string rate = HotelDatabase.Branch.Rate;
                            string tel = HotelDatabase.Branch.Tel;
                            string state = HotelDatabase.Branch.State;
                            string city = HotelDatabase.Branch.City;
                            byte[] logo = HotelDatabase.Branch.Logo;
                            string address = HotelDatabase.Branch.Address;
                            //BranchName = dataTable.Rows[0]["BranchName"].ToString();
                            Branch = new Branch(BranchID, code, owner, branchName, rate, logo, tel, state, city, address);

                        }

                        //AccessLevel

                        AccessLevel =  HotelDatabase.Module.SearchModule(RoleID);

                        Activities = new List<Activity>();
                        //Random rnd = new Random();
                        //AccessLevel.RemoveAt(rnd.Next(0, 7));
                
                        return true;


                    }
                    else
                    {
                        return false;
                    }




                }
                catch
                {

                    return false;
                }











            }         
            public static bool UpdatePassword(string pass)
            {
                try
                {

                    MakeConnection();
                    //dataTable = new DataTable();
                    cmd.CommandText = "Update \"User\" SET Password = @Password Where ID = @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Password", pass);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    // DateTime.Now.ToString("h:mm:ss tt")


                    Connect();
                    cmd.ExecuteNonQuery();
                    Disconnect();

                    return true;

                }
                catch
                {

                    return false;
                }


            }
            public static bool UpdateUsername(string username)
            {
                try
                {

                    MakeConnection();
                    //dataTable = new DataTable();
                    cmd.CommandText = "Update \"User\" SET Username = @Username Where ID = @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    // DateTime.Now.ToString("h:mm:ss tt")


                    Connect();
                    cmd.ExecuteNonQuery();
                    Disconnect();

                    return true;

                }
                catch
                {

                    return false;
                }


            }
            public static bool UpdateProfilePicture(byte[] image)
            {
                try
                {

                    MakeConnection();
                    //dataTable = new DataTable();
                    cmd.CommandText = "Update \"User\" SET Image = @Image Where ID = @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Image", image);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    // DateTime.Now.ToString("h:mm:ss tt")


                    Connect();
                    cmd.ExecuteNonQuery();
                    Disconnect();

                    return true;

                }
                catch
                {

                    return false;
                }


            }
            public static bool InsertLoginHistory()
            {
                try
                {
                    
                    MakeConnection();
                    //dataTable = new DataTable();
                    cmd.CommandText = "Insert Into \"LoginHistory\" (UserID , DateTime) Values(@UserID , @DateTime)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@UserID", ID);
                    cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
                   // DateTime.Now.ToString("h:mm:ss tt")


                    Connect();
                    cmd.ExecuteNonQuery();
                    Disconnect();

                    return true;

                }
                catch
                {

                    return false;
                }













            }

            public static DataTable GetLoginHistory()
            {
                try
                {


                    MakeConnection();
                    dataTable = new DataTable();

                    cmd.CommandText = " SELECT TOP 6 ROW_NUMBER() OVER(order by Id DESC) as # , DateTime "+
                    "FROM LoginHistory "+
                    "Where UserID = @UserID Order By ID DESC";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@UserID", ID);


                    adp.SelectCommand = cmd;

                    Connect();
                    adp.Fill(dataTable);
                    Disconnect();

                    if (dataTable.Rows.Count != 0)
                    {
                        //ID = Convert.ToInt32(dataTable.Rows[0]["ID"]);
                        //EmployeeID = Convert.ToInt32(dataTable.Rows[0]["EmployeeID"]);
                        //Username = dataTable.Rows[0]["Username"].ToString();
                        //Password = dataTable.Rows[0]["Password"].ToString();
                        //RoleID = Convert.ToInt32(dataTable.Rows[0]["RoleID"]);
                        //Activate = Convert.ToBoolean(dataTable.Rows[0]["Activate"]);
                        //Image = (byte[])dataTable.Rows[0]["Image"];


                        return dataTable;


                    }
                    else
                    {
                        return null;
                    }




                }
                catch
                {

                    return null;
                }











            }





        }
    }

 
 
}
