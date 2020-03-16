using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowApp
{
    class Address
    {
        public int ID { get; set; }
        public string city { get; set; }
        public string State { get; set; }
        public int PinCode { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int TheatreId { get; set; }
        public Theatre Theatre { get; set; }
    }
}
