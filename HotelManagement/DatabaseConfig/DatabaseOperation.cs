using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DatabaseConfig
{
    public class DatabaseOperation
    {
        private SqlCommand sqlCommand;

        public DatabaseOperation()
        {
            sqlCommand = DBConfig.MakeConnection();
        }

        public enum OperationType{
            Insert ,
            Update , 
            Delete ,
            Select,
            Procedure
        }

        //Getting Sql Query With Their Parameters From Service Classes , Then Apply To Database 
        public int InsertUpdateDelete(string sql, OperationType operationType, Dictionary<string, object> parameters)
        {
            
            sqlCommand.CommandText = sql;

           //CommandType Checking For Procedure 
            if (operationType != OperationType.Procedure) 
                sqlCommand.CommandType = System.Data.CommandType.Text;
            else 
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            sqlCommand.Parameters.Clear();
            foreach (KeyValuePair<string, object> parameter in parameters)
                sqlCommand.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));

            try
            {
                DBConfig.Conncet();
                sqlCommand.ExecuteNonQuery();
                
                if (operationType == OperationType.Insert) //Ater Insert We Need To Id of Inserted Row
                { 
                    sqlCommand.CommandText = "Select @@Identity";
                    return Convert.ToInt32(sqlCommand.ExecuteScalar());
                }

                return DatabaseResult.Successful;
            }
            catch (Exception)
            {
                //Todo : Log Exception 
                //throw;
                return DatabaseResult.Failed;
            }
            finally
            {
                DBConfig.Disconnect();
            }
        }

        
        public DataTable Select (string sql, OperationType operationType, Dictionary<string, object> parameters = null)
        {
            sqlCommand.CommandText = sql;

            //CommandType Checking For Procedure 
            if (operationType != OperationType.Procedure)
                sqlCommand.CommandType = System.Data.CommandType.Text;
            else
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            if (parameters != null)
                sqlCommand.Parameters.Clear();
                foreach (KeyValuePair<string,object> parameter in parameters)
                    sqlCommand.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));


            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            try
            {
                DBConfig.Conncet();
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception)
            {
                //Todo : Log Exception 
                //throw;
                return null;
            }
            finally
            {
                DBConfig.Disconnect();
            }
        }
    }
}
