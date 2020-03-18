using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowApp
{
    class BookMyShowContext : DbContext
    {
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Theatre> Theatre { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<TheatreSeatInfo> TheatreSeatInfo { get; set; }
        public DbSet<Seat> Seat { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<MovieTheatreInfo> MovieTheatreInfo { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-L01MDJK\SQLEXPRESS;Database=BookMyShowDatabase;Trusted_Connection=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
