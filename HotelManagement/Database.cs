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
