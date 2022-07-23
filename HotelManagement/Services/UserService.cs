using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models;
using HotelManagement.Services;
using HotelManagement.DatabaseConfig;
using UserChat = HotelManagement.ChatInfo.User;

namespace HotelManagement.Services
{
    public class UserService
    {
        public int LastInsertedId { get; private set; }

        private readonly DatabaseOperation _database;
        private string sqlQuery;
        private Dictionary<string, object> parameters;

        public UserService()
        {
            _database = new DatabaseOperation();
        }

        public bool InsertUser(User user)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "INSERT INTO \"User\" " +
                "(EmployeeID, RoleID, Username, Password, Image, Activate) " +
                "VALUES " +
                "(@EmployeeID, @RoleID, @Username , @Password, @Image, @Activate)";

            foreach (var property in typeof(Transact).GetProperties())
            {
                parameters.Add("@" + property.Name, property.GetValue(user, null));
            }

            LastInsertedId = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Insert, parameters);

            return (LastInsertedId != DatabaseResult.Failed);
        }
        public User GetUser(string username)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "SELECT * FROM \"User\" " +
                "WHERE Username = @Username ";

            parameters.Add("@Username ", username);

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertRowToObj<User>(dataTable.Rows[0]);
        }
        public User GetUser(int employeeID)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "SELECT * FROM \"User\" " +
                "WHERE  " +
                "EmployeeID = @EmployeeID ";

            parameters.Add("@EmployeeID", employeeID);

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertRowToObj<User>(dataTable.Rows[0]);
        }
        public UserChat GetOnlineUser(string username)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "SELECT u.id as Uid , Image , a.Firstname +' '+ a.Lastname as Name , BranchName   " +
                        "FROM [User] u , Employee e , Actor a , BranchInfo b  " +
                        "WHERE" +
                        " Username = @Username And u.EmployeeID = e.ID And e.BranchID = b.ID And e.ActID = a.ID ";

            parameters.Add("@Username", username);

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertRowToObj<UserChat>(dataTable.Rows[0]);
        }
        public DateTime GetLastSignIn(int id)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "SELECT DateTime FROM LoginHistory " +
                    "WHERE UserID = @UserID " +
                    "ORDER BY DateTime DESC";

            parameters.Add("@UserID", id);

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return DateTime.MinValue;

            return Convert.ToDateTime(dataTable.Rows[0]["DateTime"]);
        }

        public bool UpdateUser(User user)
        {
            if (user.ID == 0) //means the id is not set and we can't update
                return false;

            parameters = new Dictionary<string, object>();

            sqlQuery = "UPDATE \"User\"  " +
                "SET " +
                "EmployeeID = @EmployeeID, RoleID = @RoleID, Username = @Username, Image = @Image, Activate = @Activate " +
                "WHERE " +
                "ID = @ID";


            object tempObject;
            foreach (var property in typeof(User).GetProperties())
            {
                if (property.GetValue(user, null) is null)
                    tempObject = DBNull.Value;

                else
                    tempObject = property.GetValue(user, null);
                parameters.Add("@" + property.Name, tempObject);
            }

            return _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Update, parameters) != DatabaseResult.Failed;

        }
        public bool UpdateUserWithPass(User user)
        {
            if (user.ID == 0) //means the id is not set and we can't update
                return false;

            parameters = new Dictionary<string, object>();

            sqlQuery = "UPDATE \"User\" " +
                "SET " +
                "EmployeeID = @EmployeeID, RoleID = @RoleID, Username = @Username, Password = @Password, " +
                "Image = @Image, Activate = @Activate " +
                "WHERE ID = @ID";

            object tempObject;
            foreach (var property in typeof(User).GetProperties())
            {
                if (property.GetValue(user, null) is null)
                    tempObject = DBNull.Value;

                else
                    tempObject = property.GetValue(user, null);
                parameters.Add("@" + property.Name, tempObject);
            }

            return _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Update, parameters) != DatabaseResult.Failed;

        }
        public bool DeleteUser(int id)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "DELETE FROM [User] WHERE ID = @ID ";
            parameters.Add("@ID", id);

            var result = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Delete, parameters);

            return (result != DatabaseResult.Failed);
        }

    }
}
