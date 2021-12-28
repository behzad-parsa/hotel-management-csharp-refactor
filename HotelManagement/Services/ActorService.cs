using HotelManagement.DatabaseConfig;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Services
{
    public class ActorService
    {
        public int LastInsertedId { get; set; }

        private readonly DatabaseOperation _database;
        private string sqlQuery;
        private Dictionary<string, object> parameters;
       
        public ActorService()
        {
            _database = new DatabaseOperation();
        }

        public bool InsertActor(Models.Actor actor)
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
            //parameter.Add("@Mobile", Database.CheckNullInsert(mobile));
            //parameter.Add("@State", Database.CheckNullInsert(state));
            //parameter.Add("@City", Database.CheckNullInsert(city));
            //parameter.Add("@Address", Database.CheckNullInsert(address));


            //Second Approach - Iterate through The Prop erties of an Object
            //issue : All The Property Object Name And The Column Name Must Be The Same
            foreach (var property in typeof(Models.Actor).GetProperties())
            {
                parameters.Add("@"+property.Name , property.GetValue(actor,null));
            }

            LastInsertedId = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Insert, parameters);

            return (LastInsertedId != DatabaseResult.Failed);
        }
        
        public Models.Actor GetActorByNationalCode(string nationalCode , int? id)
        {
            parameters = new Dictionary<string, object>();
            sqlQuery = "SELECT * FROM \"Actor\" " +
                "WHERE " +
                "NationalCode = @NationalCode OR ID = @ID";
            parameters.Add("@NationalCode", nationalCode);
            parameters.Add("@ID", DBNull.Value);
            var dataTable =  _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

           
            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertToObj<Models.Actor>(dataTable.Rows[0]);
        }





    }
}
