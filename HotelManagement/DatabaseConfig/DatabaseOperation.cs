using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DatabaseConfig
{
    class DatabaseOperation
    {
        private SqlCommand cmd;

        //Getting Sql Query With Their Parameter From Service Classes Then Apply To Database 
        public bool InsertUpdateDelete(string sql, Dictionary<string, object> parameters, bool isProcedure)
        {
            //Initialzing Database
            cmd = DBConfig.MakeConnection();
            cmd.CommandText = sql;

           //CommandType Checking For Procedure 
            if (!isProcedure) cmd.CommandType = System.Data.CommandType.Text;
            else cmd.CommandType = System.Data.CommandType.StoredProcedure;

            
            foreach (KeyValuePair<string, object> parameter in parameters)
                cmd.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));

            try
            {
                DBConfig.Conncet();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                //throw;
                return false;
            }
            finally
            {
                DBConfig.Disconnect();
            }
        }

        //Select Method Implemention Here
    }
}
