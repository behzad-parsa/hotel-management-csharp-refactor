﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmLogin());
            //Application.Run(new frmTest());
            //Application.Run(new frmMain());
            EditTransact editTransact = new EditTransact();
            editTransact.transID = 5;
            Application.Run(editTransact);
        }
    }
}
