using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models;
using HotelManagement.Services;
using HotelManagement.DatabaseConfig;

namespace HotelManagement.Services
{
    public class ReservationService
    {
        public int LastInsertedId { get; private set; }

        private readonly DatabaseOperation _database;
        private string sqlQuery;
        private Dictionary<string, object> parameters;

        public ReservationService()
        {
            _database = new DatabaseOperation();
        }

        public bool InsertReservation(Reservation reservation)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "INSERT INTO \"Reservation\" " +
                "(UserID , CustomerID , RoomID , StartDate , EndDate , TotalPayDueDate , DateModified) " +
                "VALUES " +
                "(@UserID , @CustomerID , @RoomID , @StartDate , @EndDate , @TotalPayDueDate , @DateModified)";


            foreach (var property in typeof(Reservation).GetProperties())
            {
                parameters.Add("@" + property.Name, property.GetValue(reservation, null));
            }

            LastInsertedId = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Insert, parameters);

            return (LastInsertedId != DatabaseResult.Failed);
        }
        //using update when customer abort the reservation
        public bool UpdateReservation(Reservation reservation)
        {
            if (reservation.ID == 0) //means the id is not set and we can't update
                return false;

            parameters = new Dictionary<string, object>();

            sqlQuery = "UPDATE \"Reservation\"  " +
                "SET " +
                //the check-in time will assign to cancelDate
                "CancelDate = @CancelDate, " +  //@CancelDate === @Check-In
                "TotalPayDueDate = @TotalPayDueDate  " +
                "WHERE " +
                "ID = @ID";


            object tempObject;
            foreach (var property in typeof(Reservation).GetProperties())
            {
                if (property.GetValue(reservation, null) is null)
                    tempObject = DBNull.Value;

                else
                    tempObject = property.GetValue(reservation, null);
                parameters.Add("@" + property.Name, tempObject);
            }

            return _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Update, parameters) != DatabaseResult.Failed;

        }
        public bool DeleteReservation(int id)
        {
            parameters = new Dictionary<string, object>();

            sqlQuery = "DELETE FROM \"Reservation\" " +
                "WHERE ID = @ID";

            parameters.Add("@ID", id);

            var result = _database.InsertUpdateDelete(sqlQuery, DatabaseOperation.OperationType.Delete, parameters);

            return (result != DatabaseResult.Failed);
        }
        public Reservation GetReservation(int id)
        {
            parameters = new Dictionary<string, object>();
            sqlQuery = "SELECT * FROM \"Reservation\" Where ID = @ID";

            parameters.Add("@ID", id);

            var dataTable = _database.Select(sqlQuery, DatabaseOperation.OperationType.Select, parameters);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            return Mapper.ConvertRowToObj<Reservation>(dataTable.Rows[0]);
        }



    }
}
