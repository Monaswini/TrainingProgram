using BookMyShow.Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMyShow.Application
{
    public class UserRole
    {
        BookMyShowContext context = new BookMyShowContext();
        public void Register(string name, string password, string email, DateTime dob, string phone, string gender, bool role, string city, string state, int pincode)
        {
            User user = new User();
            Address address = new Address();
            address.City = city;
            address.State = state;
            address.PinCode = pincode;

            user.Name = name;
            user.Password = password;
            user.Email = email;
            user.DOB = dob;
            user.Phone = phone;
            user.Gender = gender;
            user.IsUser = role;
            user.Address = address;
            
            context.User.Add(user);
            context.SaveChanges();
        }

        public void BookTicket(string name, string password, int choseMovieId, int choseTheatreId, int showTime, int choseSeatTypeId, int numberOfSeat, List<BookedSeatDetail> bookedSeatDetails)
        {
            var booking = new Booking();

            booking.UserId = context.User.FirstOrDefault(u => u.Name == name && u.Password == password).ID;
            booking.TheatreId = choseTheatreId;
            booking.MovieId = choseMovieId;
            booking.ShowTime = (ShowTime)showTime;
            booking.NumberOfBookedSeat = numberOfSeat;
            booking.SeatTypeId = choseSeatTypeId;
            var seatPrice = context.TheatreSeatInfo.FirstOrDefault(t => t.TheatreId == choseTheatreId && t.SeatTypeId == choseSeatTypeId).Price;
            booking.TotalBookingPrice = seatPrice * numberOfSeat;
            booking.BookingDate = DateTime.Today;
            booking.BookedSeatList = bookedSeatDetails;

            context.Booking.Add(booking);
            context.SaveChanges();
        }

        public List<TheatreSeatInfo> GetTheatreSeatTypeList(int choseTheatreId)
        {
            var theatreSeatInfo = context.TheatreSeatInfo.Include(x => x.SeatType)
                                                         .Where(x => x.TheatreId == choseTheatreId).ToList();
            return theatreSeatInfo;
        }

        public List<int> GetAvailableSeatList(int choseMovieId, int choseTheatreId, int showTime, int choseSeatTypeId)
        {
            var tolalSeats = context.TheatreSeatInfo.FirstOrDefault(t => t.TheatreId == 1 && t.SeatTypeId == 1).NumberOfSeats;

            var bookedSeatList = context.Booking.Include(b => b.BookedSeatList)
                                              .Where(b => b.TheatreId == choseTheatreId && b.MovieId == choseMovieId && b.SeatTypeId == choseSeatTypeId && b.ShowTime == (ShowTime)showTime)
                                              .SelectMany(b => b.BookedSeatList)
                                              .Select(bsl => bsl.SeatNumber).ToList();
            var unBookedSeatList = new List<int>();
            for (var i = 1; i <= tolalSeats; i++)
            {
                if (!bookedSeatList.Contains(i))
                {
                    unBookedSeatList.Add(i);
                }
            }

            return unBookedSeatList;
        }

        public List<MovieTheatreInfo> GetMovieInTeatresInfo(int choseMovieId)
        {
            var theatres = context.MovieTheatreInfo.Where(mti => mti.MovieId == choseMovieId)
                                                      .Include(mti => mti.Movie)
                                                      .Include(mti => mti.Theatre).ToList();
            return theatres;
        }

        public List<Movie> GetMoviesList()
        {
            var movies = context.Movie.ToList();
            return movies;
        }

        public bool IsValidUser(string name, string password)
        {
            var user = context.User.FirstOrDefault(u => u.Name == name && u.Password == password);
            if (user != null)
                return true;
            return false;
        }

    }
}
