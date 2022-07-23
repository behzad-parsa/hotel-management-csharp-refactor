using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DatabaseConfig;
using HotelManagement.Models;

namespace HotelManagement.Services
{
    public class ModuleService
    {
        public int LastInsertedId { get; private set; }

        private readonly DatabaseOperation _database;
        private string sqlQuery;
        private Dictionary<string, object> parameters;

        public ModuleService()
        {
            _database = new DatabaseOperation();
        }

        public bool InsertModule(Module module)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "INSERT INTO \"Module\" (Title) VALUES (@Title)";

            parameters.Add("@Title", module.Title);

            LastInsertedId = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Insert, parameters);

            return (LastInsertedId != DatabaseResult.Failed);
        }
        public Module GetModule(int id)
        {
            parameters = new Dictionary<string, object>();
            sqlQuery = "SELECT * FROM \"Module\" " +
                "WHERE " +
                "ID = @ID";
            parameters.Add("@ID", id);

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertRowToObj<Module>(dataTable.Rows[0]);
        }

        public List<Module> GetAllModules()
        {

            sqlQuery = "SELECT * FROM \"Module\" ";

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertDataTableToList<Module>(dataTable);
        }

        public bool DeleteModule(int id)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "DELETE FROM \"Module\" " +
                "WHERE " +
                "ID = @ID";
            parameters.Add("@ID", id);

            var result = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Delete, parameters);

            return (result != DatabaseResult.Failed);
        }

    }
}
