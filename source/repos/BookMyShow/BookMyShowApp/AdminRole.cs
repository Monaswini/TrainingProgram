using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMyShowApp
{
    class AdminRole
    {
        public void AdminDBOperation()
        {
            Console.WriteLine("What operation you want to perform");
            Console.WriteLine("1. To add Movie");
            Console.WriteLine("2. To remove Movie");
            Console.WriteLine("3. To see the movies running in theatres");
            Console.WriteLine("4. To change the price of the Ticket");
            var choosenOption = Console.ReadLine();

            using (BookMyShowContext context = new BookMyShowContext())
            {
                switch (choosenOption)
                {
                    case "1":
                        {
                            //AddMovie(context);
                            break;
                        }
                    case "2":
                        {
                            //RemoveMovie(context);
                            break;
                        }
                    case "3":
                        {
                            //ShowMoviesInTheatres(context);
                            break;
                        }
                    case "4":
                        {
                            ChangeTicketPrice(context);
                            break;
                        }
                }
            }
        }

        private void ChangeTicketPrice(BookMyShowContext context)
        {
            Console.WriteLine("Enter the theatre for which you want to change the price of the ticket from the below list of theatres");
            var theatreSeatinfos = context.TheatreSeatInfo.Include(t=>t.Theatre).Include(s=>s.SeatType).ToList();
            
            foreach(var t in theatreSeatinfos)
                Console.WriteLine(t.Theatre.Name+" "+t.SeatType.Type +" "+t.Price);
            var theatreName = Console.ReadLine();
           
            if(context.Theatre.FirstOrDefault(x => x.Name.Equals(theatreName))==null)
            {
                Console.WriteLine("Theatre is not present");
                return;
            }

            Console.WriteLine("Enter the type of seat of the theatre {0} for which you wnt to change the price", theatreName);
            var seatType = Console.ReadLine();

            if(context.SeatType.FirstOrDefault(x => x.Type.Equals(seatType)) == null)
            {
                Console.WriteLine("SeatType is not present");
                return;
            }
            Console.WriteLine("Enter the change price");
            var changedPrice = Convert.ToInt32(Console.ReadLine());
            var info = theatreSeatinfos.First(s => s.SeatType.Type == seatType && s.Theatre.Name== theatreName);
            info.Price = changedPrice;
            context.SaveChanges();
        }

        private void ShowMoviesInTheatres(BookMyShowContext context)
        {
            var movieTheatreInfo = context.MovieTheatreInfo.Include(m => m.Movie)
                .Include(x => x.Theatre).ToList();
            foreach (var m in movieTheatreInfo)
                Console.WriteLine(m.Movie.Name + " : " + m.Theatre.Name);
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
        private void AddMovie(BookMyShowContext context)
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
                return;
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
                return;
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
           // return true;
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
    }
}
