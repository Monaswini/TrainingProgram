using System;

namespace FibonacciSeries
{
    class Program
    {
        static void Main(string[] args)
        {
			int input;
			int[] fibonacciSeries;
			Console.WriteLine("enter a number to find fibonacci series");
			try
			{
				input = Convert.ToInt32(Console.ReadLine());
				fibonacciSeries = new int[input];
				fibonacciSeries=GetFibonacciSeries(input);
				for(var num=0;num<input;num++)
				{
					Console.Write(fibonacciSeries[num] + " ");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		private static int[] GetFibonacciSeries(int number)
		{
			var result=new int[number];
			result[0] = 0;
			result[1] = 1;
			for (var i = 2; i < number; i++)
			{
				result[i] = result[i - 1] + result[i-2];
			}
			return result;
		}
	}
}
