using System;

namespace Excel
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var columnValue = GetColumnValueFromExcelRow(input.ToUpper());
            Console.WriteLine($"Value of : {input} is {columnValue}");
        }
        private static int GetColumnValueFromExcelRow(string input)
        {
            //XYZ
            var charArray = input.ToCharArray();
            int result = 0;
            for (int i = charArray.Length; i > 0; i--)
            {
                var character = charArray[i-1];
                var alphaValue = (byte)character-64;
                result = result + (int)Math.Pow(26, charArray.Length - i) * alphaValue;
            }
            return result;
        }
    }
}
