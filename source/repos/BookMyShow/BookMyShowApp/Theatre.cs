using System.Collections.Generic;

namespace BookMyShowApp
{
    class Theatre
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<TheatreSeatInfo> TheatreSeatInfos { get; set; }
        public List<MovieTheatreInfo> MovieTheatreInfo { get; set; }
    }
    enum ShowTime
    {
        morning,
        afternoon,
        evening,
        night
    }
}
