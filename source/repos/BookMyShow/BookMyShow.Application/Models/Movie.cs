﻿using System.Collections.Generic;

namespace BookMyShow.Application
{
   public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public List<MovieTheatreInfo> MovieTheatreInfo { get; set; }
    }
}
