using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowApp
{
    class Movie_Theatre_Info
    {
        public int ID { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int TheatreId { get; set; }
        public Theatre Theatre { get; set; }

    }
}
