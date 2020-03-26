using System.Collections.Generic;

namespace BookMyShow.Application
{
    public class Theatre
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<TheatreSeatInfo> TheatreSeatInfos { get; set; }
        public List<MovieTheatreInfo> MovieTheatreInfo { get; set; }
    }
    public enum ShowTime
    {
        morning,
        afternoon,
        evening,
        night
    }
}
