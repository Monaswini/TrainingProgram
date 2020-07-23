using System;

namespace FindPower
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter base value and power value");
            var number = Convert.ToInt32(Console.ReadLine());
            var power= Convert.ToInt32(Console.ReadLine());
            var result = FindPower(number, power);
            Console.WriteLine(result);
        }

        private static int FindPower(int number, int power)
        {
            if (power == 0)
                return 1;
            return number * FindPower(number, power - 1);
        }
    }
}
