using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models;
using HotelManagement.DatabaseConfig;
using System.Data;

namespace HotelManagement.Services
{
    public class GuestService
    {

        private readonly DatabaseOperation _database;
        private string sqlQuery;
        private Dictionary<string, object> parameters;
        private readonly ActorService _actorService;
        public GuestService()
        {
            _database = new DatabaseOperation();
            _actorService = new ActorService();
        }

        public bool InsertGuest(Guest guest)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "INSERT INTO \"Guest\" " +
                "(ActID, CustomerID, DateModified) " +
                "VALUES " +
                "(@ActID, @CustomerID, @DateModified)";

            object tempObject;
            foreach (var property in typeof(Guest).GetProperties())
            {

                if (property.GetValue(guest, null) is null)
                    tempObject = DBNull.Value;

                else
                    tempObject = property.GetValue(guest, null);

                parameters.Add("@" + property.Name, tempObject);
            }

           var result = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Update, parameters);

            return (result != DatabaseResult.Failed);
        }

        //Guest's Main Information Is On The Actor Entity So They Must Updated On Actor Table , 
        //Therefor , passing acotr Object to ActorService is Enough
        public bool UpdateGuest(Actor actor) => _actorService.UpdateActor(actor);
        

        public DataTable GetAllGuestsAssignToSingleCustomer(int customerID)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "SELECT ActID ,  NationalCode AS NC ,  Firstname +' '+Lastname AS Name  , DateModified AS Date , Gender , Birthday , Mobile  " +
                "FROM Actor a , Guest g  " +
                "WHERE " +
                "a.id = g.ActID AND g.CustomerID = @CustomerID AND g.DateModified = '" + DateTime.Now.Date + "'";

            parameters.Add("@CustomerID", customerID);

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return dataTable;
        }

        public bool DeleteGuest(Guest guest)
        {
            parameters = new Dictionary<string, object>();
           
            sqlQuery = "DELETE FROM \"Guest\"" +
                "WHERE " +
                "CustomerID = @CustomerID AND " +
                "DateModified = @DateModified And " +
                "ActID = @ActID";

            foreach (var property in typeof(Guest).GetProperties())
            {
                parameters.Add("@" + property.Name, property.GetValue(guest, null));
            }

           var result = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Delete, parameters);

            return (result != DatabaseResult.Failed);
        }

    }
}
