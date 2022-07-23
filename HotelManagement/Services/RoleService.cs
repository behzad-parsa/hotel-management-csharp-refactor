using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DatabaseConfig;
using HotelManagement.Models;

namespace HotelManagement.Services
{
    public class RoleService
    {
        public int LastInsertedId { get; private set; }

        private readonly DatabaseOperation _database;
        private string sqlQuery;
        private Dictionary<string, object> parameters;

        public RoleService()
        {
            _database = new DatabaseOperation();
        }

        public bool InsertRole(Role role)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "Insert Into \"Role\" (Title) Values (@Title)";

            parameters.Add("@Title" , role.Title);

            LastInsertedId = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Insert, parameters);

            return (LastInsertedId != DatabaseResult.Failed);
        }
        public Role GetRole(int id)
        {
            parameters = new Dictionary<string, object>();
            sqlQuery = "SELECT * FROM \"Role\" " +
                "WHERE " +
                "ID = @ID";
            parameters.Add("@ID", id);

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertRowToObj<Role>(dataTable.Rows[0]);
        }
        public List<Role> GetAllRoles()
        {

            sqlQuery = "SELECT * FROM \"Role\" ";

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertDataTableToList<Role>(dataTable);
        }
        //public bool UpdateRole(Role Role)
        //{
        //    parameters = new Dictionary<string, object>();
        //    sqlQuery = "UPDATE \"Role\" " +
        //        "Set Firstname = @Firstname , Lastname = @Lastname  , Birthday=@Birthday ," +
        //        "NationalCode = @NationalCode , Nationality = @Nationality , Email = @Email ," +
        //        "Tel= @Tel , Mobile= @Mobile , Gender= @Gender , State = @State, City = @City ," +
        //        "Address = @Address WHERE ID = @ID ";

        //    object tempObject;
        //    foreach (var property in typeof(Role).GetProperties())
        //    {
        //        if (property.GetValue(Role, null) is null)
        //            tempObject = DBNull.Value;

        //        else
        //            tempObject = property.GetValue(Role, null);
        //        parameters.Add("@" + property.Name, tempObject);
        //    }

        //    return _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Update, parameters) != DatabaseResult.Failed;

        //}
        public bool DeleteRole(int id)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "DELETE FROM \"Role\" " +
                "WHERE " +
                "ID = @ID";
            parameters.Add("@ID", id);

            var result = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Delete, parameters);

            return (result != DatabaseResult.Failed);
        }
    }
}
