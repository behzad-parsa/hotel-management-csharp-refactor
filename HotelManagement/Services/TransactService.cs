using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models;
using HotelManagement.Services;
using HotelManagement.DatabaseConfig;

namespace HotelManagement.Services
{
    public class TransactService
    {
        public int LastInsertedId { get; private set; }

        private readonly DatabaseOperation _database;
        private string sqlQuery;
        private Dictionary<string, object> parameters;

        public TransactService()
        {
            _database = new DatabaseOperation();
        }

        //Operations Which Related to the Transact
        public bool InsertTransact(Transact transact)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "INSERT INTO \"Transact\" " +
                "(AccountID , PaymentMethodID , TransactionTypeID , TransactionNumber , Amount, DateModified , Description) " +
                "VALUES " +
                "(@AccountID , @PaymentMethodID , @TransactionTypeID , @TransactionNumber , @Amount, @DateModified , @Description)";

            foreach (var property in typeof(Transact).GetProperties())
            {
                parameters.Add("@" + property.Name, property.GetValue(transact, null));
            }

            LastInsertedId = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Insert, parameters);

            return (LastInsertedId != DatabaseResult.Failed);
        }
        public bool UpdateTransact(Transact transact)
        {
            if (transact.ID == 0) //means the id is not set and we can't update
                return false;

            parameters = new Dictionary<string, object>();

            sqlQuery = "UPDATE \"Transact\" " +
                "SET " +
                "AccountID = @AccountID, PaymentMethodID = @PaymentMethodID, TransactionTypeID = @TransactionTypeID, " +
                "TransactionNumber = @TransactionNumber, Amount = @Amount, DateModified = @DateModified, Description = @Description " +
                "WHERE ID = @ID";

            object tempObject;
            foreach (var property in typeof(Transact).GetProperties())
            {
                if (property.GetValue(transact, null) is null)
                    tempObject = DBNull.Value;

                else
                    tempObject = property.GetValue(transact, null);
                parameters.Add("@" + property.Name, tempObject);
            }

            return _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Update, parameters) != DatabaseResult.Failed;
        }
        public bool DeleteTransact(int id)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "DELETE FROM \"Transact\" " +
                "WHERE ID = @ID";
            parameters.Add("@ID", id);

            var result = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Delete, parameters);

            return (result != DatabaseResult.Failed);
        }
        public Transact GetTransact(int id)
        {
            parameters = new Dictionary<string, object>();
            sqlQuery = "SELECT * FROM \"Transact\" WHERE ID = @ID";

            parameters.Add("@ID", id);

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertRowToObj<Transact>(dataTable.Rows[0]);
        }

        //Getting All Rows Related To Transact Features 
        public List<PaymentMethod> GetAllPaymentMethods()
        {

            sqlQuery = "SELECT * FROM \"PaymentMethod\" ";

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertDataTableToList<PaymentMethod>(dataTable);
        }
        public List<TransactionType> GetAllTransactionTypes()
        {

            sqlQuery = "SELECT * FROM \"TransactionType\" ";

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertDataTableToList<TransactionType>(dataTable);
        }
    }
}
