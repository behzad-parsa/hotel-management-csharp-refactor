using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Services;
using HotelManagement.Models;
using HotelManagement.DatabaseConfig;

namespace HotelManagement.Services
{
    public class BillService
    {
        public int LastInsertedId { get; private set; }

        private readonly DatabaseOperation _database;
        private string sqlQuery;
        private Dictionary<string, object> parameters;

        public BillService()
        {
            _database = new DatabaseOperation();
        }

        public bool InsertBill(Bill bill)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "INSERT INTO \"Bill\" " +
                "(ResID ,DateModified ) " +
                "VALUES " +
                "(@ResID , @DateModified)";

            foreach (var property in typeof(Bill).GetProperties())
            {
                parameters.Add("@" + property.Name, property.GetValue(bill, null));
            }

            LastInsertedId = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Insert, parameters);

            return (LastInsertedId != DatabaseResult.Failed);
        }
        //public Bill GetBill(int resID)
        //{
        //    parameters = new Dictionary<string, object>();
        //    sqlQuery = "SELECT * FROM \"Bill\" Where ResID = @ResID";

        //    parameters.Add("@ResID", resID);

        //    var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

        //    if (dataTable == null || dataTable.Rows.Count == 0)
        //        return null;

        //    return Mapper.ConvertRowToObj<Bill>(dataTable.Rows[0]);
        //}
        //public Bill GetBill(int id)
        //{
        //    parameters = new Dictionary<string, object>();
        //    sqlQuery = "SELECT * FROM \"Bill\" Where ID = @ID";

        //    parameters.Add("@ID", id);

        //    var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

        //    if (dataTable == null || dataTable.Rows.Count == 0)
        //        return null;

        //    return Mapper.ConvertRowToObj<Bill>(dataTable.Rows[0]);
        //}
        public Bill GetBill(int? id , int? resID)
        {
            parameters = new Dictionary<string, object>();
            sqlQuery = "SELECT * FROM \"Bill\" Where ID = @ID OR ResID = @ResID";

            if(id != null)
                parameters.Add("@ID", id);
            if(resID != null)
                parameters.Add("@ResID", resID);

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertRowToObj<Bill>(dataTable.Rows[0]);
        }
        //public Bill GetBill(int id , SearchKind searchKind)
        //{
        //    parameters = new Dictionary<string, object>();
        //    if (searchKind = SearchKind.ID)
        //        sqlQuery = "SELECT * FROM \"Bill\" Where ID = @ID";





        //    parameters.Add("@ID", id);

        //    var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

        //    if (dataTable == null || dataTable.Rows.Count == 0)
        //        return null;

        //    return Mapper.ConvertRowToObj<Bill>(dataTable.Rows[0]);
        //}
        public bool UpdateBill(Bill bill)
        {
            if (bill.ID == 0) //means the id is not set and we can't update
                return false;

            parameters = new Dictionary<string, object>();

            sqlQuery = "UPDATE \"Bill\"  " +
                "SET  Discount = @Discount, Description = @Description, TransactionID = @TransactionID   " +
                "WHERE " +
                "ID = @ID";


            object tempObject;
            foreach (var property in typeof(Bill).GetProperties())
            {
                if (property.GetValue(bill, null) is null)
                    tempObject = DBNull.Value;

                else
                    tempObject = property.GetValue(bill, null);
                parameters.Add("@" + property.Name, tempObject);
            }

            return _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Update, parameters) != DatabaseResult.Failed;

        }
    }
    public enum SearchKind
    {
        ID ,
        ResID
    }
}
