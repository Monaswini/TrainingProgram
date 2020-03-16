using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowApp
{
    class BookingDetail
    {
        public int ID { get; set; }
        public int BookingId { get; set; }
        public int SeatId { get; set; }
        public Booking Booking { get; set; }
        public Seat Seat { get; set; }
    }
}
