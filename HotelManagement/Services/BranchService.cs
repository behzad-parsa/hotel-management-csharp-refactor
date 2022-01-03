using HotelManagement.DatabaseConfig;
using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HotelManagement.Services
{
    public class BranchService
    {
        public int LastInsertedId { get; set; }

        private readonly DatabaseOperation _database;
        private string sqlQuery;
        private Dictionary<string, object> parameters;

        public BranchService()
        {
            _database = new DatabaseOperation();
        }

        public bool InsertBranch(Branch branch)
        {
            parameters = new Dictionary<string, object>();
            parameters.Clear();

            sqlQuery = "INSERT INTO \"BranchInfo\" " +
                "(Code , Owner , BranchName , Rate , Logo , Tel , State , City , Address) " +
                "VALUES " +
                "(@Code , @Owner , @BranchName , @Rate , @Logo , @Tel , @State , @City , @Address) ";


            foreach (var property in typeof(Branch).GetProperties())
            {
                  parameters.Add("@" + property.Name, property.GetValue(branch, null));
            }

            LastInsertedId = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Insert, parameters);

            return (LastInsertedId != DatabaseResult.Failed);
        }

        public List<Branch> GetAllBranches()
        {
            
            sqlQuery = "SELECT * FROM \"BranchInfo\" ";

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select );

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;
            
            return Mapper.ConvertDataTableToList<Branch>(dataTable);
        }

        public Branch GetBranch(int id)
        {
            parameters = new Dictionary<string, object>();
            sqlQuery = "SELECT * FROM \"BranchInfo\" " +
                "WHERE " +
                "ID = @ID";
            parameters.Add("@ID", id);

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertRowToObj<Branch>(dataTable.Rows[0]);
        }

    


    }
}
