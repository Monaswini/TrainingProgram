using System;

namespace GetSqureroot
{
    class Program
    {
        static void Main(string[] args)
        {
			
			Console.WriteLine("enter a number to find squre root");
			int sqrt=0;
			try
			{
				var input = Convert.ToInt32(Console.ReadLine());
				sqrt = FindSqureRoot(input);
				Console.WriteLine($"result {sqrt}");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Console.WriteLine(sqrt);
        }
		static int FindSqureRoot(int perfectSqureNumber)
		{
			int min = 0, max = perfectSqureNumber;
			int mid = (min + max) / 2;
			int result = 0;
			while(mid*mid!= perfectSqureNumber)
			{
				if(mid*mid> perfectSqureNumber)
				{
					
					max = mid;
					mid = (mid + min) / 2;
					
				}

				else
				{

					min = mid;
					mid = (max + mid) / 2;
					
				}
				result = mid;
			}
			return result;
		}
    }
}
