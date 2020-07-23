using System;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {

            var calculator = new Calculator<int>();
            Console.WriteLine("enter 2 numbers to add");
            var num1 =Convert.ToInt32( Console.ReadLine());
            var num2 = Convert.ToInt32(Console.ReadLine());
            var sum=calculator.GetSum(num1, num2);
            Console.WriteLine(sum);
        }
    }
}
