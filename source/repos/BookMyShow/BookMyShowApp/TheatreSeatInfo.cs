namespace BookMyShowApp
{
    class TheatreSeatInfo
    {
        public int ID { get; set; }
        public int TheatreId { get; set; }
        public Theatre Theatre { get; set; }
        public int SeatTypeId { get; set; }
        public SeatType SeatType { get; set; }
        public int Price { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
