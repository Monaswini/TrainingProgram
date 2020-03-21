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
            Console.WriteLine("1. To book ticket");
           
            var choosenOption = Console.ReadLine();

            using (BookMyShowContext context = new BookMyShowContext())
            {
                switch (choosenOption)
                {
                    case "1":
                        {
                            BookTicket(context);
                            break;
                        }
                }
            }
        }

        private void BookTicket(BookMyShowContext context)
        {
            var bookedSeatDetail1 = new BookedSeatDetail();
            var bookedSeatDetail2 = new BookedSeatDetail();
            var booking = new Booking();
            booking.UserId = 1;
            booking.ShowTime=ShowTime.evening;
            booking.TheatreId  = 1;
            booking.MovieId = 1;
            booking.NumberOfBookedSeat = 2;
            booking.SeatTypeId = 1;
            var seatPrice = context.TheatreSeatInfo.FirstOrDefault(t=>t.TheatreId==1).Price;
            booking.TotalBookingPrice = seatPrice * 2;
            booking.BookingDate = DateTime.Today;
            
            bookedSeatDetail1.SeatNumber = 5;
            bookedSeatDetail2.SeatNumber = 6;
            
            var bookedSeatDetails = new List<BookedSeatDetail>();
            bookedSeatDetails.Add(bookedSeatDetail1);
            bookedSeatDetails.Add(bookedSeatDetail2);

            booking.BookedSeatList = bookedSeatDetails;
            context.Booking.Add(booking);
            context.SaveChanges();
        }
    }
}
