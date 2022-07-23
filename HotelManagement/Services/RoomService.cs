using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models;
using HotelManagement.DatabaseConfig;


namespace HotelManagement.Services
{
    public class RoomService
    {
        public int LastInsertedId { get; private set; }

        private readonly DatabaseOperation _database;
        private string sqlQuery;
        private Dictionary<string, object> parameters;

        public RoomService()
        {
            _database = new DatabaseOperation();
        }

        //Operations Which Related to the Room
        public bool InsertRoom(Room room)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "INSERT INTO \"Room\" " +
                "(BranchID , RoomNumberID , RoomTypeID , IsEmpty , Floor , Capacity , Price , Description) " +
                "VALUES " +
                "(@BranchID , @RoomNumberID , @RoomTypeID , @IsEmpty , @Floor , @Capacity , @Price , @Description)";


            foreach (var property in typeof(Room).GetProperties())
            {
                parameters.Add("@" + property.Name, property.GetValue(room, null));
            }

            LastInsertedId = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Insert, parameters);

            return (LastInsertedId != DatabaseResult.Failed);
        }
        public bool UpdateRoom(Room room)
        {
            if (room.ID == 0) //means the id is not set and we can't update
                return false;
            
            parameters = new Dictionary<string, object>();
            
            sqlQuery = "UPDATE \"Room\" " +
                "SET " +
                "BranchID = @BranchID, RoomNumberID = @RoomNumberID, RoomTypeID = @RoomTypeID, " +
                "IsEmpty = @IsEmpty, Floor = @Floor, " +
                "Capacity = @Capacity, Price = @Price, Description = @Description " +
                "WHERE ID = @ID";

            object tempObject;
            foreach (var property in typeof(Room).GetProperties())
            {
                if (property.GetValue(room, null) is null)
                    tempObject = DBNull.Value;

                else
                    tempObject = property.GetValue(room, null);
                parameters.Add("@" + property.Name, tempObject);
            }
            
            return _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Update, parameters) != DatabaseResult.Failed;

        }
        public bool DeleteRoom(int id)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "DELETE FROM \"Room\" " +
                "WHERE " +
                "ID = @ID";
            parameters.Add("@ID", id);

            var result = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Delete, parameters);

            return (result != DatabaseResult.Failed);
        }
        public Room GetRoom(int id)
        {
            parameters = new Dictionary<string, object>();
            sqlQuery = "SELECT * FROM \"Room\" " +
                "WHERE " +
                "ID = @ID";
            parameters.Add("@ID", id);

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertRowToObj<Room>(dataTable.Rows[0]);
        }

        // Getting All Rows Related To Room Features 
        public List<Facility> GetAllFacilities()
        {

            sqlQuery = "SELECT * FROM \"Facilities\" ";

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertDataTableToList<Facility>(dataTable);
        }
        public List<RoomNumber> GetAllRoomNumbers()
        {

            sqlQuery = "SELECT * FROM \"RoomNumber\" ";

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertDataTableToList<RoomNumber>(dataTable);
        }
        public List<RoomType> GetAllRoomTypes()
        {

            sqlQuery = "SELECT * FROM \"RoomType\" ";

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertDataTableToList<RoomType>(dataTable);
        }

        //Operations Related to the RoomFacilities And RoomType
        public bool InsertRoomFacility(int roomID , int facilityID)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "INSERT INTO \"RoomFacilities\" " +
                "(RoomID , FacilitiesID) " +
                "VALUES " +
                "(@RoomID , @FacilitiesID)";

            parameters.Add("@RoomID", roomID);
            parameters.Add("@FacilitiesID", facilityID);

            var result= _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Update, parameters);

            return (result != DatabaseResult.Failed);
        }
        public List<Facility> GetRoomFacilities(int roomId)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "SELECT f.*  FROM RoomFacilities af,Facilities f " +
                "WHERE " +
                "af.FacilitiesID = f.ID And af.RoomID = @RoomID";
            parameters.Add("@RoomID", roomId);

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertDataTableToList<Facility>(dataTable);
        }
        public bool DeleteRoomFacility(int roomID)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "DELETE FROM \"RoomFacilities\" WHERE RoomID = @ID";

            parameters.Add("@ID", roomID);
            
            var result = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Delete, parameters);

            return (result != DatabaseResult.Failed);
        }
        //public bool InsertRoomType(int roomID, int typeID)
        //{
        //    parameters = new Dictionary<string, object>();

        //    sqlQuery = "INSERT INTO \"RoomTypeRel\" " +
        //        "(RoomID , FacilitiesID) " +
        //        "VALUES " +
        //        "(@RoomID , @FacilitiesID)";

        //    parameters.Add("@RoomID", roomID);
        //    parameters.Add("@FacilitiesID", typeID);

        //    var result = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Insert, parameters);

        //    return (result != DatabaseResult.Failed);
        //}
        //public bool DeleteRoomType(int roomID)
        //{
        //    parameters = new Dictionary<string, object>();

        //    sqlQuery = "DELETE FROM \"RoomTypeRel\" WHERE RoomID = @ID";

        //    parameters.Add("@ID", roomID);
            
        //    var result = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Delete, parameters);

        //    return (result != DatabaseResult.Failed);
        //}
    }
}
