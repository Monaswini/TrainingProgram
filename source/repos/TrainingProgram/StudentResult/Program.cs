using System;
using System.Collections.Generic;

namespace StudentResult
{
    class Program
    {
        static void Main(string[] args)
        {
            // var grades = new List<char> { 'B', 'O', 'E', 'A' };
            var grades = new char[] { 'B', 'E', 'O', 'A'};
            var standard = GetStandard(grades);
            Console.WriteLine(standard);
        }

        private static object GetStandard(char[] grades)
        {
            string result = "";
            var i = 0;

            while (i != grades.Length)
            {
                if (grades[i] == ('F'))
                {
                    return "Bad";
                }
                i++;
            }
            for (var j = 0; j < grades.Length; j++)
            {
                if (grades[j] == ('O'))
                {
                    result = "Outstanding";
                    break;
                }
                else if (grades[j] == ('E'))
                {
                    result = "Execelent";
                    break;
                }
                else if (grades[j] == ('A'))
                {
                    result = "Good";
                    break;
                }
                else
                    result = "Average";
            }
            return result;
        }

        private static string GetStandard1(char[] grades)
        {
            for (var j = 0; j < grades.Length; j++)
            {
                if (grades[j] == 'F')
                    return "Bad";
                if (grades[j] == 'O')
                    return "Outstanding";
                if (grades[j] == 'E')
                    return "Execelent";
                if (grades[j] == 'A')
                    return "Good";
            }

            return "Average";
        }
    }


    
}


