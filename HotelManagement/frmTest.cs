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

            ModuleService moduleService = new ModuleService();
            moduleService.InsertModule(new Module()
            {
                Title = "Chat"
            });
            var module = moduleService.GetModule(moduleService.LastInsertedId);
            var modules = moduleService.GetAllModules();
            var res = moduleService.DeleteModule(moduleService.LastInsertedId);

            var roleModules = moduleService.GetModules(1);

        }
        
    }
}
