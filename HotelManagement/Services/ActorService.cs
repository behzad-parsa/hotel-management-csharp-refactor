using HotelManagement.DatabaseConfig;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models;

namespace HotelManagement.Services
{
    public class ActorService
    {
        public int LastInsertedId { get; private set; }

        private readonly DatabaseOperation _database;
        private string sqlQuery;
        private Dictionary<string, object> parameters;
       
        public ActorService()
        {
            _database = new DatabaseOperation();
        }

        public bool InsertActor(Actor actor)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "INSERT INTO \"Actor\" " +
                "(Firstname , Lastname , Birthday , NationalCode , Nationality ," +
                "Email , Tel , Mobile , Gender , State , City , Address) " +
                 "VALUES" +
                "(@Firstname , @Lastname , @Birthday , @NationalCode , @Nationality ," +
                " @Email , @Tel , @Mobile , @Gender , @State , @City , @Address)";


            //First Approach - Initializing One By One Manually

            //parameter.Add("@Firstname", actor.Firstname);
            //parameter.Add("@Lastname ", actor.Lastname);
            //parameter.Add("@NationalCode", actor.NationalCode);
            //parameter.Add("@Nationality", Database.CheckNullInsert(nationality));
            //parameter.Add("@Tel", Database.CheckNullInsert(tel));
            //parameter.Add("@City", Database.CheckNullInsert(city));
            //parameter.Add("@Address", Database.CheckNullInsert(address));


            //Second Approach - Iterate through The Properties of an Object
            //issue : All The Property Object Name And The Column Name Must Be The Same
            foreach (var property in typeof(Actor).GetProperties())
            {
                parameters.Add("@"+property.Name , property.GetValue(actor,null));
            }

            LastInsertedId = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Insert, parameters);

            return (LastInsertedId != DatabaseResult.Failed);
        }
        
        public Actor GetActor(int id)
        {
            parameters = new Dictionary<string, object>();
            sqlQuery = "SELECT * FROM \"Actor\" " +
                "WHERE " +
                "ID = @ID";
            parameters.Add("@ID", id);

            var dataTable =  _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertRowToObj<Actor>(dataTable.Rows[0]);
        }
        public Actor GetActor(string nationalCode)
        {
            parameters = new Dictionary<string, object>();
            sqlQuery = "SELECT * FROM \"Actor\" " +
                "WHERE " +
                "NationalCode = @NationalCode";
            parameters.Add("@NationalCode", nationalCode);

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);
            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertRowToObj<Actor>(dataTable.Rows[0]);
        }
        public bool UpdateActor(Actor actor)
        {
            if (actor.ID == 0)
                return false;

            parameters = new Dictionary<string, object>();
            sqlQuery = "UPDATE \"Actor\" " +
                "Set Firstname = @Firstname , Lastname = @Lastname  , Birthday=@Birthday , " +
                "NationalCode = @NationalCode , Nationality = @Nationality , Email = @Email, " +
                "Tel= @Tel, Mobile= @Mobile, Gender= @Gender, State = @State, City = @City, " +
                "Address = @Address " +
                "WHERE " +
                "ID = @ID ";

            object tempObject;
            foreach (var property in typeof(Actor).GetProperties())
            {
                if (property.GetValue(actor, null) is null)
                    tempObject = DBNull.Value;

                else
                    tempObject = property.GetValue(actor, null);
                parameters.Add("@" + property.Name, tempObject);
            }

            return _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Update, parameters) != DatabaseResult.Failed;

        }

    }
}
