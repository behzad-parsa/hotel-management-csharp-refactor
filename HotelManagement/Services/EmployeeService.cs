using HotelManagement.DatabaseConfig;
using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Services
{
    public class EmployeeService
    {
        public int LastInsertedId { get; set; }

        private readonly DatabaseOperation _database;
        private string sqlQuery;
        private Dictionary<string, object> parameters;

        public EmployeeService()
        {
            _database = new DatabaseOperation();
        }

        public bool InsertEmployee(Employee employee)
        {
            parameters = new Dictionary<string, object>();
            parameters.Clear();

            sqlQuery = "INSERT INTO \"Employee\" " +
                "(ActID , BranchID , Education , HireDate , Salary) " +
                "VALUES " +
                "(@ActID , @BranchID  , @Education, @HireDate , @Salary)";



            foreach (var property in typeof(Employee).GetProperties())
            {
                parameters.Add("@" + property.Name, property.GetValue(employee, null));
            }

            LastInsertedId = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Insert, parameters);

            return (LastInsertedId != DatabaseResult.Failed);
        }

        public Employee GetEmployee(int actID)
        {
            parameters = new Dictionary<string, object>();
            sqlQuery = "SELECT * FROM \"Employee\" " +
                "WHERE " +
                "ActID = @ActID";
            parameters.Add("@ActID", actID);

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertRowToObj<Employee>(dataTable.Rows[0]);
        } 
        public Employee GetEmployee(int actID , int branchID)
        {
            parameters = new Dictionary<string, object>();
            sqlQuery = "SELECT * FROM \"Employee\" " +
                "WHERE ActID = @ActID " +
                "AND BranchID = @BranchID ";

            parameters.Add("@ActID", actID);
            parameters.Add("@BranchID", branchID);

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertRowToObj<Employee>(dataTable.Rows[0]);
        }
        public bool UpdateEmployee(Employee employee)
        {
            if (employee.ID == 0)
                return false;
            parameters = new Dictionary<string,object>();
            sqlQuery = "Update \"Employee\"  " +
                "SET " +
                "ActID = @ActID, BranchID = @BranchID, Education = @Education, HireDate = @HireDate, Salary = @Salary " +
                "WHERE ID = @ID";

            foreach (var property in typeof(Employee).GetProperties())
            {
                parameters.Add("@" + property.Name, property.GetValue(employee, null));
            }

            return _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Update, parameters) != DatabaseResult.Failed;
        }
        public bool DeleteEmployee(int id)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "DELETE FROM \"Employee\" " +
                "Where " +
                "ID = @ID";
            parameters.Add("@ID" ,id);
  
            var result = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Delete, parameters);

            return (result != DatabaseResult.Failed);
        }

    }
}
