using System;

namespace FindNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter a number");
            var input = Convert.ToInt32(Console.ReadLine());
            var sum = 0;
            var count = 0;
            for (var i = 1; i <= input; i++)
            {
                if ((i % 3 == 0) || (i % 5 == 0))
                {
                    sum = sum + i;
                }
                else
                {
                    count++;
                }
            }
            Console.WriteLine(sum);
            Console.WriteLine(count);
        }
    }
}
