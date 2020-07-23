using System;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the length of the array");
            var length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter some numbers to the array");
            var input = new int[length];
            for (var j = 0; j < length; j++)
                input[j] = Convert.ToInt32(Console.ReadLine());
            GetSorted(input);
            Console.WriteLine("the sorted array is :");
            for (var i = 0; i < input.Length; i++)
            {
                Console.Write(input[i] + " ");
            }
        }

        private static void GetSorted(int[] input)
        {
            int n = input.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = input[i];
                int j = i - 1;

                while (j >= 0 && input[j] > key)
                {
                    input[j + 1] = input[j];
                    j = j - 1;
                }
                input[j + 1] = key;
            }
        }
    }
}
