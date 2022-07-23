using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models;
using HotelManagement.DatabaseConfig;


namespace HotelManagement.Services
{
    public class AccessLevelService
    {

        private readonly DatabaseOperation _database;
        private string sqlQuery;
        private Dictionary<string, object> parameters;

        public AccessLevelService()
        {
            _database = new DatabaseOperation();
        }

        public bool InsertAccessLevel(AccessLevel accessLevel)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "INSERT INTO \"AccessLevel\" " +
                "(RoleID , ModuleID ) VALUES (@RoleID , @ModuleID )";

            parameters.Add("@RoleID", accessLevel.RoleID);
            parameters.Add("@ModuleID", accessLevel.ModuleID);

            var result = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Update, parameters);

            return (result != DatabaseResult.Failed);
        }

        /// <summary>
        /// Return the list of Modules which a role has access.
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public List<Module> GetRoleAuthorities(int roleID)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "SELECT m.*  FROM \"Module\" as m , AccessLevel a " +
                "WHERE " +
                "a.ModuleID = m.ID AND a.RoleID = @RoleID ";
            parameters.Add("@RoleID", roleID);

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertDataTableToList<Module>(dataTable);
        }


        /// <summary>
        /// Return the list of Roles which a module gives access to them.
        /// </summary>
        /// <param name="moduleID"></param>
        /// <returns></returns>
        public List<Role> GetModuleAuthorities(int moduleID)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "SELECT r.* FROM \"Role\" as r , AccessLevel a " +
                "WHERE " +
                "r.ID = a.RoleID AND a.ModuleID = @ModuleID ";
            parameters.Add("@ModuleID", moduleID);

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertDataTableToList<Role>(dataTable);
        }


        public bool DeleteAccessLevel(int roleID)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "DELETE FROM \"AccessLevel\" " +
                "WHERE " +
                "RoleID  = @RoleID";
            parameters.Add("@RoleID", roleID);

            var result = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Delete, parameters);

            return (result != DatabaseResult.Failed);
        }



    }
}
