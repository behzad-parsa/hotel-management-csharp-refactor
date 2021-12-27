using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement
{
    public class Branch
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Owner { get; set; }

        public string BranchName { get; set; }
        public string Rate { get; set; }

        public byte[] Logo { get; set; }

        public string Tel { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public  string Address { get; set; }

        public Branch(int id , string code , string owner , string branchName , string rate , byte[] logo , string tel , string state , string city , string address)
        {
            this.ID = id;
            this.Code = code;
            this.Owner = owner;
            this.BranchName = branchName;
            this.Rate = rate;
            this.Logo = logo;
            this.Tel = tel;
            this.State = state;
            this.City = city;
            this.Address = address;
           




        }


    }
}
