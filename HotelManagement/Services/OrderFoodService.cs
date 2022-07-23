using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DatabaseConfig;
using HotelManagement.Models;

namespace HotelManagement.Services
{
    public class OrderFoodService
    {
        public int LastInsertedId { get; private set; }

        private readonly DatabaseOperation _database;
        private string sqlQuery;
        private Dictionary<string, object> parameters;

        public OrderFoodService()
        {
            _database = new DatabaseOperation();
        }

        public bool InsertOrderFood(OrderFood orderFood)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "INSERT INTO \"OrderFood\" " +
                "(FoodID, ResID, Count, Total, DateModified) " +
                "VALUES " +
                "(@FoodID, @ResID, @Count, @Total, @DateModified)";


            foreach (var property in typeof(OrderFood).GetProperties())
            {
                parameters.Add("@" + property.Name, property.GetValue(orderFood, null));
            }

            LastInsertedId = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Insert, parameters);

            return (LastInsertedId != DatabaseResult.Failed);
        }
        public bool DeleteOrderFood(int id)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "DELETE FROM \"OrderFood\" " +
                "WHERE " +
                "ID = @ID";
            parameters.Add("@ID", id);

            var result = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Delete, parameters);

            return (result != DatabaseResult.Failed);
        }
    }
}
