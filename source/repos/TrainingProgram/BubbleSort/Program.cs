using System;

namespace BubbleSort
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
            for(var i=0;i<input.Length;i++)
            {
                for(var j=0;j<input.Length-i-1;j++)
                {
                    if(input[j]>input[j+1])
                    {
                        var temp = input[j];
                        input[j] = input[j+1];
                        input[j + 1] = temp;
                    }
                }
            }
        }
    }
}
