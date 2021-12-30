using HotelManagement.DatabaseConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models;


namespace HotelManagement.Services
{
    public class CustomerService
    {

        public int LastInsertedId { get; set; }

        private readonly DatabaseOperation _database;
        private string sqlQuery;
        private Dictionary<string, object> parameters;

        public CustomerService()
        {
            _database = new DatabaseOperation();
        }

        public bool InsertCustomer(Customer customer)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "INSERT INTO \"Customer\" " +
                "(ActID) VALUES " +
                "(@ActID)";

            parameters.Add("@ActID", customer.ActID);

            LastInsertedId = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Insert, parameters);

            return (LastInsertedId != DatabaseResult.Failed);
        }

        public Customer GetCustomer(int actID)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "SELECT * FROM \"Customer\" " +
                "WHERE " +
                "ActID = @ActID";

            parameters.Add("@ActID", actID);

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertRowToObj<Customer>(dataTable.Rows[0]);
        }   
        public Customer GetCustomer(int actID , string optional = null)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "SELECT  a.ID AS ActID , c.ID AS ID , a.* " +
                "FROM \"Actor\" AS a  ,\"Customer\" AS c "+
                "wHERE  c.ActID = a.ID AND a.ID = @ActID";

            parameters.Add("@ActID", actID);

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertRowToObj<Customer>(dataTable.Rows[0]);
        }




    }
}
