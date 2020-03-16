using System.Collections.Generic;

namespace BookMyShowApp
{
    class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
