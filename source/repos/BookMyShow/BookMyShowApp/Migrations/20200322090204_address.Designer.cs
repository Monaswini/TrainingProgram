﻿// <auto-generated />
using System;
using BookMyShowApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookMyShowApp.Migrations
{
    [DbContext(typeof(BookMyShowContext))]
    [Migration("20200322090204_address")]
    partial class address
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookMyShowApp.Address", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PinCode")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("BookMyShowApp.BookedSeatDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BookingId");

                    b.ToTable("BookedSeatDetail");
                });

            modelBuilder.Entity("BookMyShowApp.Booking", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfBookedSeat")
                        .HasColumnType("int");

                    b.Property<int>("SeatTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ShowTime")
                        .HasColumnType("int");

                    b.Property<int>("TheatreId")
                        .HasColumnType("int");

                    b.Property<double>("TotalBookingPrice")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TheatreId");

                    b.HasIndex("UserId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("BookMyShowApp.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("BookMyShowApp.Movie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GenreID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("GenreID");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("BookMyShowApp.MovieTheatreInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("TheatreId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MovieId");

                    b.HasIndex("TheatreId");

                    b.ToTable("MovieTheatreInfo");
                });

            modelBuilder.Entity("BookMyShowApp.SeatType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("SeatType");
                });

            modelBuilder.Entity("BookMyShowApp.Theatre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Theatre");
                });

            modelBuilder.Entity("BookMyShowApp.TheatreSeatInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("SeatTypeId")
                        .HasColumnType("int");

                    b.Property<int>("TheatreId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SeatTypeId");

                    b.HasIndex("TheatreId");

                    b.ToTable("TheatreSeatInfo");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            NumberOfSeats = 20,
                            Price = 40,
                            SeatTypeId = 1,
                            TheatreId = 1
                        },
                        new
                        {
                            ID = 2,
                            NumberOfSeats = 30,
                            Price = 60,
                            SeatTypeId = 2,
                            TheatreId = 1
                        },
                        new
                        {
                            ID = 3,
                            NumberOfSeats = 50,
                            Price = 50,
                            SeatTypeId = 1,
                            TheatreId = 2
                        },
                        new
                        {
                            ID = 4,
                            NumberOfSeats = 50,
                            Price = 70,
                            SeatTypeId = 2,
                            TheatreId = 2
                        },
                        new
                        {
                            ID = 5,
                            NumberOfSeats = 60,
                            Price = 45,
                            SeatTypeId = 1,
                            TheatreId = 3
                        },
                        new
                        {
                            ID = 6,
                            NumberOfSeats = 70,
                            Price = 75,
                            SeatTypeId = 2,
                            TheatreId = 3
                        },
                        new
                        {
                            ID = 7,
                            NumberOfSeats = 100,
                            Price = 120,
                            SeatTypeId = 2,
                            TheatreId = 4
                        });
                });

            modelBuilder.Entity("BookMyShowApp.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsUser")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BookMyShowApp.Address", b =>
                {
                    b.HasOne("BookMyShowApp.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("BookMyShowApp.Address", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookMyShowApp.BookedSeatDetail", b =>
                {
                    b.HasOne("BookMyShowApp.Booking", "Booking")
                        .WithMany("BookedSeatList")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookMyShowApp.Booking", b =>
                {
                    b.HasOne("BookMyShowApp.Theatre", "Theatre")
                        .WithMany()
                        .HasForeignKey("TheatreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookMyShowApp.User", null)
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookMyShowApp.Movie", b =>
                {
                    b.HasOne("BookMyShowApp.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("GenreID");
                });

            modelBuilder.Entity("BookMyShowApp.MovieTheatreInfo", b =>
                {
                    b.HasOne("BookMyShowApp.Movie", "Movie")
                        .WithMany("MovieTheatreInfo")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookMyShowApp.Theatre", "Theatre")
                        .WithMany("MovieTheatreInfo")
                        .HasForeignKey("TheatreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookMyShowApp.TheatreSeatInfo", b =>
                {
                    b.HasOne("BookMyShowApp.SeatType", "SeatType")
                        .WithMany()
                        .HasForeignKey("SeatTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookMyShowApp.Theatre", "Theatre")
                        .WithMany("TheatreSeatInfos")
                        .HasForeignKey("TheatreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
