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

        public class Database
        {


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
