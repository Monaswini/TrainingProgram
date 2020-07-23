using System;
using System.Collections;

namespace StackFunctionalities
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Stack stack = new Stack();
            var i = 0;
            for(;i<input.Length;i++)
            {
                if (input[i] == '(')
                    stack.Push(input[i]);
                if (input[i] == ')')
                {
                    if (stack.Count == 0) break;
                    stack.Pop();
                }
            }
            if(stack.Count == 0 && i == input.Length)
            {
                Console.WriteLine("balanced");
            }
            else
                Console.WriteLine("unbalanced");
        }
    }
}
