using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShow.Application
{
    class BookMyShowContext : DbContext
    {
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Theatre> Theatre { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<TheatreSeatInfo> TheatreSeatInfo { get; set; }
        public DbSet<SeatType> SeatType { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<BookedSeatDetail> BookedSeatDetail { get; set; }
        public DbSet<MovieTheatreInfo> MovieTheatreInfo { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-L01MDJK\SQLEXPRESS;Database=BookMyShowDatabase;Trusted_Connection=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SeatType>().HasData(
                                                    new SeatType { ID=1,Type="Gold"},
                                                    new SeatType { ID = 2,Type = "Platinum"});

            //modelBuilder.Entity<TheatreSeatInfo>().HasData(

            //                                    new TheatreSeatInfo { ID = 1, TheatreId = 1, SeatTypeId = 1, Price = 40, NumberOfSeats = 20 },
            //                                    new TheatreSeatInfo { ID = 2, TheatreId = 1, SeatTypeId = 2, Price = 60, NumberOfSeats = 30 },
            //                                    new TheatreSeatInfo { ID = 3, TheatreId = 2, SeatTypeId = 1, Price = 50, NumberOfSeats = 50 },
            //                                    new TheatreSeatInfo { ID = 4, TheatreId = 2, SeatTypeId = 2, Price = 70, NumberOfSeats = 50 },
            //                                    new TheatreSeatInfo { ID = 5, TheatreId = 3, SeatTypeId = 1, Price = 45, NumberOfSeats = 60 },
            //                                    new TheatreSeatInfo { ID = 6, TheatreId = 3, SeatTypeId = 2, Price = 75, NumberOfSeats = 70 },
            //                                    new TheatreSeatInfo { ID = 7, TheatreId = 4, SeatTypeId = 2, Price = 120, NumberOfSeats = 100 }
            //                                    );

        }
    }
}
