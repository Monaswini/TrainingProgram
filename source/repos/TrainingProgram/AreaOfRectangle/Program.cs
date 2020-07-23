using System;
namespace AreaOfShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            var rectangle = new Rectangle();
            Console.WriteLine("Enter length of the rectangle");
            rectangle.Length = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter length of the breath");
            rectangle.Breath = float.Parse(Console.ReadLine());
            
            Console.WriteLine("Area of rectangle : "+rectangle.AreaOfRectangle());

            var square = new Square();
            Console.WriteLine("Enter side of the square");
            square.Side = float.Parse(Console.ReadLine());

            Console.WriteLine("Area of Square : " + square.AreaOfSquare());

            var triangle = new Triangle();
            Console.WriteLine("Enter base of the triangle");
            triangle.Base = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter height of the triangle");
            triangle.Height = float.Parse(Console.ReadLine());

            Console.WriteLine("Area of Triangle : " + triangle.AreaOfTriangle());
        }
    }
}
