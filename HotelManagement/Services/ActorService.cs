using HotelManagement.DatabaseConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Services
{
    public class ActorService
    {
        private readonly DatabaseOperation _database;
        private string sqlQuery;
        public ActorService()
        {
            _database = new DatabaseOperation();
        }

        public int InsertActor(Models.Actor actor)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>();


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
            foreach (var property in typeof(Models.Actor).GetProperties())
            {
                parameter.Add("@"+property.Name , property.GetValue(actor,null));
            }


            return _database.InsertUpdateDelete(sqlQuery, parameter, false , DatabaseOperation.OperationType.Insert);
        }
        //public int GetLastInsertedId()
        //{
        //    sqlQuery = "Select IDENT_CURRENT('/Actor'/)"
        //    return _database.select("Select ");
        //}


    }
}
