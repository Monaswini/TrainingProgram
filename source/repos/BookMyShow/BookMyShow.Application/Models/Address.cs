using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShow.Application
{
    public class Address
    {
        public int ID { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PinCode { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
       
    }
}
