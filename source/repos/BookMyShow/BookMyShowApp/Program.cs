using BookMyShow.Application;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookMyShowApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose your role");
            Console.WriteLine("Enter 1 for Admin");
            Console.WriteLine("Enter 2 for User");
            var role = Console.ReadLine();

            // implement in switch case 
            switch (role)
            {
                case "1":
                    {
                        //select menu options
                        Console.WriteLine("What operation you want to perform");
                        Console.WriteLine("1. To add Movie");
                        Console.WriteLine("2. To remove Movie");
                        Console.WriteLine("3. To see the movies running in theatres");
                        Console.WriteLine("4. To change the price of the Ticket");
                        var choseOption = Console.ReadLine();
                        switch (choseOption)
                        {
                            case "1":
                                {
                                    AddMovie();
                                    break;
                                }
                            case "2":
                                {
                                    RemoveMovie();
                                    break;
                                }
                            case "3":
                                {
                                    new AdminRole().ShowMoviesInTheatres();
                                    break;
                                }
                            case "4":
                                {
                                    ChangeTicketPrice();
                                    break;
                                }
                        }
                        break;
                    }

                case "2":
                    {
                        Console.WriteLine("What operation you want to perform");
                        Console.WriteLine("1. To Register");
                        Console.WriteLine("2. To Book ticket");
                        var choseOption = Console.ReadLine();
                        switch(choseOption)
                        {
                            case "1":
                                {
                                    Register();
                                    break;
                                }
                            case "2":
                                {
                                    BookTicket();
                                    break;
                                }
                        }
                        //new UserRole().UserDBOperation();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid");
                        return;
                    }
            }
        }
        private static void BookTicket()
        {
            var userRole = new UserRole();
            Console.WriteLine("Enter user name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter password");
            var password = Console.ReadLine();
            var isValidUser = userRole.IsValidUser(name,password);
            if(isValidUser)
            {
                Console.WriteLine("Enter movie id from the below list");
                var movies = userRole.GetMoviesList();
                movies.ForEach(x => Console.WriteLine(x.ID + " : " + x.Name));
                var choseMovieId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter theatre id where you want to see the movie from the available list");
                var movieInTeatresInfo = userRole.GetMovieInTeatresInfo(choseMovieId);
                movieInTeatresInfo.ForEach(x => Console.WriteLine(x.Movie.Name + " : " + x.Theatre.Name + " : " + x.TheatreId));

                var choseTheatreId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Choose show time from the list");
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine(i + 1 + " : " + Enum.GetName(typeof(ShowTime), i));
                }
                var showTime = Convert.ToInt32(Console.ReadLine()) - 1;

                Console.WriteLine("Enter seatTypeId from the list");
                var theatreSeatInfo = userRole.GetTheatreSeatTypeList(choseTheatreId);
                theatreSeatInfo.ForEach(x => Console.WriteLine(x.Theatre.Name + " : " + x.SeatType.Type + " : " + x.SeatTypeId + " : " + x.Price));
                var choseSeatTypeId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter number of seats to book");
                var numberOfSeat = Convert.ToInt32(Console.ReadLine());
               
                var availableSeatList = userRole.GetAvailableSeatList(choseMovieId, choseTheatreId, showTime, choseSeatTypeId);
                Console.WriteLine("Displaying the available seats");
                foreach(var seatNum in availableSeatList)
                {
                    Console.WriteLine(seatNum+" ");
                }

                var bookedSeatDetails = new List<BookedSeatDetail>();
                for (int i = 1; i <= numberOfSeat; i++)
                {
                    Console.WriteLine("Enter seat number");
                    var seatNum = Convert.ToInt32(Console.ReadLine());
                    if (availableSeatList.Contains(seatNum))
                    {
                        var bookedSeatDetail = new BookedSeatDetail() { SeatNumber = seatNum };
                        bookedSeatDetails.Add(bookedSeatDetail);
                    }
                }
                userRole.BookTicket(name, password, choseMovieId, choseTheatreId, showTime, choseSeatTypeId, numberOfSeat, bookedSeatDetails);
                Console.WriteLine("Ticket booked");
                return;
            }
                Console.WriteLine("Not a valid user");
        }

        private static void Register()
        {
            var userRole = new UserRole();
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
            userRole.Register(user);
        }

        private static void ChangeTicketPrice()
        {
            AdminRole adminRole = new AdminRole();
            var theatreSeatinfos = adminRole.GetTheatreSeatinfos();
            Console.WriteLine("Enter the theatreId for which you want to change the ticket price from the below list of theatres");
            foreach (var t in theatreSeatinfos)
                Console.WriteLine(t.TheatreId + " : " + t.Theatre.Name + " ==>  " + t.SeatTypeId + " : " + t.SeatType.Type + " : " + t.Price);
            var theatreId = Convert.ToInt32(Console.ReadLine());
            if (theatreSeatinfos.FirstOrDefault(x => x.TheatreId.Equals(theatreId)) == null)
            {
                Console.WriteLine("Theatre is not present");
                return;
            }

            Console.WriteLine("Enter the seatTypeId");
            var seatTypeId = Convert.ToInt32(Console.ReadLine());
            if (theatreSeatinfos.FirstOrDefault(x => x.SeatTypeId.Equals(seatTypeId)) == null)
            {
                Console.WriteLine("SeatType is not present");
                return;
            }
            Console.WriteLine("Enter the change price");
            var changedPrice = Convert.ToInt32(Console.ReadLine());
            adminRole.ChangeTicketPrice(theatreId, seatTypeId, changedPrice);
        }

        private static void RemoveMovie()
        {
            AdminRole adminRole = new AdminRole();
            var movies = adminRole.GetMoviesList();
            movies.ForEach(x => Console.WriteLine(x.ID + " : " + x.Name));
            Console.WriteLine("Enter the movieId you want to remove");
            var selectedMovieId = Convert.ToInt32(Console.ReadLine());
            var movieTobeDeleted = movies.FirstOrDefault(x => x.ID.Equals(selectedMovieId));
            if (movieTobeDeleted == null)
            {
                Console.WriteLine("Not present in the list");
                return;
            }
            adminRole.RemoveMovie(movieTobeDeleted);

        }

        private static void AddMovie()
        {
            AdminRole adminRole = new AdminRole();

            //call the method and get all the genres and thetres data and store it in a variable
            var movieData = adminRole.GetMovieData();
            var genres = movieData.Genres;
            //show all the genres
            genres.ForEach(x => Console.WriteLine(x.ID + " : " + x.Name));
            //take a genre id as input from user 
            Console.WriteLine("Select GenreId for your movie");
            var choseGenre = Convert.ToInt32(Console.ReadLine());

            var genre = genres.FirstOrDefault(x => x.ID.Equals(choseGenre));

            if (genre == null)
            {
                Console.WriteLine("Select correct Genre.");
                return;
            }

            Console.WriteLine("Enter movie name");
            var movieName = Console.ReadLine();

            var theatres = movieData.Theatres;
            theatres.ForEach(x => Console.WriteLine(x.ID + " : " + x.Name));
            Console.WriteLine("Enter the no of the Theatres to be choosen");
            //take a theatre from user
            var noOfTheatre = Convert.ToInt32(Console.ReadLine());
            if (noOfTheatre > theatres.Count())
            {
                Console.WriteLine("Exceeds maximum. Try again..");
                return;
            }

            List<Theatre> choseTheatreslist = new List<Theatre>();

            int j = 1;
            while (j <= noOfTheatre)
            {
                Console.WriteLine("Enter your choice");
                int id = Convert.ToInt32(Console.ReadLine());
                choseTheatreslist.Add(theatres[--id]);
                j++;
            }
            //take the movie as input from user
            adminRole.AddMovie(genre, movieName, choseTheatreslist);
        }
    }
}

