using System;

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
            if (role == "1")
                new AdminRole().AdminDBOperation();
            new UserRole().UserDBOperation();
        }
    }
}
