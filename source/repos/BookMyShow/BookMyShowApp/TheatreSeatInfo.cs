namespace BookMyShowApp
{
    class TheatreSeatInfo
    {
        public int ID { get; set; }
        public SeatType SeatType { get; set; }
        public int NumberOfSeats { get; set; }
        public int Price { get; set; }
        public ShowTime ShowTime { get; set; }

        public Theatre Theatre { get; set; }
        public int TheaterId { get; set; }
    }
    public enum ShowTime
    { 
        MORNING,
        AFTERNOON,
        EVENING,
        NIGHT
    }
}
