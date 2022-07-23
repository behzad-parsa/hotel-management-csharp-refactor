﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class OrderService
    {
        public int ID { get; set; }
        public int ResID { get; set; }
        public int SerivceID { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
        public DateTime DateModified { get; set; }
    }
}