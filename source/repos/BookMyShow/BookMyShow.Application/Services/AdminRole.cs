using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMyShow.Application
{
    public class AdminRole
    {
        BookMyShowContext context = new BookMyShowContext();
        public void ChangeTicketPrice(int theatreId, int seatTypeId, int changedPrice)
        {
            var info = context.TheatreSeatInfo.First(s => s.SeatTypeId == seatTypeId && s.TheatreId == theatreId);
            info.Price = changedPrice;
            context.SaveChanges();
        }

        public List<MovieTheatreInfo> ShowMoviesInTheatres()
        {
            var movieTheatreInfo = context.MovieTheatreInfo.Include(m => m.Movie)
                .Include(x => x.Theatre).ToList();
            return movieTheatreInfo;
        }

        public void RemoveMovie(Movie movieTobeDeleted)
        {
            context.Movie.Remove(movieTobeDeleted);
            context.SaveChanges();
        }

        public void AddMovie(Genre genre, string movieName, List<Theatre> choseTheatreslist)
        {
            Movie movie = new Movie();
            List<MovieTheatreInfo> movieTheatreInfos = new List<MovieTheatreInfo>();

            foreach (var theatre in choseTheatreslist)
            {
                var movieTheatreInfo = new MovieTheatreInfo();
                movieTheatreInfo.Theatre = theatre;
                movieTheatreInfos.Add(movieTheatreInfo);
            }

            movie.Genre = genre;
            movie.Name = movieName;
            movie.MovieTheatreInfo = movieTheatreInfos;

            context.Movie.Add(movie);
            context.SaveChanges();
        }

        public List<Movie> GetMoviesList()
        {
            var movies = context.Movie.ToList();
            return movies;
        }

        public List<TheatreSeatInfo> GetTheatreSeatinfos()
        {
            var theatreSeatinfos = context.TheatreSeatInfo.Include(t => t.Theatre).Include(s => s.SeatType).ToList();
            return theatreSeatinfos;
        }

        public MovieData GetMovieData()
        {
            var movieData = new MovieData();
            movieData.Genres = context.Genre.ToList();
            movieData.Theatres = context.Theatre.ToList();
            return movieData;
        }
    }
}
