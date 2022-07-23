using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models;
using HotelManagement.DatabaseConfig;


namespace HotelManagement.Services
{
    public class OrderServiceService
    {
        public int LastInsertedId { get; private set; }

        private readonly DatabaseOperation _database;
        private string sqlQuery;
        private Dictionary<string, object> parameters;

        public OrderServiceService()
        {
            _database = new DatabaseOperation();
        }
        public bool InsertOrderService(OrderService orderService)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "INSERT INTO \"OrderService\" " +
                "(FoodID, ResID, Count, Total, DateModified) " +
                "VALUES " +
                "(@FoodID, @ResID, @Count, @Total, @DateModified)";


            foreach (var property in typeof(OrderService).GetProperties())
            {
                parameters.Add("@" + property.Name, property.GetValue(orderService, null));
            }

            LastInsertedId = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Insert, parameters);

            return (LastInsertedId != DatabaseResult.Failed);
        }
        public bool DeleteOrderService(int id)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "DELETE FROM \"OrderService\" " +
                "WHERE " +
                "ID = @ID";
            parameters.Add("@ID", id);

            var result = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Delete, parameters);

            return (result != DatabaseResult.Failed);
        }
    }
}
