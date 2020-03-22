using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMyShowApp
{
    class UserRole
    {
        public void UserDBOperation()
        {
            Console.WriteLine("What operation you want to perform");
            Console.WriteLine("1. To Register");
            Console.WriteLine("2. To Book ticket");


            var choosenOption = Console.ReadLine();

            using (BookMyShowContext context = new BookMyShowContext())
            {
                switch (choosenOption)
                {
                    case "1":
                        {
                            Register(context);
                            break;
                        }
                    case "2":
                        {
                            BookTicket(context);
                            break;
                        }
                }
            }
        }

        private void Register(BookMyShowContext context)
        {
            User user = new User();
            Address address = new Address();
            Console.WriteLine("Enter name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter password");
            var password = Console.ReadLine();
            Console.WriteLine("Enter Date of birth");
            var dob = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter email");
            var email = Console.ReadLine();
            Console.WriteLine("Enter phone");
            var phone = Console.ReadLine();
            Console.WriteLine("enter gender");
            var gender = Console.ReadLine();
            Console.WriteLine("Choose the role. If User enter 1. If Admin enter 2");
            var option = Console.ReadLine();
            bool role;
            if (option == "1")
                role = true;
            else
                role = false;

            Console.WriteLine("Enter city");
            var city = Console.ReadLine();
            Console.WriteLine("Enter state");
            var state = Console.ReadLine();
            Console.WriteLine("Enter pincode");
            var pincode = Convert.ToInt32(Console.ReadLine());

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

        private void BookTicket(BookMyShowContext context)
        {
            var booking = new Booking();
            Console.WriteLine("Enter user name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter password");
            var password = Console.ReadLine();
            var user = context.User.FirstOrDefault(u => u.Name == name && u.Password == password);

            if (user!=null)
            {
                Console.WriteLine("Enter movie id from the below list");
                var movies = context.Movie.ToList();
                movies.ForEach(x => Console.WriteLine(x.ID + " : " + x.Name));
                var choosenMovieId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter theatre id from the list for the movie");

                var theatres = context.MovieTheatreInfo.Where(mti => mti.MovieId == choosenMovieId)
                                                     .Include(mti => mti.Movie)
                                                     .Include(mti => mti.Theatre).ToList();
                theatres.ForEach(x => Console.WriteLine(x.Movie.Name + " : " + x.Theatre.Name + " : " + x.TheatreId));
               
                var choosenTheatreId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Choose show time from the list");
                for(int i=0;i<4;i++)
                {
                    Console.WriteLine(i + 1 + " : "+ Enum.GetName(typeof(ShowTime), i));
                }
                var showTime = Convert.ToInt32(Console.ReadLine()) - 1;

                Console.WriteLine("Enter seat type from the list");
                var theatreSeatInfo = context.TheatreSeatInfo.Include(x=>x.SeatType).Where(x => x.TheatreId == choosenTheatreId).ToList();
                theatreSeatInfo.ForEach(x => Console.WriteLine(x.Theatre.Name + " : " + x.SeatType.Type+" : "+x.SeatTypeId+" : "+x.Price));
                var choosenSeatType = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter number of seats to book");
                var numberOfSeat = Convert.ToInt32(Console.ReadLine());
                var bookedSeatDetails = new List<BookedSeatDetail>();

                

                var tolalSeats = context.TheatreSeatInfo.FirstOrDefault(t => t.TheatreId == 1 && t.SeatTypeId == 1).NumberOfSeats;

                var bookedSeatList = context.Booking.Include(b => b.BookedSeatList)
                                              .Where(b => b.TheatreId == choosenTheatreId && b.MovieId == choosenMovieId && b.SeatTypeId == choosenSeatType && b.ShowTime == (ShowTime)showTime)
                                              .SelectMany(b => b.BookedSeatList)
                                              .Select(bsl => bsl.SeatNumber).ToList();


                var unbookedSeatList = new List<int>();
                Console.WriteLine("Enter the seat number from the list");
                for (var i = 1; i <= tolalSeats; i++)
                {
                    if (!bookedSeatList.Contains(i))
                    {
                        Console.WriteLine(i);
                        unbookedSeatList.Add(i);
                    }
                }


                for (int i = 1; i <= numberOfSeat; i++)
                {
                    var seatNum = Convert.ToInt32(Console.ReadLine());
                    if (unbookedSeatList.Contains(seatNum))
                    {
                        var bookedSeatDetail = new BookedSeatDetail() { SeatNumber = seatNum }; 
                        bookedSeatDetails.Add(bookedSeatDetail);
                    }
                }

                booking.UserId = user.ID;
                booking.TheatreId = choosenTheatreId;
                booking.MovieId = choosenMovieId;
                booking.ShowTime = (ShowTime)showTime;
                booking.NumberOfBookedSeat = numberOfSeat;
                booking.SeatTypeId = choosenSeatType;
                var seatPrice = context.TheatreSeatInfo.FirstOrDefault(t => t.TheatreId == choosenTheatreId).Price;
                booking.TotalBookingPrice = seatPrice * numberOfSeat;
                booking.BookingDate = DateTime.Today;
                booking.BookedSeatList = bookedSeatDetails;

                context.Booking.Add(booking);
                context.SaveChanges();
            }

            
        }
    }
}
