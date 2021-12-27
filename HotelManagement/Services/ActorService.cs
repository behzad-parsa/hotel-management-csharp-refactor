using HotelManagement.DatabaseConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Actor = HotelManagement.Models.Actor;
namespace HotelManagement.Services
{
    public class ActorService
    {
        private readonly DatabaseOperation _db;
        public ActorService()
        {
            _db = new DatabaseOperation();
        }

        public int InsertActor(Models.Actor actor)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>();


            string sqlQuery = "INSERT INTO \"Actor\" " +
                "(Firstname , Lastname , Birthday , NationalCode , Nationality ," +
                " Email , Tel , Mobile , Gender , State , City , Address) " +
                 "Values" +
                "(@Firstname , @Lastname , @Birthday , @NationalCode , @Nationality ," +
                " @Email , @Tel , @Mobile , @Gender , @State , @City , @Address)";


            //First Approach - Initializing One By One Manually

            //parameter.Add("@Firstname", actor.Firstname);
            //parameter.Add("@Lastname ", actor.Lastname);
            //parameter.Add("@Birthday", actor.Birthday);
            //parameter.Add("@NationalCode", actor.NationalCode);
            //parameter.Add("@Nationality", Database.CheckNullInsert(nationality));
            //parameter.Add("@Email", email);
            //parameter.Add("@Tel", Database.CheckNullInsert(tel));
            //parameter.Add("@Mobile", Database.CheckNullInsert(mobile));
            //parameter.Add("@Gender", gender);
            //parameter.Add("@State", Database.CheckNullInsert(state));
            //parameter.Add("@City", Database.CheckNullInsert(city));
            //parameter.Add("@Address", Database.CheckNullInsert(address));


            //Second Approach - Iterate through The Properties of an Object
            foreach (var property in typeof(Models.Actor).GetProperties())
            {
                parameter.Add("@"+property.Name , property.GetValue(actor,null));
            }


            return _db.InsertUpdateDelete(sqlQuery, parameter, false , DatabaseOperation.OperationType.Insert);


        }



    }
}
