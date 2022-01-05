using HotelManagement.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagement.Models;

namespace HotelManagement
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
            Room room = new Room()
            {
                BranchID = 1,
                Capacity = 3 ,
                Floor = 2 ,
                Description = "Hello World" , 
                IsEmpty = true , 
                Price = 1000,
                RoomNumberID  = 9,
                RoomTypeID = 1 
                
            };
            RoomService roomService = new RoomService();
            var res =roomService.InsertRoom(room);
            var getRoom = roomService.GetRoom(roomService.LastInsertedId);
            getRoom.Price = 2000; //This one have Inserted ID
            var update = roomService.UpdateRoom(getRoom);
            room.Price = 3000; //This one Just Inserted have no id , in other word id = 0
            var updateRoom = roomService.UpdateRoom(room);
            var delete = roomService.DeleteRoom(roomService.LastInsertedId);

            var getallfacil = roomService.GetAllFacilities();
            var getallroomnumber = roomService.GetAllRoomNumbers();
            var getroomType = roomService.GetAllRoomTypes();


            roomService.InsertRoomFacility(2, 5);
            roomService.InsertRoomFacility(2, 1);
            roomService.InsertRoomFacility(2, 3);
            roomService.InsertRoomFacility(2, 14);
            roomService.DeleteRoomFacility(2);


        }
        
    }
}
