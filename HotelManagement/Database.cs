using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace HotelManagement
{

    namespace HotelDatabase
    {
       
        public class Room
        {
            public static int ID { get; set; }
            public static int BranchID { get; set; }
            public static int RoomNumberID { get; set; }
            public static int TypeID { get; set; }
            public static bool IsEmpty { get; set; }
            public static List<int> facility { get; set; }
            public static int Floor { get; set; }
            public static int Capacity { get; set; }
            public static int Price { get; set; }
            public static string Description { get; set; }

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


            public static int Insert(int branchID, int roomNumberID , bool isEmpty , int floor , int capacity , int price , string description)
            {
                try
                {
                    MakeConnection();
                    cmd.CommandText = "Insert Into \"Room\" (BranchID , RoomNumberID , IsEmpty , Floor , Capacity , Price , Description) Values (@BranchID , @RoomNumberID , @IsEmpty , @Floor , @Capacity , @Price , @Description)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@BranchID", branchID);
                    cmd.Parameters.AddWithValue("@RoomNumberID", roomNumberID);
                    cmd.Parameters.AddWithValue("@IsEmpty", isEmpty);
                    cmd.Parameters.AddWithValue("@Floor", Database.CheckNullInsert(floor));
                    cmd.Parameters.AddWithValue("@Capacity", capacity);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Description", Database.CheckNullInsert(description));
     
                    Connect();
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = Database.QueryLastID;
                    int insertedID = Convert.ToInt32(cmd.ExecuteScalar());
                    Disconnect();
                    return insertedID;
                }
                catch
                {
                    return -1;
                }
            }
           
            public static bool Update(int id , int branchID, int roomNumberID, bool isEmpty, int floor, int capacity, int price, string description)
            {
                try
                {
                    MakeConnection();
                    cmd.CommandText = "Update \"Room\" Set BranchID = @BranchID , RoomNumberID = @RoomNumberID , IsEmpty = @IsEmpty , Floor = @Floor  , Capacity = @Capacity , Price = @Price , Description = @Description Where ID = @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@BranchID", branchID);
                    cmd.Parameters.AddWithValue("@RoomNumberID", roomNumberID);
                    cmd.Parameters.AddWithValue("@IsEmpty", isEmpty);
                    cmd.Parameters.AddWithValue("@Floor", Database.CheckNullInsert(floor));
                    cmd.Parameters.AddWithValue("@Capacity", capacity);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Description", Database.CheckNullInsert(description));
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
            //public static bool SearchRoom(int branchID, int roomNumberID)
            //{
            //    try
            //    {
            //        MakeConnection();
            //        dataTable = new DataTable();
            //        cmd.CommandText = "SELECT * FROM \"Room\" Where BranchID = @BranchID AND RoomNumberID = @RoomNumberID ";
            //        cmd.Parameters.Clear();
            //        cmd.Parameters.AddWithValue("@BranchID" , branchID);
            //        cmd.Parameters.AddWithValue("@RoomNumberID", roomNumberID);
            //        adp.SelectCommand = cmd;
            //        Connect();
            //        adp.Fill(dataTable);
            //        Disconnect();
            //        if (dataTable.Rows.Count != 0)
            //        {
            //            ID = Convert.ToInt32(dataTable.Rows[0]["ID"]);
            //            RoomNumberID = Convert.ToInt32(dataTable.Rows[0]["RoomNumberID"]);
            //            BranchID = Convert.ToInt32(dataTable.Rows[0]["BranchID"]);
            //            IsEmpty = Convert.ToBoolean(dataTable.Rows[0]["IsEmpty"]);
            //            Floor = Convert.ToInt32(dataTable.Rows[0]["Floor"]);
            //            Price  = Convert.ToInt32(dataTable.Rows[0]["Price"]);
            //            Capacity = Convert.ToInt32(dataTable.Rows[0]["Capacity"]);
            //            Description = Database.CheckNullSelect(dataTable.Rows[0]["Description"]) as string;
            //            //return dataTable;
            //            return true;
            //        }
            //        else
            //        {
            //            return false;
            //            //return null; 
            //        }
            //    }
            //    catch
            //    {
            //        return false;
            //        //return null;
            //    }
            //}
            public static bool Delete(int id)
            {
                try
                {
                    MakeConnection();
                    cmd.CommandText = "Delete From \"Room\" Where ID = @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", id);
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




            public static Dictionary<int,string> GetRoomNumbers()
            {
                try
                {
                    MakeConnection();
                    dataTable = new DataTable();                    
                    cmd.CommandText = "SELECT * FROM \"RoomNumber\" ";
                    cmd.Parameters.Clear();
                    //cmd.Parameters.AddWithValue("@BranchID", branchID);
                    //cmd.Parameters.AddWithValue("@RoomNumberID", roomNumberID);
                    adp.SelectCommand = cmd;
                    Connect();
                    adp.Fill(dataTable);
                    Disconnect();

                    if (dataTable.Rows.Count != 0)
                    {
                        Dictionary<int, string> list = new Dictionary<int, string>();
                        for (int i = 0; i <  dataTable.Rows.Count ; i++)
                        {
                            list.Add(Convert.ToInt32(dataTable.Rows[i]["ID"]), dataTable.Rows[i]["Title"].ToString());


                        }

                        //return dataTable;
                        return list;


                    }
                    else
                    {
                        return null;
                        //return null; 
                    }
                }
                catch
                {
                    return null ;
                    //return null;
                }
            }
            public static Dictionary<int, string> GetRoomTypes()
            {
                try
                {
                    MakeConnection();
                    dataTable = new DataTable();
                    cmd.CommandText = "SELECT * FROM \"RoomType\" ";
                    cmd.Parameters.Clear();
                    adp.SelectCommand = cmd;
                    Connect();
                    adp.Fill(dataTable);
                    Disconnect();

                    if (dataTable.Rows.Count != 0)
                    {
                        Dictionary<int, string> list = new Dictionary<int, string>();
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            list.Add(Convert.ToInt32(dataTable.Rows[i]["ID"]), dataTable.Rows[i]["Title"].ToString());
                        }
                        return list;
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
            public static Dictionary<int, string> GetFacilities()
            {
                try
                {
                    MakeConnection();
                    dataTable = new DataTable();
                    cmd.CommandText = "SELECT * FROM \"Facilities\" ";
                    cmd.Parameters.Clear();
                    adp.SelectCommand = cmd;
                    Connect();
                    adp.Fill(dataTable);
                    Disconnect();

                    if (dataTable.Rows.Count != 0)
                    {
                        Dictionary<int, string> list = new Dictionary<int, string>();
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            list.Add(Convert.ToInt32(dataTable.Rows[i]["ID"]), dataTable.Rows[i]["Title"].ToString());
                        }
                        return list;
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


            public static bool DeleteFacilType(int roomID)
            {
                try
                {
                    MakeConnection();
                    cmd.CommandText = "Delete From \"RoomFacilities\" Where RoomID = @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", roomID);
                    Connect();
                    cmd.ExecuteNonQuery();
                    Disconnect();
                    cmd.CommandText = "Delete From \"RoomTypeRel\" Where RoomID = @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", roomID);
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
            public static bool InsertFacilities(int roomID, int facilitiesID)
            {
                try
                {
                    MakeConnection();
                    cmd.CommandText = "Insert Into \"RoomFacilities\" (RoomID , FacilitiesID) Values (@RoomID , @FacilitiesID)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@RoomID", roomID);
                    cmd.Parameters.AddWithValue("@FacilitiesID", facilitiesID);
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
            public static bool InsertRoomType(int roomID, int typeID)
            {
                try
                {
                    MakeConnection();
                    cmd.CommandText = "Insert Into \"RoomTypeRel\" (RoomID , RoomTypeID) Values (@RoomID , @RoomTypeID)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@RoomID", roomID);
                    cmd.Parameters.AddWithValue("@RoomTypeID", typeID);
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


            public static bool SearchRoomWithID(int id)
            {
                try
                {
                    MakeConnection();
                    dataTable = new DataTable();
                    DataTable facil = new DataTable();
                    cmd.CommandText = "SELECT * FROM \"Room\" , RoomTypeRel Where ID = @ID AND ID = RoomID ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", id);
                    adp.SelectCommand = cmd;
                    Connect();
                    adp.Fill(dataTable);
                    cmd.CommandText = "Select * From RoomFacilities Where RoomID =" + id;
                    adp.SelectCommand = cmd;
                    adp.Fill(facil);
                    Disconnect();

                    if (dataTable.Rows.Count != 0)
                    {
                        ID = Convert.ToInt32(dataTable.Rows[0]["ID"]);
                        TypeID = Convert.ToInt32(dataTable.Rows[0]["RoomTypeID"]);
                        RoomNumberID = Convert.ToInt32(dataTable.Rows[0]["RoomNumberID"]);
                        BranchID = Convert.ToInt32(dataTable.Rows[0]["BranchID"]);
                        IsEmpty = Convert.ToBoolean(dataTable.Rows[0]["IsEmpty"]);
                        Floor = Convert.ToInt32(dataTable.Rows[0]["Floor"]);
                        Price = Convert.ToInt32(dataTable.Rows[0]["Price"]);
                        Capacity = Convert.ToInt32(dataTable.Rows[0]["Capacity"]);
                        Description = Database.CheckNullSelect(dataTable.Rows[0]["Description"]) as string;
                        if (facil != null)
                        {
                            List<int> lstID = new List<int>();
                            for (int i = 0; i < facil.Rows.Count; i++)
                            {
                                lstID.Add(Convert.ToInt32(facil.Rows[i]["FacilitiesID"]));
                            }
                            facility = lstID;
                        }
                        else
                        {
                            facility = null;
                        }
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

        }
        public class User
        {
            public static int ID { get; set; }
            public static int EmployeeID { get; set; }
            public static string Username { get; set; }
            public static string Password { get; set; }
            public static bool Activate { get; set; }
            public static byte[] Image { get; set; }
            public static int RoleID{ get; set; }

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

            public static bool SearchUser(string username)
            {
                try
                {
                    MakeConnection();
                    dataTable = new DataTable();
                    cmd.CommandText = "SELECT * FROM \"User\" Where Username = @Username ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Username", username);
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
                        Activate = Convert.ToBoolean(dataTable.Rows[0]["Activate"]);
                        Image = (byte[])dataTable.Rows[0]["Image"];
                        RoleID = Convert.ToInt32(dataTable.Rows[0]["RoleID"]);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    Disconnect();
                    return false;
                }
            }

            public static bool SearchUser( int employeeID)
            {
                try
                {
                    MakeConnection();
                    dataTable = new DataTable();
                    cmd.CommandText = "SELECT * FROM \"User\" Where  EmployeeID = @EmployeeID ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
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
                        Activate = Convert.ToBoolean(dataTable.Rows[0]["Activate"]);
                        Image = (byte[])dataTable.Rows[0]["Image"];
                        RoleID = Convert.ToInt32(dataTable.Rows[0]["RoleID"]);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    Disconnect();
                    return false;
                }
            }
            //public static int SearchUserID(string username)
            //{
            //    try
            //    {
            //        MakeConnection();
            //        dataTable = new DataTable();
            //        cmd.CommandText = "SELECT * FROM \"User\" Where Username = @Username ";
            //        cmd.Parameters.Clear();
            //        cmd.Parameters.AddWithValue("@Username", username);
            //        adp.SelectCommand = cmd;
            //        Connect();
            //        adp.Fill(dataTable);
            //        Disconnect();
            //        if (dataTable.Rows.Count != 0)
            //        {
            //            ID = Convert.ToInt32(dataTable.Rows[0]["ID"]);
            //            return ID;
            //        }
            //        else
            //        {
            //            return -1;
            //        
            //    }
            //    catch
            //    {
            //        Disconnect();
            //        return -2;
            //    }
            //}
            public static int Insert(int employeeID, int roleID, string username, string password, byte[] img, bool activate)
            {
                try
                {
                    MakeConnection();
                    cmd.CommandText = "Insert Into \"User\" (EmployeeID , RoleID , Username , Password , Image , Activate) Values (@EmployeeID  , @RoleID, @Username , @Password , @Image , @Activate)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@RoleID", roleID);
                    cmd.Parameters.AddWithValue("@Image", img);
                    cmd.Parameters.AddWithValue("@Activate", Database.CheckNullInsert(activate));

                    Connect();
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = Database.QueryLastID;
                    int insertedID = Convert.ToInt32(cmd.ExecuteScalar());
                    Disconnect();
                    return insertedID;
                }
                catch
                {
                    Disconnect();
                    return -1;
                }
            }
            public static bool Update( int id, int employeeID, int roleID, string username, byte[] img, bool activate)
            {
                try
                {
                    MakeConnection();
                    cmd.CommandText = "Update \"User\"  Set EmployeeID = @EmployeeID , RoleID = @RoleID  , Username = @Username   , Image = @Image  , Activate   = @Activate Where ID = @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                    cmd.Parameters.AddWithValue("@Username", username);                  
                    cmd.Parameters.AddWithValue("@RoleID", roleID);
                    cmd.Parameters.AddWithValue("@Image", img);
                    cmd.Parameters.AddWithValue("@Activate", Database.CheckNullInsert(activate));

                    Connect();
                    cmd.ExecuteNonQuery();
                    Disconnect();
                    return true;
                }
                catch
                {
                    Disconnect();
                    return false;
                }
            }
            public static bool UpdateWithPass(int id, int employeeID, int roleID, string username , string password, byte[] img, bool activate)
            {
                try
                {
                    MakeConnection();
                    cmd.CommandText = "Update \"User\"  Set EmployeeID = @EmployeeID , RoleID = @RoleID  , Username = @Username , Password = @Password  , Image = @Image  , Activate   = @Activate Where ID = @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@RoleID", roleID);
                    cmd.Parameters.AddWithValue("@Image", img);
                    cmd.Parameters.AddWithValue("@Activate", Database.CheckNullInsert(activate));

                    Connect();
                    cmd.ExecuteNonQuery();
                    Disconnect();
                    return true;

                }
                catch
                {
                    Disconnect();
                    return false;
                }
            }
            public static DateTime GetLastSignin(int id)
            {
                try
                {
                    MakeConnection();
                    dataTable = new DataTable();
                    cmd.CommandText = " SELECT DateTime " +
                    "FROM LoginHistory " +
                    "Where UserID = @UserID Order By DateTime DESC";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@UserID", id);
                    adp.SelectCommand = cmd;

                    Connect();
                    adp.Fill(dataTable);
                    Disconnect();
                    if (dataTable.Rows.Count != 0)
                    {
                        DateTime date = Convert.ToDateTime(dataTable.Rows[0]["DateTime"]);
                        return date;
                    }
                    else
                    {
                        return DateTime.MinValue;
                    }
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
            //public static bool InsertLoginHistory()
            //{
            //    try
            //    {
            //        MakeConnection();
            //        //dataTable = new DataTable();
            //        cmd.CommandText = "Insert Into \"LoginHistory\" (UserID , DateTime) Values(@UserID , @DateTime)";
            //        cmd.Parameters.Clear();
            //        cmd.Parameters.AddWithValue("@UserID", ID);
            //        cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
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
            public static bool Delete(int id)
            {
                try
                {
                    cmd.CommandText = "Delete FRom [User] Where ID = @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", id);

                    MakeConnection();
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

            public static ChatInfo.User SearchOnlineUser(string username)
            {
                try
                {
                    MakeConnection();
                    dataTable = new DataTable();
                    cmd.CommandText = "SELECT u.id as Uid , Image , a.Firstname +' '+ a.Lastname as Name , BranchName   " +
                        "  FROM [User] u , Employee e , Actor a , BranchInfo b  " +
                        " Where Username = @Username And u.EmployeeID = e.ID And e.BranchID = b.ID And e.ActID = a.ID ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Username", username);
                    adp.SelectCommand = cmd;
                    Connect();
                    adp.Fill(dataTable);
                    Disconnect();

                    if (dataTable.Rows.Count != 0)
                    {
                        ChatInfo.User user = new ChatInfo.User();
                        user.ID = Convert.ToInt32(dataTable.Rows[0]["Uid"]);
                        user.Name = dataTable.Rows[0]["Name"].ToString();
                        user.Username = username;
                        user.Branch = dataTable.Rows[0]["BranchName"].ToString();
                        user.Image = (byte[])dataTable.Rows[0]["Image"];
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    Disconnect();
                    return null;
                }
            }
        }
        public class Reservation
        {
            public static int ID { get; set; }
            public static int UserID { get; set; }
            public static int CustomerID { get; set; }
            public static int RoomID { get; set; }
            public static DateTime DateModified { get; set; }
            public static DateTime StartDate { get; set; }
            public static DateTime EndDate { get; set; }
            public static int TotalPayDueDate{ get; set; }
            public static DateTime CancelDate { get; set; }

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

            public static int Insert(int userID, int customerID, int roomID, DateTime startDate, DateTime endDate, int totalPayDueDate)
            {
                try
                {
                    MakeConnection();
                   
                    cmd.CommandText = "Insert Into \"Reservation\" (UserID , CustomerID , RoomID , StartDate , EndDate , TotalPayDueDate , DateModified) Values(@UserID , @CustomerID , @RoomID , @StartDate , @EndDate , @TotalPayDueDate , @DateModified)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    cmd.Parameters.AddWithValue("@RoomID", roomID);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    cmd.Parameters.AddWithValue("@TotalPayDueDate", totalPayDueDate);
                    cmd.Parameters.AddWithValue("@DateModified",DateTime.Now);

                    Connect();
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = Database.QueryLastID;
                    int insertedID = Convert.ToInt32(cmd.ExecuteScalar());
                    Disconnect();
                    return insertedID;

                }
                catch
                {
                    return -1;
                }
            }   
            //public static bool SearchReserve(int customerID , DateTime sDate )
            //{
            //    try
            //    {
            //        MakeConnection();
            //        dataTable = new DataTable();
            //        cmd.CommandText = "SELECT * FROM \"Reserve\" Where CustomerID = @CustomerID AND StartDate >= @sDate  ";
            //        cmd.Parameters.Clear();
            //        cmd.Parameters.AddWithValue("@CustomerID", customerID);
            //        cmd.Parameters.AddWithValue("@sDate", sDate);
            //        adp.SelectCommand = cmd;
            //        Connect();
            //        adp.Fill(dataTable);
            //        Disconnect();
            //        if (dataTable.Rows.Count != 0)
            //        {
            //            //ID = Convert.ToInt32(dataTable.Rows[0]["ID"]);
            //            //CustomerID = Convert.ToInt32(dataTable.Rows[0]["CustomerID"]);
            //            //UserID = Convert.ToInt32(dataTable.Rows[0]["UserID"]);
            //            //RoomID = dataTable.Rows[0]["NationalCode"].ToString();
            //            //Email = Database.CheckNullSelect(dataTable.Rows[0]["Email"]) as string;
            //            //Tel = Database.CheckNullSelect(dataTable.Rows[0]["Tel"]) as string;
            //            //State = Database.CheckNullSelect(dataTable.Rows[0]["State"]) as string;
            //            //City = Database.CheckNullSelect(dataTable.Rows[0]["City"]) as string;
            //            //Birthday = Database.CheckNullSelectDateTime(dataTable.Rows[0]["Birthday"]); //Min Value FOr Date Time Consider As Null
            //            //Address = Database.CheckNullSelect(dataTable.Rows[0]["Address"]) as string;
            //            //Gender = Database.CheckNullSelect(dataTable.Rows[0]["Gender"]) as string;
            //            //Nationality = Database.CheckNullSelect(dataTable.Rows[0]["Nationality"]) as string;
            //            //Mobile = Database.CheckNullSelect(dataTable.Rows[0]["Mobile"]) as string;
            //            ////Activate = Convert.ToBoolean(dataTable.Rows[0]["Activate"]);
            //            //Image = (byte[])dataTable.Rows[0]["Image"];
            //            return true;
            //        }
            //        else
            //        {
            //            return false;
            //        }
            //    }
            //    catch
            //    {
            //        return false;
            //    }
            //}
            public static bool SearchReserveWithID(int idd)
            {
                try
                {
                    MakeConnection();
                    dataTable = new DataTable();
                    cmd.CommandText = "SELECT * FROM \"Reservation\" Where ID = @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", idd);
                    adp.SelectCommand = cmd;

                    Connect();
                    adp.Fill(dataTable);
                    Disconnect();

                    if (dataTable.Rows.Count != 0)
                    {
                        ID = Convert.ToInt32(dataTable.Rows[0]["ID"]);
                        CustomerID = Convert.ToInt32(dataTable.Rows[0]["CustomerID"]);
                        UserID = Convert.ToInt32(dataTable.Rows[0]["UserID"]);
                        RoomID = Convert.ToInt32(dataTable.Rows[0]["RoomID"]);
                        CancelDate = Database.CheckNullSelectDateTime(dataTable.Rows[0]["CancelDate"]) ;
                        StartDate =Convert.ToDateTime(dataTable.Rows[0]["StartDate"]);
                        EndDate = Convert.ToDateTime(dataTable.Rows[0]["EndDate"]);
                        DateModified = Convert.ToDateTime(dataTable.Rows[0]["DateModified"]);
                        TotalPayDueDate = Convert.ToInt32(dataTable.Rows[0]["TotalPayDueDate"]); //Min Value FOr Date Time Consider As Null
                        //Address = Database.CheckNullSelect(dataTable.Rows[0]["Address"]) as string;
                        //Gender = Database.CheckNullSelect(dataTable.Rows[0]["Gender"]) as string;
                        //Nationality = Database.CheckNullSelect(dataTable.Rows[0]["Nationality"]) as string;
                        //Mobile = Database.CheckNullSelect(dataTable.Rows[0]["Mobile"]) as string;
                        //Activate = Convert.ToBoolean(dataTable.Rows[0]["Activate"]);
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
            public static bool Update(int id2 , DateTime Checkin , bool cancel)
            {
                try
                {
                    MakeConnection(); 
                    if (cancel)
                    {
                        cmd.CommandText = "Update \"Reservation\"  Set CancelDate = @Checkin ,  TotalPayDueDate=@TotalPay Where ID = @ParameterID";               
                    }
                    else
                    {      
                        cmd.CommandText = "Update \"Reservation\"  Set EndDate = @Checkin , TotalPayDueDate=@TotalPay Where ID = @ParameterID";                       
                    }
                    SearchReserveWithID(id2);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@TotalPay", TotalPayDueDate * 0.5);
                    cmd.Parameters.AddWithValue("@Checkin", Checkin);
                    cmd.Parameters.AddWithValue("@ParameterID", id2);
                    
                    //cmd.Parameters.AddWithValue("@RoomID", roomID);
                    //cmd.Parameters.AddWithValue("@StartDate", startDate);
                    //cmd.Parameters.AddWithValue("@EndDate", endDate);
                    //cmd.Parameters.AddWithValue("@TotalPayDueDate", totalPayDueDate);
                    //cmd.Parameters.AddWithValue("@DateModified", DateTime.Now);
                    //cmd.Parameters.AddWithValue("@Mobile", Database.CheckNullInsert(mobile));
                    //cmd.Parameters.AddWithValue("@Gender", gender);
                    //cmd.Parameters.AddWithValue("@State", Database.CheckNullInsert(Gender));
                    //cmd.Parameters.AddWithValue("@City", Database.CheckNullInsert(city));
                    //cmd.Parameters.AddWithValue("@Address", Database.CheckNullInsert(address));
                    // DateTime.Now.ToString("h:mm:ss tt")
                    Connect();
                    cmd.ExecuteNonQuery();
                    Disconnect();
                    return true;                
                }
                catch
                {
                    return false ;
                }
            }
            public static bool Update(int id, int totalPayDueDat, DateTime cancelDate)
            {
                try
                {
                    MakeConnection();
                    cmd.CommandText = "Update \"Reservation\"  Set CancelDate = @Checkin , TotalPayDueDate = @TotalPay  Where ID = @ParameterID";
                    //SearchReserveWithID(id);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@TotalPay", totalPayDueDat * 0.5);
                    cmd.Parameters.AddWithValue("@Checkin", cancelDate);
                    cmd.Parameters.AddWithValue("@ParameterID", id);
                    //cmd.Parameters.AddWithValue("@RoomID", roomID);
                    //cmd.Parameters.AddWithValue("@StartDate", startDate);
                    //cmd.Parameters.AddWithValue("@EndDate", endDate);
                    //cmd.Parameters.AddWithValue("@TotalPayDueDate", totalPayDueDate);
                    //cmd.Parameters.AddWithValue("@DateModified", DateTime.Now);
                    //cmd.Parameters.AddWithValue("@Mobile", Database.CheckNullInsert(mobile));
                    //cmd.Parameters.AddWithValue("@Gender", gender);
                    //cmd.Parameters.AddWithValue("@State", Database.CheckNullInsert(Gender));
                    //cmd.Parameters.AddWithValue("@City", Database.CheckNullInsert(city));
                    //cmd.Parameters.AddWithValue("@Address", Database.CheckNullInsert(address));
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
            public static bool Delete(int id)
            {
                try
                {
                    cmd.CommandText = "Delete FROM \"Reservation\" Where ID = @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", id);

                    MakeConnection();
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
            //public static bool Update(int id, DateTime CancelDate)
            //{
            //    try
            //    {
            //        MakeConnection();
            //        cmd.CommandText = "Update \"Reservation\"  Set StartDate = @Checkin Where ID = @ID";
            //        cmd.Parameters.Clear();
            //        cmd.Parameters.AddWithValue("@ID", id);
            //        cmd.Parameters.AddWithValue("@Checkin", Checkin);
            //        //cmd.Parameters.AddWithValue("@RoomID", roomID);
            //        //cmd.Parameters.AddWithValue("@StartDate", startDate);
            //        //cmd.Parameters.AddWithValue("@EndDate", endDate);
            //        //cmd.Parameters.AddWithValue("@TotalPayDueDate", totalPayDueDate);
            //        //cmd.Parameters.AddWithValue("@DateModified", DateTime.Now);
            //        //cmd.Parameters.AddWithValue("@Mobile", Database.CheckNullInsert(mobile));
            //        //cmd.Parameters.AddWithValue("@Gender", gender);
            //        //cmd.Parameters.AddWithValue("@State", Database.CheckNullInsert(Gender));
            //        //cmd.Parameters.AddWithValue("@City", Database.CheckNullInsert(city));
            //        //cmd.Parameters.AddWithValue("@Address", Database.CheckNullInsert(address));
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

            //public static int SearchActorID(string nationalCode)
            //{
            //    try
            //    {
            //        MakeConnection();
            //        dataTable = new DataTable();
            //        cmd.CommandText = "SELECT * FROM \"Actor\" Where NationalCode = @NationalCode ";
            //        cmd.Parameters.Clear();
            //        cmd.Parameters.AddWithValue("@NationalCode", nationalCode);
            //        adp.SelectCommand = cmd;
            //        Connect();
            //        adp.Fill(dataTable);
            //        Disconnect();
            //        if (dataTable.Rows.Count != 0)
            //        {
            //            ID = Convert.ToInt32(dataTable.Rows[0]["ID"]);
            //            //Activate = Convert.ToBoolean(dataTable.Rows[0]["Activate"]);
            //            //Image = (byte[])dataTable.Rows[0]["Image"];
            //            return ID;
            //        }
            //        else
            //        {
            //            return -1;
            //        }
            //    }
            //    catch
            //    {
            //        return -2;
            //    }
            //}
        }
        public class Bill
        {
            public static int ID { get; set; }
            public static int ResID { get; set; }
            public static int TransactionID { get; set; }
            public static string BillNo { get; set; }
            public static int RoomCharge { get; set; }
            public static int FoodCharge { get; set; }
            public static int ServiceCharge { get; set; }
            public static int TotalCharge { get; set; }
            public static double Discount { get; set; }
            public static DateTime DateModified { get; set; }
            public static string Description { get; set; }

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

            //public static int Insert(int resID , int transID , string billNo , int roomCharge , int foodCharge , int serviceCharge  , int totalCharge , double discount , string description)
            //{
            //    try
            //    {
            //        MakeConnection();
            //        cmd.CommandText = "Insert Into \"Bill\" (ResID , TransactionID , BillNo , RoomCharge , FoodCharge , ServiceCharge  , TotalCharge , Discount , DateModified , Description) Values (@ResID , @TransactionID , @BillNo , @RoomCharge , @FoodCharge , @ServiceCharge , @TotalCharge , @Discount , @DateModified , @Description)";
            //        cmd.Parameters.Clear();
            //        cmd.Parameters.AddWithValue("@ResID", resID);
            //        cmd.Parameters.AddWithValue("@TransactionID", transID);
            //        cmd.Parameters.AddWithValue("@BillNo", billNo);
            //        cmd.Parameters.AddWithValue("@RoomCharge", roomCharge);
            //        cmd.Parameters.AddWithValue("@FoodCharge", foodCharge);
            //        cmd.Parameters.AddWithValue("@ServiceCharge", serviceCharge);
            //        cmd.Parameters.AddWithValue("@TotalCharge", totalCharge);
            //        cmd.Parameters.AddWithValue("@Discount", discount);
            //        cmd.Parameters.AddWithValue("@DateModified", DateTime.Now);
            //        cmd.Parameters.AddWithValue("@Description", Database.CheckNullInsert(description));                
            //        Connect();
            //        cmd.ExecuteNonQuery();
            //        cmd.CommandText = Database.QueryLastID;
            //        int insertedID = Convert.ToInt32(cmd.ExecuteScalar());
            //        Disconnect();
            //        return insertedID;
            //    }
            //    catch
            //    {
            //        return -1;
            //    }
            //}
            public static int Insert(int resID)
            {
                try
                {
                    MakeConnection();
                    cmd.CommandText = "Insert Into \"Bill\" (ResID ,DateModified ) Values (@ResID , @DateModified)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ResID", resID);
                    //cmd.Parameters.AddWithValue("@TransactionID", transID);
                    //cmd.Parameters.AddWithValue("@BillNo", billNo);
                    //cmd.Parameters.AddWithValue("@RoomCharge", roomCharge);
                    //cmd.Parameters.AddWithValue("@FoodCharge", foodCharge);
                    //cmd.Parameters.AddWithValue("@ServiceCharge", serviceCharge);
                    //cmd.Parameters.AddWithValue("@TotalCharge", totalCharge);
                    //cmd.Parameters.AddWithValue("@Discount", discount);
                    cmd.Parameters.AddWithValue("@DateModified", DateTime.Now);
                    //cmd.Parameters.AddWithValue("@Description", Database.CheckNullInsert(description));
                    Connect();
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = Database.QueryLastID;
                    int insertedID = Convert.ToInt32(cmd.ExecuteScalar());
                    Disconnect();
                    return insertedID;
                }
                catch
                {
                    return -1;
                }
            }
            public static bool Update(int id  ,int? transactionID  )
            {
                try
                {                 
                    cmd.CommandText = "Update \"Bill\"  SET TransactionID =  @TransactionID  Where ID = @ID";
                    cmd.Parameters.Clear();
                    //cmd.Parameters.AddWithValue("@AccountID", accountID);
                    //cmd.Parameters.AddWithValue("@PaymentMethodID", paymentMethodID);
                    cmd.Parameters.AddWithValue("@ID", id);
                    if (transactionID == null)
                    {
                        cmd.Parameters.AddWithValue("@TransactionID", DBNull.Value );
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@TransactionID", transactionID);
                    }

                    //cmd.Parameters.AddWithValue("@TransactionNumber", Database.CheckNullInsert(transNum));
                    //cmd.Parameters.AddWithValue("@Amount", amount);
                    ////cmd.Parameters.AddWithValue("@DateModified", serviceCharge);
                    //////cmd.Parameters.AddWithValue("@To", totalCharge);
                    //if (discount > -1) cmd.Parameters.AddWithValue("@Discount", discount);
                    ////cmd.Parameters.AddWithValue("@Discount", discount);
                    ////cmd.Parameters.AddWithValue("@DateModified", DateTime.Now);
                    //if(description!=null || description!="") cmd.Parameters.AddWithValue("@Description", Database.CheckNullInsert(description));
                    MakeConnection();
                    Connect();
                    cmd.ExecuteNonQuery();
                    //cmd.CommandText = Database.QueryLastID;
                    //int insertedID = Convert.ToInt32(cmd.ExecuteScalar());
                    Disconnect();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            public static bool Update(int id, double discount, string description)
            {
                try
                {
                    cmd.CommandText = "Update \"Bill\"  SET  Discount = @Discount , Description = @Description  Where ID = @ID";
                    cmd.Parameters.Clear();
                    //cmd.Parameters.AddWithValue("@AccountID", accountID);
                    //cmd.Parameters.AddWithValue("@PaymentMethodID", paymentMethodID);
                    cmd.Parameters.AddWithValue("@ID", id);
                    //if (transactionID == null)
                    //{
                    //    cmd.Parameters.AddWithValue("@TransactionID", DBNull.Value);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@TransactionID", transactionID);
                    //}
                    //cmd.Parameters.AddWithValue("@TransactionNumber", Database.CheckNullInsert(transNum));
                    //cmd.Parameters.AddWithValue("@Amount", amount);
                    ////cmd.Parameters.AddWithValue("@DateModified", serviceCharge);
                    ////cmd.Parameters.AddWithValue("@To", totalCharge);
                    /*if (discount > -1)*/ cmd.Parameters.AddWithValue("@Discount", discount);
                    //cmd.Parameters.AddWithValue("@Discount", discount);
                    //cmd.Parameters.AddWithValue("@DateModified", DateTime.Now);
                   /* i/*f (description != null || description != "")*/ cmd.Parameters.AddWithValue("@Description", Database.CheckNullInsert(description));
                    MakeConnection();
                    Connect();
                    cmd.ExecuteNonQuery();
                    //cmd.CommandText = Database.QueryLastID;
                    //int insertedID = Convert.ToInt32(cmd.ExecuteScalar());
                    Disconnect();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
            public static bool SearchBill(int resID)
            {
                try
                {
                    MakeConnection();
                    dataTable = new DataTable();
                    cmd.CommandText = "SELECT * FROM \"Bill\" Where ResID = @ResID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ResID", resID);
                    adp.SelectCommand = cmd;
                    Connect();
                    adp.Fill(dataTable);
                    Disconnect();

                    if (dataTable.Rows.Count != 0)
                    {
                        ID = Convert.ToInt32(dataTable.Rows[0]["ID"]);
                        if (dataTable.Rows[0]["TransactionID"] != DBNull.Value)
                        {
                            TransactionID = Convert.ToInt32(dataTable.Rows[0]["TransactionID"]);
                        }
                        else
                        {
                            TransactionID = 0;
                        }
                        
                        BillNo = Database.CheckNullSelect(dataTable.Rows[0]["BillNo"]) as string;
                        RoomCharge = Convert.ToInt32(dataTable.Rows[0]["RoomCharge"]) ;
                        FoodCharge = Convert.ToInt32(dataTable.Rows[0]["FoodCharge"]) ;
                        ServiceCharge = Convert.ToInt32(dataTable.Rows[0]["ServiceCharge"]) ;
                        TotalCharge = Convert.ToInt32(dataTable.Rows[0]["TotalCharge"]);
                        Discount = Convert.ToDouble(dataTable.Rows[0]["Discount"]);
                        DateModified = Convert.ToDateTime(dataTable.Rows[0]["DateModified"]);
                        Description = Database.CheckNullSelect(dataTable.Rows[0]["Description"]) as string;
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
            //public static int SearchBranchID(string code)
            //{
            //    try
            //    {
            //        MakeConnection();
            //        dataTable = new DataTable();
            //        cmd.CommandText = "SELECT * FROM \"BranchInfo\" Where Code = @Code";
            //        cmd.Parameters.Clear();
            //        cmd.Parameters.AddWithValue("@Code", code);
            //        adp.SelectCommand = cmd;
            //        Connect();
            //        adp.Fill(dataTable);
            //        Disconnect();
            //        if (dataTable.Rows.Count != 0)
            //        {
            //            ID = Convert.ToInt32(dataTable.Rows[0]["ID"]);
            //            return ID;
            //        }
            //        else
            //        {
            //            return -1;
            //        }
            //    }
            //    catch
            //    {
            //        return -2;
            //    }
            //}
        }
        public class Transact
        {
            public static int ID { get; set; }
            public static int AccountID { get; set; }
            public static int PaymentMethodID { get; set; }
            public static int TransactionTypeID { get; set; }
            public static string TransactionNumber { get; set; }
            public static double Amount { get; set; }
            //public static int FoodCharge { get; set; }
            //public static int ServiceCharge { get; set; }
            //public static int TotalCharge { get; set; }
            //public static double Discount { get; set; }
            public static DateTime DateModified { get; set; }
            public static string Description { get; set; }

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

            public static int Insert(int accountID, int paymentMethodID, int transTypeID, string transNum, double amount , string description)
            {
                try
                {
                    MakeConnection();
                    cmd.CommandText = "Insert Into \"Transact\" (AccountID , PaymentMethodID , TransactionTypeID , TransactionNumber , Amount, DateModified , Description) Values (@AccountID , @PaymentMethodID , @TransactionTypeID , @TransactionNumber , @Amount, @DateModified , @Description)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@AccountID", accountID);
                    cmd.Parameters.AddWithValue("@PaymentMethodID", paymentMethodID);
                    cmd.Parameters.AddWithValue("@TransactionTypeID", transTypeID);
                    cmd.Parameters.AddWithValue("@TransactionNumber", Database.CheckNullInsert(transNum));
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    //cmd.Parameters.AddWithValue("@DateModified", serviceCharge);
                    //cmd.Parameters.AddWithValue("@To", totalCharge);
                    //cmd.Parameters.AddWithValue("@Discount", discount);
                    cmd.Parameters.AddWithValue("@DateModified", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Description", Database.CheckNullInsert(description));
                    Connect();
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = Database.QueryLastID;
                    int insertedID = Convert.ToInt32(cmd.ExecuteScalar());
                    Disconnect();
                    return insertedID;
                }
                catch
                {
                    return -1;
                }
            }

            public static bool Update(int id , int accountID, int paymentMethodID, int transTypeID, string transNum, double amount, string description)
            {
                try
                {
                    MakeConnection();

                    cmd.CommandText = "Update \"Transact\" Set AccountID = @AccountID , PaymentMethodID = @PaymentMethodID , TransactionTypeID = @TransactionTypeID , TransactionNumber =  @TransactionNumber , Amount = @Amount , DateModified = @DateModified , Description = @Description Where ID = @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@AccountID", accountID);
                    cmd.Parameters.AddWithValue("@PaymentMethodID", paymentMethodID);
                    cmd.Parameters.AddWithValue("@TransactionTypeID", transTypeID);
                    cmd.Parameters.AddWithValue("@TransactionNumber", Database.CheckNullInsert(transNum));
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@DateModified", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Description", Database.CheckNullInsert(description));

                    Connect();
                    cmd.ExecuteNonQuery();
                    Disconnect();
                    return true ;
                }
                catch
                {
                    return false ;
                }
            }

            public static bool SearchTransact(int id)
            {
                try
                {
                    MakeConnection();
                    dataTable = new DataTable();
                    cmd.CommandText = "SELECT * FROM \"Transact\" Where ID = @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID",id);
                    adp.SelectCommand = cmd;
                    Connect();
                    adp.Fill(dataTable);
                    Disconnect();
                    if (dataTable.Rows.Count != 0)
                    {
                        AccountID = Convert.ToInt32(dataTable.Rows[0]["AccountID"]) ;
                        PaymentMethodID = Convert.ToInt32(dataTable.Rows[0]["PaymentMethodID"]);
                        TransactionTypeID = Convert.ToInt32(dataTable.Rows[0]["TransactionTypeID"]);
                        TransactionNumber = Database.CheckNullSelect(dataTable.Rows[0]["TransactionNumber"]) as string;
                        Amount = Convert.ToDouble(dataTable.Rows[0]["Amount"]);
                        //Discount = Convert.ToDouble(dataTable.Rows[0][" Discount"]);
                        DateModified = Convert.ToDateTime(dataTable.Rows[0]["DateModified"]);
                        Description = Database.CheckNullSelect(dataTable.Rows[0]["Description"]) as string;
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
            public static Dictionary<int , string> GetPaymentMethod()
            {
                try
                {
                    MakeConnection();
                    dataTable = new DataTable();
                    cmd.CommandText = "SELECT * FROM \"PaymentMethod\"";
                    cmd.Parameters.Clear();
                    //cmd.Parameters.AddWithValue("@ID", ID);
                    adp.SelectCommand = cmd;
                    Connect();
                    adp.Fill(dataTable);
                    Disconnect();

                    if (dataTable.Rows.Count != 0)
                    {
                        Dictionary<int, string> lstPay = new Dictionary<int, string>();

                        //if (dataTable.Rows[0]["TransactionID"] != DBNull.Value)
                        //{
                        //    TransactionID = Convert.ToInt32(dataTable.Rows[0]["TransactionID"]);
                        //}
                        //else
                        //{
                        //    TransactionID = 0;
                        //}
                        //AccountID = Convert.ToInt32(dataTable.Rows[0]["AccountID"]);
                        //PaymentMethodID = Convert.ToInt32(dataTable.Rows[0]["PaymentMethodID"]);
                        //TransactionTypeID = Convert.ToInt32(dataTable.Rows[0]["TransactionTypeID"]);
                        //TransactionNumber = Database.CheckNullSelect(dataTable.Rows[0]["TransactionNumber"]) as string;
                        //Amount = Convert.ToDouble(dataTable.Rows[0]["Amount"]);
                        ////Discount = Convert.ToDouble(dataTable.Rows[0][" Discount"]);
                        //DateModified = Convert.ToDateTime(dataTable.Rows[0]["DateModified"]);
                        //Description = Database.CheckNullSelect(dataTable.Rows[0]["Description"]) as string;

                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            int id = Convert.ToInt32(dataTable.Rows[i]["ID"]);
                            string Title = dataTable.Rows[i]["Title"].ToString();
                            lstPay.Add(id, Title);

                        }
                        return lstPay ;
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
            public static Dictionary<int, string> GetTransactionType()
            {
                try
                {
                    MakeConnection();
                    dataTable = new DataTable();
                    cmd.CommandText = "SELECT * FROM \"TransactionType\"";
                    cmd.Parameters.Clear();
                    //cmd.Parameters.AddWithValue("@ID", ID);
                    adp.SelectCommand = cmd;
                    Connect();
                    adp.Fill(dataTable);
                    Disconnect();
                    if (dataTable.Rows.Count != 0)
                    {
                        Dictionary<int, string> lstTransType = new Dictionary<int, string>();
                        //if (dataTable.Rows[0]["TransactionID"] != DBNull.Value)
                        //{
                        //    TransactionID = Convert.ToInt32(dataTable.Rows[0]["TransactionID"]);
                        //}
                        //else
                        //{
                        //    TransactionID = 0;
                        //}
                        //AccountID = Convert.ToInt32(dataTable.Rows[0]["AccountID"]);
                        //PaymentMethodID = Convert.ToInt32(dataTable.Rows[0]["PaymentMethodID"]);
                        //TransactionTypeID = Convert.ToInt32(dataTable.Rows[0]["TransactionTypeID"]);
                        //TransactionNumber = Database.CheckNullSelect(dataTable.Rows[0]["TransactionNumber"]) as string;
                        //Amount = Convert.ToDouble(dataTable.Rows[0]["Amount"]);
                        ////Discount = Convert.ToDouble(dataTable.Rows[0][" Discount"]);
                        //DateModified = Convert.ToDateTime(dataTable.Rows[0]["DateModified"]);
                        //Description = Database.CheckNullSelect(dataTable.Rows[0]["Description"]) as string;
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            int id = Convert.ToInt32(dataTable.Rows[i]["ID"]);
                            string Title = dataTable.Rows[i]["Title"].ToString();
                            lstTransType.Add(id, Title);
                        }
                        return lstTransType;
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
            public static bool Delete(int id)
            {
                try
                {
                    dataTable = new DataTable();

                    cmd.CommandText = "Delete FROM \"Transact\" Where ID = @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", id);
                    MakeConnection();
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
            //public static Dictionary<int , List<string>> A(int ID)
            //public static int SearchBranchID(string code)
            //{
            //    try
            //    {
            //        MakeConnection();
            //        dataTable = new DataTable();
            //        cmd.CommandText = "SELECT * FROM \"BranchInfo\" Where Code = @Code";
            //        cmd.Parameters.Clear();
            //        cmd.Parameters.AddWithValue("@Code", code);
            //        adp.SelectCommand = cmd;
            //        Connect();
            //        adp.Fill(dataTable);
            //        Disconnect();
            //        if (dataTable.Rows.Count != 0)
            //        {
            //            ID = Convert.ToInt32(dataTable.Rows[0]["ID"]);
            //            return ID;
            //        }
            //        else
            //        {
            //            return -1;
            //        }
            //    }
            //    catch
            //    {
            //        return -2;
            //    }
            //}
        }
        public class Account
        {
            public static int ID { get; set; }
            public static int BranchID { get; set; }
            public static string Bank { get; set; }
            public static double Balance { get; set; }
            public static string AccountName { get; set; }
            public static string AccountNumber{ get; set; }
            //public static double Amount { get; set; }
            //public static int FoodCharge { get; set; }
            //public static int ServiceCharge { get; set; }
            //public static int TotalCharge { get; set; }
            //public static double Discount { get; set; }
            //public static DateTime DateModified { get; set; }
            public static string Description { get; set; }

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

            public static int Insert(int branchID , string accountName , string accountNumber , string bank , double balance , string description )
            {
                try
                {
                    MakeConnection();
                    cmd.CommandText = "Insert Into \"Accounts\" (BranchID , AccountName , AccountNumber , Bank , Balance ,   Description) Values (@BranchID , @AccountName , @AccountNumber , @Bank , @Balance , @Description)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@BranchID", branchID);
                    cmd.Parameters.AddWithValue("@AccountName", accountName);
                    cmd.Parameters.AddWithValue("@Bank", bank);
                    cmd.Parameters.AddWithValue("@Balance", balance);
                    cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);
                    //cmd.Parameters.AddWithValue("@DateModified", serviceCharge);
                    //cmd.Parameters.AddWithValue("@To", totalCharge);
                    //cmd.Parameters.AddWithValue("@Discount", discount);
                    //cmd.Parameters.AddWithValue("@DateModified", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Description", Database.CheckNullInsert(description));
                    Connect();
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = Database.QueryLastID;
                    int insertedID = Convert.ToInt32(cmd.ExecuteScalar());
                    Disconnect();
                    return insertedID;
                }
                catch
                {
                    return -1;
                }
            }
            public static bool Update(int id , string accountName, string accountNumber, string bank, double balance, string description)
            {
                try
                {
                    MakeConnection();
                    cmd.CommandText = "Update \"Accounts\" SET    AccountName = @AccountName , AccountNumber = @AccountNumber , Bank  = @Bank  , Balance = @Balance  ,   Description = @Description  Where ID=@ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("ID", id);
                    //cmd.Parameters.AddWithValue("@BranchID", branchID);
                    cmd.Parameters.AddWithValue("@AccountName", accountName);
                    cmd.Parameters.AddWithValue("@Bank", bank);
                    cmd.Parameters.AddWithValue("@Balance", balance);
                    cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);
                    //cmd.Parameters.AddWithValue("@DateModified", serviceCharge);
                    //cmd.Parameters.AddWithValue("@To", totalCharge);
                    //cmd.Parameters.AddWithValue("@Discount", discount);
                    //cmd.Parameters.AddWithValue("@DateModified", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Description", Database.CheckNullInsert(description));
                    Connect();
                    cmd.ExecuteNonQuery();
                    Disconnect();
                    return true;
                }
                catch
                {
                    return false ;
                }
            }
            public static bool SearchAccount(int ID)
            {
                try
                {
                    MakeConnection();
                    dataTable = new DataTable();
                    cmd.CommandText = "SELECT * FROM \"Accounts\" Where ID = @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", ID);
                    adp.SelectCommand = cmd;
                    Connect();
                    adp.Fill(dataTable);
                    Disconnect();
                    if (dataTable.Rows.Count != 0)
                    {
                        ID = Convert.ToInt32(dataTable.Rows[0]["ID"]);        
                        BranchID = Convert.ToInt32(dataTable.Rows[0]["BranchID"]);
                        AccountName = dataTable.Rows[0]["AccountName"].ToString();
                        AccountNumber = dataTable.Rows[0]["AccountNumber"].ToString();
                        Bank = dataTable.Rows[0]["Bank"].ToString();                  
                        Balance = Convert.ToDouble(dataTable.Rows[0]["Balance"]);
                        Description = Database.CheckNullSelect(dataTable.Rows[0]["Description"]) as string;
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
            public static bool Delete (int id)
            {
                try
                {       
                    dataTable = new DataTable();
                    cmd.CommandText = "Delete FROM \"Accounts\" Where ID = @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", id);
                    MakeConnection();
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
            //public static int SearchBranchID(string code)
            //{
            //    try
            //    {
            //        MakeConnection();
            //        dataTable = new DataTable();
            //        cmd.CommandText = "SELECT * FROM \"BranchInfo\" Where Code = @Code";
            //        cmd.Parameters.Clear();
            //        cmd.Parameters.AddWithValue("@Code", code)
            //        adp.SelectCommand = cmd;
            //        Connect();
            //        adp.Fill(dataTable);
            //        Disconnect();
            //        if (dataTable.Rows.Count != 0)
            //        {
            //            ID = Convert.ToInt32(dataTable.Rows[0]["ID"]);
            //            return ID;
            //        }
            //        else
            //        {
            //            return -1;
            //        }
            //    }
            //    catch
            //    {
            //        return -2;
            //    }
            //}
            public static Dictionary<int, string> GetAccountList(int branchID)
            {
                try
                {
                    MakeConnection();
                    dataTable = new DataTable();
                    cmd.CommandText = "SELECT * FROM \"Accounts\" Where BranchID = @BranchID ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@BranchID", branchID);
                    adp.SelectCommand = cmd;
                    Connect();
                    adp.Fill(dataTable);
                    Disconnect();
                    if (dataTable.Rows.Count != 0)
                    {
                        Dictionary<int, string> lstAccount = new Dictionary<int,string>();
                        //List<string> lstSecond = new List<string>();
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            ID = Convert.ToInt32(dataTable.Rows[i]["ID"]);
                            AccountName = dataTable.Rows[i]["AccountName"].ToString();
                            AccountNumber = dataTable.Rows[i]["AccountNumber"].ToString();
                            Bank = dataTable.Rows[i]["Bank"].ToString();
                            //Balance = Convert.ToDouble(dataTable.Rows[i]["Balance"])
                            string str = Bank + " - " + AccountName + " - " + AccountNumber;
                            lstAccount.Add(ID, str);
                        }
                        return lstAccount;
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
        public class Food
        {
            public static int ID { get; set; }
            public static string Title { get; set; }
            public static int Price { get; set; }
            public static string Description { get; set; }
            //public static double Amount { get; set; }
            //public static int FoodCharge { get; set; }
            //public static int ServiceCharge { get; set; }
            //public static int TotalCharge { get; set; }
            //public static double Discount { get; set; }
            //public static DateTime DateModified { get; set; }
            //public static string Description { get; set; }

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
            public static int Insert(string title , int price , string description)
            {
                try
                {
                    MakeConnection();
                    cmd.CommandText = "Insert Into \"Food\" (Title , Price , Description ) Values (@Title ,@Price , @Description)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Price", price);                 
                    cmd.Parameters.AddWithValue("@Description", Database.CheckNullInsert(description));

                    Connect();
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = Database.QueryLastID;
                    int insertedID = Convert.ToInt32(cmd.ExecuteScalar());
                    Disconnect();
                    return insertedID;
                }
                catch
                {
                    return -1;
                }
            }
            public static bool Update(int id , string title, int price, string description)
            {
                try
                {
                    MakeConnection();
                    cmd.CommandText = "Update \"Food\" Set Title = @Title , Price = @Price , Description = @Description Where ID=@ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Description", Database.CheckNullInsert(description));

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
            public static bool SearchFood(int id)
            {
                try
                {
                    MakeConnection();
                    dataTable = new DataTable();
                    cmd.CommandText = "SELECT * FROM \"Food\" Where ID = @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", id);
                    adp.SelectCommand = cmd;

                    Connect();
                    adp.Fill(dataTable);
                    Disconnect();

                    if (dataTable.Rows.Count != 0)
                    {
                        //ID = Convert.ToInt32(dataTable.Rows[0]["ID"]);
                        //if (dataTable.Rows[0]["TransactionID"] != DBNull.Value)
                        //{
                        //    TransactionID = Convert.ToInt32(dataTable.Rows[0]["TransactionID"]);
                        //}
                        //else
                        //{
                        //    TransactionID = 0;
                        //}
                        Price = Convert.ToInt32(dataTable.Rows[0]["Price"]);
                        //PaymentMethodID = Convert.ToInt32(dataTable.Rows[0]["PaymentMethodID"]);
                        //TransactionTypeID = Convert.ToInt32(dataTable.Rows[0]["TransactionTypeID"]);
                        Title = Database.CheckNullSelect(dataTable.Rows[0]["Title"]) as string;
                        //Amount = Convert.ToDouble(dataTable.Rows[0]["Amount"]);
                        ////Discount = Convert.ToDouble(dataTable.Rows[0][" Discount"]);
                        //DateModified = Convert.ToDateTime(dataTable.Rows[0]["DateModified"]);
                        Description = Database.CheckNullSelect(dataTable.Rows[0]["Description"]) as string;
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
            public static bool Delete(int id)
            {
                try
                {
                    dataTable = new DataTable();
                    cmd.CommandText = "Delete FROM \"Food\" Where ID = @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", id);
                    MakeConnection();
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
            public static int InsertOrderFood(int foodID , int resID , int count , int Total )
            {
                try
                {
                    MakeConnection();
                    cmd.CommandText = "Insert Into \"OrderFood\" (FoodID , ResID , Count , Total , DateModified ) Values (@FoodID , @ResID , @Count , @Total , @DateModified )";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@FoodID", foodID);
                    cmd.Parameters.AddWithValue("@ResID", resID);
                    cmd.Parameters.AddWithValue("@Count", count);
                    cmd.Parameters.AddWithValue("@Total", Total);
                    cmd.Parameters.AddWithValue("@DateModified", DateTime.Now);
                    Connect();
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = Database.QueryLastID;
                    int insertedID = Convert.ToInt32(cmd.ExecuteScalar());
                    Disconnect();
                    return insertedID;
                }
                catch
                {
                    return -1;
                }
            }
            public static bool DeleteOrderFood(int id)
            {
                try
                {
                    dataTable = new DataTable();
                    cmd.CommandText = "Delete FROM \"OrderFood\" Where ID = @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", id);
                    MakeConnection();
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
        }
        public class Service
        {
            public static int ID { get; set; }
            public static string Title { get; set; }
            public static int Price { get; set; }
            public static string Description { get; set; }

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

            public static int Insert(string title, int price, string description)
            {
                try
                {
                    MakeConnection();
                    cmd.CommandText = "Insert Into \"Service\" (Title , Price , Description ) Values (@Title ,@Price , @Description)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Description", Database.CheckNullInsert(description));
                    Connect();
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = Database.QueryLastID;
                    int insertedID = Convert.ToInt32(cmd.ExecuteScalar());
                    Disconnect();
                    return insertedID;
                }
                catch
                {
                    return -1;
                }
            }
            public static bool Update(int id, string title, int price, string description)
            {
                try
                {
                    MakeConnection();
                    cmd.CommandText = "Update \"Service\" Set Title = @Title , Price = @Price , Description = @Description Where ID=@ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Description", Database.CheckNullInsert(description));
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
            public static bool SearchService(int id)
            {
                try
                {
                    MakeConnection();
                    dataTable = new DataTable();
                    cmd.CommandText = "SELECT * FROM \"Service\" Where ID = @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", id);
                    adp.SelectCommand = cmd;
                    Connect();
                    adp.Fill(dataTable);
                    Disconnect();
                    if (dataTable.Rows.Count != 0)
                    {
                        //ID = Convert.ToInt32(dataTable.Rows[0]["ID"]);
                        //if (dataTable.Rows[0]["TransactionID"] != DBNull.Value)
                        //{
                        //    TransactionID = Convert.ToInt32(dataTable.Rows[0]["TransactionID"]);
                        //}
                        //else
                        //{
                        //    TransactionID = 0;
                        //}
                        Price = Convert.ToInt32(dataTable.Rows[0]["Price"]);
                        //PaymentMethodID = Convert.ToInt32(dataTable.Rows[0]["PaymentMethodID"]);
                        //TransactionTypeID = Convert.ToInt32(dataTable.Rows[0]["TransactionTypeID"]);
                        Title = Database.CheckNullSelect(dataTable.Rows[0]["Title"]) as string;
                        //Amount = Convert.ToDouble(dataTable.Rows[0]["Amount"]);
                        ////Discount = Convert.ToDouble(dataTable.Rows[0][" Discount"]);
                        //DateModified = Convert.ToDateTime(dataTable.Rows[0]["DateModified"]);
                        Description = Database.CheckNullSelect(dataTable.Rows[0]["Description"]) as string;
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
            public static bool Delete(int id)
            {
                try
                {
                    dataTable = new DataTable();
                    cmd.CommandText = "Delete FROM \"Service\" Where ID = @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", id);
                    MakeConnection();
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
            public static int InsertOrderService(int serviceID, int resID, int count, int total)
            {
                try
                {
                    MakeConnection();
                    cmd.CommandText = "Insert Into \"OrderService\" (ServiceID , ResID , Count , Total , DateModified ) Values (@ServiceID  , @ResID , @Count , @Total , @DateModified )";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ServiceID ", serviceID);
                    cmd.Parameters.AddWithValue("@ResID", resID);
                    cmd.Parameters.AddWithValue("@Count", count);
                    cmd.Parameters.AddWithValue("@Total", total);
                    cmd.Parameters.AddWithValue("@DateModified", DateTime.Now);

                    Connect();
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = Database.QueryLastID;
                    int insertedID = Convert.ToInt32(cmd.ExecuteScalar());
                    Disconnect();
                    return insertedID;
                }
                catch
                {
                    return -1;
                }
            }
            public static bool DeleteOrderService(int id)
            {
                try
                {
                    dataTable = new DataTable();
                    cmd.CommandText = "Delete FROM \"OrderService\" Where ID = @ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", id);
                    MakeConnection();
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
        }
        public class Database
        {
            //--Query To Get LastID After Insert
            public static string QueryLastID = "Select @@Identity";

            //---Mehtods----
            public static object CheckNullInsert(object obj)
            {

                if (obj == null || obj == "")
                {
                    return DBNull.Value;
                }
                else
                {
                    return obj;
                }
            }
            public static object CheckNullInsertDateTime(DateTime obj)
            {
                if (obj == DateTime.MinValue)
                {

                    return DBNull.Value;
                }
                else
                {
                    return obj;
                }
            }

            public static object CheckNullSelect(object obj)
            {

                if (obj == DBNull.Value)
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }
            public static DateTime CheckNullSelectDateTime(object obj)
            {

                if (obj == DBNull.Value)
                {
                    return DateTime.MinValue;
                }
                else
                {
                    return Convert.ToDateTime(obj);
                }
            }

            //--Queries---
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
      
            public static DataTable Query(string query)
            {
                try
                {
                    MakeConnection();
                    dataTable = new DataTable();
                    cmd.CommandText = query;
                    adp.SelectCommand = cmd;
                    Connect();
                    adp.Fill(dataTable);
                    Disconnect();
                    if (dataTable.Rows.Count != 0)
                    {
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
