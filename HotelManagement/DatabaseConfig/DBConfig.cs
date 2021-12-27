using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DatabaseConfig
{
    public class DBConfig
    {
        private static SqlCommand cmd = new SqlCommand();
        private static SqlConnection con = new SqlConnection();

        public static SqlCommand MakeConnection()
        {
            try
            {
                con.ConnectionString = "Data Source = (Local); Initial Catalog = Hotel; Integrated Security = True";
                cmd.Connection = con;
                return cmd;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Conncet()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Disconnect()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
