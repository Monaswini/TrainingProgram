using System;

namespace BookMyShowApp
{
    class Booking
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int TheatreId { get; set; }
        public Theatre Theatre { get; set; }
        public int MovieId { get; set; }
        public DateTime BookingDate { get; set; }
        public ShowTime ShowTime { get; set; }
        public float TotalPrice { get; set; }
    }
}
