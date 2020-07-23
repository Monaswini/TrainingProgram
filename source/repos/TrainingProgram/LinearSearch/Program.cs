using System;

namespace LinearSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 23, 45, 10, 75, 34, 81 };
            Console.WriteLine("enter a number to search in the arrray");
            var input = Convert.ToInt32(Console.ReadLine());
            // Console.WriteLine(if(Search(input,numbers)));
            if (Search(input, numbers))
                Console.WriteLine(input + "found in the array");
            else
                Console.WriteLine(input + "not found in the array");
        }

        private static bool Search(int input, int[] numbers)
        {
            for (var i = 0; i < numbers.Length; i++)
            {
                if (input == numbers[i])
                    return true;
            }
            return false;
        }
    }
}
