using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement
{
   public class Activity
    {
        public DateTime Date { get; set; }
        public string Title {  get;  set; }
        public string Description { get; set; }

        public Activity()
        {

        }

        public Activity(DateTime date , string title , string des)
        {
            this.Date = date;
            this.Title = title;
            this.Description = des;
        }

        public Activity( string title, string des)
        {
            this.Date = DateTime.Now;
            this.Title = title;
            this.Description = des;
        }
    }
}
