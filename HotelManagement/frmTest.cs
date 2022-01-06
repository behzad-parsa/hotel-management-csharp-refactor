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
            Food food = new Food()
            {
                Description = "It's healthy",
                 Price = 200,
                 Title = "Kabab"
            };
            FoodService foodService = new FoodService();
            var result = foodService.InsertFood(food);

            food.ID = foodService.LastInsertedId;
            food.Price = 250;
            var update = foodService.UpdateFood(food);
            var get = foodService.GetFood(food.ID);
            var delete = foodService.DeleteFood(food.ID);


        }
        
    }
}
