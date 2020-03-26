using System;
using System.Collections.Generic;

namespace BookMyShow.Application
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public bool IsUser { get; set; }
        public List<Booking> Bookings { get; set; }
        public Address Address { get; set; }
    }
}
