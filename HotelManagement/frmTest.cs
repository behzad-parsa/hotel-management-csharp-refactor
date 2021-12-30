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

            //Employee employee = new Employee()
            //{
            //    ActID = 2029,
            //    BranchID = 1005,
            //    HireDate = DateTime.Now,
            //    Education = "Bsc",
            //    Salary = 150000
            //};

            //EmployeeService employeeService = new EmployeeService();
            //var res = employeeService.InsertEmployee(employee);

            //var res2 = employeeService.GetEmployee(16);
            //var res3 = employeeService.GetEmployee(24,1);

            //employee.ID = employeeService.LastInsertedId;
            //employee.Education = "PHD";
            //var res4 = employeeService.UpdateEmployee(employee);

            //var res5 = employeeService.DeleteEmployee(employeeService.LastInsertedId);

            CustomerService cs = new CustomerService();
            Customer c = new Customer();
            var res = cs.GetCustomer(21, null);
            
        }
        
    }
}
