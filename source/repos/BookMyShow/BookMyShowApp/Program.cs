using System;

namespace BookMyShowApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBaseOperation dataBaseOperation = new DataBaseOperation(); 
            Console.WriteLine("Choose your role");
            Console.WriteLine("Enter 1 for Admin");
            Console.WriteLine("Enter 2 for User");
            var role = Console.ReadLine();
            if (role == "1")
                dataBaseOperation.AdminDBOperation();
            dataBaseOperation.UserDBOperation();
        }
    }
}
