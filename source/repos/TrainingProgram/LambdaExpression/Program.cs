using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaExpression
{
    interface A
    {
        public void show();
    }
    class Abc : A
    {
        public void show()
        {
            Console.WriteLine("Hello");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            A obj = new Abc();
            obj.show();

            var x = new List<string>() { "2", "6", "8", "4", "9", "5" };
            var list = x.Where(x => x != "5");
            foreach (var n in list)
            {
                Console.WriteLine(n);
            }

            var output = x.FirstOrDefault(x => x == "9");
            Console.WriteLine(output);
            Func<int, int> result = (x) => x * x;
            Console.WriteLine(result(6));
        }
    }
}
