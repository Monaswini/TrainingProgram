using System;

namespace MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int input;
            Console.WriteLine("Enter a number to find its multiplication table");
            int.TryParse(Console.ReadLine(), out input);
            for (var i = 1; i <= 10; i++)
            {
                Console.WriteLine(i+" * "+input+" = "+i*input);
            }

            Console.Read();
        }
    }
}
