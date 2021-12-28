using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models;
using HotelManagement.DatabaseConfig;

namespace HotelManagement.Services
{
    public class GuestService
    {

        private readonly DatabaseOperation _database;
        private string sqlQuery;
        private Dictionary<string, object> parameters;

        public GuestService()
        {
            _database = new DatabaseOperation();
        }

        public bool InsertGuest(Guest guest)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "INSERT INTO \"Guest\" " +
                "(ActID, CustomerID, DateModified) " +
                "VALUES " +
                "(@ActID, @CustomerID, @DateModified)";

            
            foreach (var property in typeof(Guest).GetProperties())
            {
                parameters.Add("@" + property.Name, property.GetValue(guest, null));
            }

           var result = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Update, parameters);

            return (result != DatabaseResult.Failed);
        }

        //public bool UpdateGuest(Guest Guest)
        //{
        //    parameters = new Dictionary<string, object>();
        //    sqlQuery = "UPDATE \"Guest\" " +
        //        "Set Firstname = @Firstname , Lastname = @Lastname  , Birthday=@Birthday ," +
        //        "NationalCode = @NationalCode , Nationality = @Nationality , Email = @Email ," +
        //        "Tel= @Tel , Mobile= @Mobile , Gender= @Gender , State = @State, City = @City ," +
        //        "Address = @Address WHERE ID = @ID ";


        //    foreach (var property in typeof(Guest).GetProperties())
        //    {
        //        parameters.Add("@" + property.Name, property.GetValue(Guest, null));
        //    }

        //    return _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Update, parameters) != DatabaseResult.Failed;

        //}

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
