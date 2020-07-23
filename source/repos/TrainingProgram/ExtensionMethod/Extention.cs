using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethod
{
    static class Extention
    {
        public static void M3(this Initial initial)
        {
            Console.WriteLine("M3 Extension method");
        }
    }
}
