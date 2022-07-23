using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DatabaseConfig;
using HotelManagement.Models;

namespace HotelManagement.Services
{
    public class AccountService
    {
        public int LastInsertedId { get; private set; }

        private readonly DatabaseOperation _database;
        private string sqlQuery;
        private Dictionary<string, object> parameters;

        public AccountService()
        {
            _database = new DatabaseOperation();
        }

        public bool InsertAccount(Account account)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "INSERT INTO \"Accounts\" " +
                "(BranchID, AccountName, AccountNumber, Bank, Balance, Description) " +
                "VALUES " +
                "(@BranchID, @AccountName, @AccountNumber, @Bank, @Balance, @Description)";



            foreach (var property in typeof(Account).GetProperties())
            {
                parameters.Add("@" + property.Name, property.GetValue(account, null));
            }

            LastInsertedId = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Insert, parameters);

            return (LastInsertedId != DatabaseResult.Failed);
        }
        public bool UpdateAccount(Account Account)
        {
            if (Account.ID == 0) 
                return false;

            parameters = new Dictionary<string, object>();

            sqlQuery = "UPDATE \"Accounts\" SET   " +
                "AccountName = @AccountName, AccountNumber = @AccountNumber, Bank = @Bank, " +
                "Balance = @Balance, Description = @Description  " +
                "WHERE ID=@ID";

            object tempObject;
            foreach (var property in typeof(Account).GetProperties())
            {
                if (property.GetValue(Account, null) is null)
                    tempObject = DBNull.Value;

                else
                    tempObject = property.GetValue(Account, null);
                parameters.Add("@" + property.Name, tempObject);
            }

            return _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Update, parameters) != DatabaseResult.Failed;

        }
        public bool DeleteAccount(int id)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "DELETE FROM \"Accounts\" " +
                "WHERE " +
                "ID = @ID";
            parameters.Add("@ID", id);

            var result = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Delete, parameters);

            return (result != DatabaseResult.Failed);
        }
        public Account GetAccount(int id)
        {
            parameters = new Dictionary<string, object>();
            sqlQuery = "SELECT * FROM \"Accounts\" " +
                "WHERE " +
                "ID = @ID";
            parameters.Add("@ID", id);

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertRowToObj<Account>(dataTable.Rows[0]);
        }
        public List<Account> GetAllBranchAccounts(int branchId)
        {
            parameters = new Dictionary<string, object>();
            sqlQuery = "SELECT * FROM \"Accounts\" " +
                "WHERE " +
                "BranchID = @BranchID ";
            parameters.Add("@BranchID", branchId);

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertDataTableToList<Account>(dataTable);
        }

    }
}
