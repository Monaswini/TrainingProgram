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
                switch (choosenOption)
                {
                    case "1":
                        {
                            var result=AddMovie(context);
                            if(result)
                            Console.WriteLine("Movie added");
                            else
                                Console.WriteLine("Movie did not added.Try again..");
                            break;
                        }

                }
            }
        }

        private bool AddMovie(BookMyShowContext context)
        {
            Movie movie = new Movie();
            Console.WriteLine("Select Genre for your movie");
            var genres = context.Genre.ToList();
            //for (var i = 0; i < genres.Count; i++)
            //    Console.WriteLine(i + 1 + ". " + genres[i].Name);
            genres.ForEach(x => Console.WriteLine(x.ID + " : " + x.Name));
            var choosenGenre = Convert.ToInt32(Console.ReadLine());
            var genre = genres.FirstOrDefault(x => x.ID.Equals(choosenGenre));
            //foreach (var genre in genres)
            //{
            //    if (choosenGenre.Equals(genre.ID))
            //    {
            //        movie.Genre = genre;
            //        break;
            //    }
            //}
            if (genre == null)
            {
                Console.WriteLine("Select correct Genre.");
                return false;
            }
                

            movie.Genre = genre;
            Console.WriteLine("Enter movie name");
            var movieName = Console.ReadLine();

            Console.WriteLine("Total Number of available Theatres : "+context.Theatre.Count());
            Console.WriteLine("Enter the no of the Theatres to be choosen");
            var noOfTheatre = Convert.ToInt32(Console.ReadLine());
            if(noOfTheatre> context.Theatre.Count())
            {
                Console.WriteLine("Exceeds maximum. Try again..");
                return false;
            }

            Console.WriteLine("Select the Theater");
            var theatres = context.Theatre.ToList();
            List<Theatre> choosenTheatres = ChoosenTheatres(theatres, noOfTheatre);
            List<Movie_Theatre_Info> movie_Theatre_Infos = new List<Movie_Theatre_Info>();
            foreach (var theatre in choosenTheatres)
            {
                var movie_Theatre_Info = new Movie_Theatre_Info();
                movie_Theatre_Info.Theatre = theatre;
                movie_Theatre_Infos.Add(movie_Theatre_Info);
            }


            movie.Name = movieName;
            movie.Movie_Theatre_Info = movie_Theatre_Infos;

            context.Movie.Add(movie);
            context.SaveChanges();
            return true;
        }

        private List<Theatre> ChoosenTheatres(List<Theatre> theatres, int noOfTheatre)
        {
            for (var i = 1; i <= theatres.Count; i++)
                Console.WriteLine((i) + "." + theatres[i - 1].Name);
            Console.WriteLine("Enter 1 for 'AMB Cinemas'");
            Console.WriteLine("Enter 2 for 'Cinepolis'");
            Console.WriteLine("Enter 3 for 'Platinum Movie Time'");
            Console.WriteLine("Enter 4 for 'PVR Icon'");


            List<Theatre> list = new List<Theatre>();
            
            int j = 1;
            while (j <= noOfTheatre)
            {
                Console.WriteLine("Enter your choice");
                int c = Convert.ToInt32(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        list.Add(theatres[--c]);
                        break;
                    case 2:
                        list.Add(theatres[--c]);
                        break;
                    case 3:
                        list.Add(theatres[--c]);
                        break;
                    case 4:
                        list.Add(theatres[--c]);
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
                j++;
            }
            return list;
        }

        public void UserDBOperation()
        {
            using (BookMyShowContext context = new BookMyShowContext())
            {

            }
        }
    }
}
