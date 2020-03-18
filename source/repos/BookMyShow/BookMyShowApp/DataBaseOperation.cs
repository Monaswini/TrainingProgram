using Microsoft.EntityFrameworkCore;
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
            Console.WriteLine("3. To See Movie the running in theatres");
            Console.WriteLine("4. To change the price of the Ticket");
            var choosenOption = Console.ReadLine();

            using (BookMyShowContext context = new BookMyShowContext())
            {
                Movie movie = new Movie();
                switch (choosenOption)
                {
                    case "1":
                        {
                            var result = AddMovie(context, movie);
                            if (result)
                                Console.WriteLine("Movie added");
                            else
                                Console.WriteLine("Movie did not added.Try again..");
                            break;
                        }
                    case "2":
                        {
                            RemoveMovie(context);
                            break;
                        }
                    case "3":
                        {
                            ShowMoviesInTheatres(context);
                            break;
                        }
                }
            }
        }

        private void ShowMoviesInTheatres(BookMyShowContext context)
        {
            var movieTheatreInfo = context.MovieTheatreInfo.Include(m => m.Movie)
                .Include(x => x.Theatre).ToList();
            foreach(var m in movieTheatreInfo)
                Console.WriteLine(m.Movie.Name+" : "+m.Theatre.Name);
        }

        private void RemoveMovie(BookMyShowContext context)
        {
            Console.WriteLine("Enter the movie name you want to remove");
            var movies = context.Movie.ToList();
            movies.ForEach(x => Console.WriteLine(x.ID + " : " + x.Name));
            var selectedMovie = Console.ReadLine();
            var movieTobeDeleted = movies.FirstOrDefault(x => x.Name.Equals(selectedMovie));
            if (movieTobeDeleted == null)
            {
                Console.WriteLine("Not present in the list");
                return;
            }

            //var movieTheatreInfo = context.Movie.Include(mt => mt.MovieTheatreInfo)
            //    .ThenInclude(x => x.Theatre)
            //    .First(x => x.ID == movieTobeDeleted.ID);

            //var movieInTheatre = movieTheatreInfo.MovieTheatreInfo; //getting the list of theatres where the movie is running

            //foreach (var m in movieInTheatre)
            //    Console.WriteLine(m.Theatre.ID + " : " + m.Theatre.Name);

            //var count = 0;
            //while (count <= movieInTheatre.Count)
            //{
            //    Console.WriteLine("Select the theatres from where you want to remove the movie " + selectedMovie);
            //    var selectedTheatreId = Convert.ToInt32(Console.ReadLine());

            //}
            //var t = context.Theatre.Select(x => x.ID);
            //var t1 = context.Theatre.Where(x => x.ID == 2);
            //var t2 = context.Theatre.FirstOrDefault(x => x.ID == 2);


            context.Movie.Remove(movieTobeDeleted);
            context.SaveChanges();
            Console.WriteLine("Movie removed");
        }

        private bool AddMovie(BookMyShowContext context, Movie movie)
        {
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

            Console.WriteLine("Total Number of available Theatres : " + context.Theatre.Count());
            Console.WriteLine("Enter the no of the Theatres to be choosen");
            var noOfTheatre = Convert.ToInt32(Console.ReadLine());
            if (noOfTheatre > context.Theatre.Count())
            {
                Console.WriteLine("Exceeds maximum. Try again..");
                return false;
            }

            Console.WriteLine("Select the Theater");
            var theatres = context.Theatre.ToList();
            List<Theatre> choosenTheatres = ChoosenTheatres(theatres, noOfTheatre);
            List<MovieTheatreInfo> movieTheatreInfos = new List<MovieTheatreInfo>();
            foreach (var theatre in choosenTheatres)
            {
                var movieTheatreInfo = new MovieTheatreInfo();
                movieTheatreInfo.Theatre = theatre;
                movieTheatreInfos.Add(movieTheatreInfo);
            }


            movie.Name = movieName;
            movie.MovieTheatreInfo = movieTheatreInfos;

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
