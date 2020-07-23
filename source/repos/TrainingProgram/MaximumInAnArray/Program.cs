using System;

namespace MaximumInAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter length of an Array");
            try
            {
                var length = Convert.ToInt32(Console.ReadLine());
                var numbers = new int[length];
                Console.WriteLine("enter {0} numbers into the Array",length);
                for(var i=0;i<length;i++)
                {
                    numbers[i]= Convert.ToInt32(Console.ReadLine());
                }
                var maxNumber = FindMaximumNumber(numbers);
                Console.WriteLine("The max number in the array :"+maxNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static int FindMaximumNumber(int[] numbers)
        {
            var max = numbers[0];
            for(var i=1;i<numbers.Length;i++)
            {
                if (max < numbers[i])
                    max = numbers[i];
            }
            return max;
        }
    }
}
