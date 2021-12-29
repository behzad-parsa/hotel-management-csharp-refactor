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
            //HotelManagement.Models.Actor actor = new Models.Actor()
            //{
            //    Firstname = "Maria",
            //    Lastname = "Johnson",
            //    Birthday = new DateTime(1996, 2, 2),
            //    NationalCode = "123564456",
            //    Nationality = "Iran",
            //    Address = "ValiAsr",
            //    City = "Arakis",
            //    Gender = "Male",
            //    Email = "Sth@yahoo.com",
            //    Mobile = "123456789",
            //    State = "Tehran",
            //    Tel = "123546"



            //};
            //ActorService actorService = new ActorService();
            //actorService.InsertActor(actor);

            //ActorService actorservice = new ActorService();

            //actorservice.InsertActor(new Actor()
            //{
            //    Firstname= "hAJ"
            //});


            BranchService branchService = new BranchService();

            var list = branchService.GetAllBranches();
            var branch = branchService.GetBranch(2);

            Branch br = new Branch()
            {
              
                City = "Tehran",
                Address = "BLVD",
                Logo = branch.Logo,
                Owner = "Sorosh" ,
                BranchName = "Dune" ,
                Rate = "3" , 
                State = "Tehran" ,
                Code = "GHJ12585" ,
                Tel = "11111111"
                
                
            };
            var res = branchService.InsertBranch(br);
           

        }
        
    }
}
