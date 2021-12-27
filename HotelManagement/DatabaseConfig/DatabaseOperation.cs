using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DatabaseConfig
{
    public class DatabaseOperation
    {
        private SqlCommand cmd;
        public enum OperationType{
            Insert ,
            Update , 
            Delete 

        }
        //Getting Sql Query With Their Parameter From Service Classes Then Apply To Database 
        public int InsertUpdateDelete(string sql, Dictionary<string, object> parameters, bool isProcedure , OperationType operationType)
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
                
                if (operationType == OperationType.Insert) //Ater Insert We Need To Id of Inserted Row
                { 
                    cmd.CommandText = "Select @@Identity";
                    return Convert.ToInt32(cmd.ExecuteScalar());

                }
                return 1;
            }
            catch (Exception)
            {
                //throw;
                return -1;
            }
            finally
            {
                DBConfig.Disconnect();
            }
        }

        //Select Method Implemention Here
    }
}
