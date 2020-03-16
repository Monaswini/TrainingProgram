using System.Collections.Generic;

namespace BookMyShowApp
{
    class Theatre
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Seat> Seats { get; set; }
        public List<TheatreSeatInfo> TheatreSeatInfo { get; set; }
        public List<Booking> Bookings { get; set; }
        public Address Address { get; set; }
    }
        public enum SeatType
        {
            GOLD,
            PLATINUM
        }
    
}
