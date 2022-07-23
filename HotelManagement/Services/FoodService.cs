using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DatabaseConfig;
using HotelManagement.Models;

namespace HotelManagement.Services
{
    public class FoodService
    {
        public int LastInsertedId { get; private set; }

        private readonly DatabaseOperation _database;
        private string sqlQuery;
        private Dictionary<string, object> parameters;

        public FoodService()
        {
            _database = new DatabaseOperation();
        }
      
        public bool InsertFood(Food food)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "INSERT INTO \"Food\" " +
                "(Title, Price, Description ) " +
                "VALUES " +
                "(@Title, @Price, @Description)";
           

            foreach (var property in typeof(Food).GetProperties())
            {
                parameters.Add("@" + property.Name, property.GetValue(food, null));
            }

            LastInsertedId = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Insert, parameters);

            return (LastInsertedId != DatabaseResult.Failed);
        }
        public bool UpdateFood(Food food)
        {
            if (food.ID == 0) //means the id is not set and we can't update
                return false;

            parameters = new Dictionary<string, object>();

            sqlQuery = "Update \"Food\" " +
                "Set " +
                "Title = @Title, Price = @Price, Description = @Description " +
                "Where ID = @ID";

            object tempObject;
            foreach (var property in typeof(Food).GetProperties())
            {
                if (property.GetValue(food, null) is null)
                    tempObject = DBNull.Value;

                else
                    tempObject = property.GetValue(food, null);
                parameters.Add("@" + property.Name, tempObject);
            }

            return _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Update, parameters) != DatabaseResult.Failed;

        }
        public bool DeleteFood(int id)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "DELETE FROM \"Food\" " +
                "WHERE " +
                "ID = @ID";
            parameters.Add("@ID", id);

            var result = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Delete, parameters);

            return (result != DatabaseResult.Failed);
        }
        public Food GetFood(int id)
        {
            parameters = new Dictionary<string, object>();
            sqlQuery = "SELECT * FROM \"Food\" " +
                "WHERE ID = @ID";
            parameters.Add("@ID", id);

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertRowToObj<Food>(dataTable.Rows[0]);
        }
    }
}
