using System;

namespace Addition
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two numbers to add");
            var firstInput = Convert.ToInt32(Console.ReadLine());
            var secondInput = Convert.ToInt32(Console.ReadLine());
            var sum = firstInput + secondInput;
            Console.WriteLine("Sum of {0} and {1} is {2}", firstInput, secondInput, sum);
        }
    }
}
