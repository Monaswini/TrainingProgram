﻿using System.Collections.Generic;

namespace BookMyShowApp
{
    class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public List<Movie_Theatre_Info> Movie_Theatre_Info { get; set; }
    }
}
