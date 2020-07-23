using System;

namespace SpeedCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the speed");
            var inputSpeed = Convert.ToInt32(Console.ReadLine());
            //if (inputSpeed <= 70)
            //{
            //    Console.WriteLine("Ok");
            //}
            //else
            //{
            //    var speed =inputSpeed - 70;
            //    Console.WriteLine("Your speed point is " + speed / 5);
            //}

            var result = inputSpeed <= 70 ? "Ok" : "Your speed point is " + (inputSpeed - 70) / 5;
            Console.WriteLine(result);
        }
    }
}
