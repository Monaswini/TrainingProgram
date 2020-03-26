using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShow.Application
{
    public class BookedSeatDetail
    {
        public int ID { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public int SeatNumber { get; set; }
    }
}
