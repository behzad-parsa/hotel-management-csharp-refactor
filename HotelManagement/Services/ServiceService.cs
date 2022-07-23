using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DatabaseConfig;
using HotelManagement.Models;

namespace HotelManagement.Services
{
    public class ServiceService
    {
        public int LastInsertedId { get; private set; }

        private readonly DatabaseOperation _database;
        private string sqlQuery;
        private Dictionary<string, object> parameters;

        public ServiceService()
        {
            _database = new DatabaseOperation();
        }

        public bool InsertService(Service service)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "INSERT INTO \"Service\" " +
                "(Title, Price, Description ) " +
                "VALUES " +
                "(@Title, @Price, @Description)";


            foreach (var property in typeof(Service).GetProperties())
            {
                parameters.Add("@" + property.Name, property.GetValue(service, null));
            }

            LastInsertedId = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Insert, parameters);

            return (LastInsertedId != DatabaseResult.Failed);
        }
        public bool UpdateService(Service service)
        {
            if (service.ID == 0) //means the id is not set and we can't update
                return false;

            parameters = new Dictionary<string, object>();

            sqlQuery = "Update \"Service\" " +
                "Set " +
                "Title = @Title, Price = @Price, Description = @Description " +
                "Where ID = @ID";

            object tempObject;
            foreach (var property in typeof(Service).GetProperties())
            {
                if (property.GetValue(service, null) is null)
                    tempObject = DBNull.Value;

                else
                    tempObject = property.GetValue(service, null);
                parameters.Add("@" + property.Name, tempObject);
            }

            return _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Update, parameters) != DatabaseResult.Failed;

        }
        public bool DeleteService(int id)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "DELETE FROM \"Service\" " +
                "WHERE " +
                "ID = @ID";
            parameters.Add("@ID", id);

            var result = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Delete, parameters);

            return (result != DatabaseResult.Failed);
        }
        public Service GetService(int id)
        {
            parameters = new Dictionary<string, object>();
            sqlQuery = "SELECT * FROM \"Service\" " +
                "WHERE ID = @ID";
            parameters.Add("@ID", id);

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertRowToObj<Service>(dataTable.Rows[0]);
        }




    }
}
