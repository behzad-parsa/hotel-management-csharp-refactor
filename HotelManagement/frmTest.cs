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
            HotelManagement.Models.Actor actor = new Models.Actor()
            {
                ID = 3,
                Firstname = "Florence ",
                Lastname = "Pugh",
                Birthday = new DateTime(1996, 2, 2),
                NationalCode = "5555",
                Nationality = "England",
                Address = "Bukingham",
                City = "London",
                Gender = "Female",
                Email = "fPugh@Gmail.com",
                Mobile = "095675232",
                State = "London",
                Tel = "85255"
            };
            ActorService actorService = new ActorService();
            //actorService.InsertActor(actor);
            //var actor = actorService.GetActor()
            //var result = actorService.UpdateActor(actor);
            GuestService guestService = new GuestService();

            Guest guest = new Guest()
            {
                DateModified = new DateTime(2021,12,28),
                ActID = 2027,
                CustomerID = 3031
                 
            };
            var res = guestService.DeleteGuest(guest);
        }
        
    }
}
