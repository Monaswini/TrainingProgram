using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMyShowApp
{
    class DataBaseOperation
    {
        public void AdminDBOperation()
        {
            Console.WriteLine("What operation you want to perform");
            Console.WriteLine("1. To add Movie");
            Console.WriteLine("2. To Remove Movie");
            Console.WriteLine("3. To change the price of the Ticket");
            var choosenOption = Console.ReadLine();

            using (BookMyShowContext context = new BookMyShowContext())
            {
                switch(choosenOption)
                {
                    case "1":
                        {
                            Movie movie = new Movie();
                            Console.WriteLine("Select Genre for your movie");
                                var genres = context.Genre.ToList();
                                for(var i= 0;i < genres.Count;i++)
                                    Console.WriteLine(i+1+". "+genres[i].Name);
                                var choosenGenre = Console.ReadLine().ToLower();
                                foreach(var genre in genres)
                                {
                                    if(!choosenGenre.Equals(genre))
                                        break;
                                    movie.Genre = genre;
                                }
                            Console.WriteLine("Enter movie name");
                            var movieName = Console.ReadLine();

                            break;
                        }
                    
                }
            }
        }

        public void UserDBOperation()
        {
            using (BookMyShowContext context = new BookMyShowContext())
            {

            }
        }
    }
}
