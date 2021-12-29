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

        private static readonly SqlCommand sqlCommand = new SqlCommand();
        private static readonly SqlConnection sqlConnection = new SqlConnection();

        public static SqlCommand MakeConnection()
        {
            try
            {
                sqlConnection.ConnectionString = "Data Source = (Local); Initial Catalog = Hotel; Integrated Security = True";
                sqlCommand.Connection = sqlConnection;
                return sqlCommand;
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
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
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
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
