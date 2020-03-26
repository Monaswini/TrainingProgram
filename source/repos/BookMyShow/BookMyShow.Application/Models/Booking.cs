using System;
using System.Collections.Generic;

namespace BookMyShow.Application
{
    public class Booking
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int TheatreId { get; set; }
        public Theatre Theatre { get; set; }
        public int MovieId { get; set; }
        public DateTime BookingDate { get; set; }
        public ShowTime ShowTime { get; set; }
        public int SeatTypeId { get; set; }
        public List<BookedSeatDetail> BookedSeatList { get; set; }
        public int NumberOfBookedSeat { get; set; }
        public double TotalBookingPrice { get; set; }
    }
}
