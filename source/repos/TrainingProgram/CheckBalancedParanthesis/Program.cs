using System;
using System.Collections.Generic;

namespace CheckBalancedParanthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var result = IsBalanced(input);
            if (result)
                Console.WriteLine("balanced");
            else
                Console.WriteLine("unbalanced");
        }
        private static bool IsBalanced(string input)
        {
            Stack<char> stack = new Stack<char>();
            char top;
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == '<' || input[i] == '{' || input[i] == '[')
                    stack.Push(input[i]);
                else if (stack.Count != 0)
                {
                    if (input[i] == ')' || input[i] == '>' || input[i] == '}' || input[i] == ']')
                    {
                        return false;
                    }

                    top = stack.Pop();
                    if ((top == '(' && input[i] == ')') || (top == '{' && input[i] == '}') || (top == '[' && input[i] == ']') || (top == '<' && input[i] == '>'))
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
            return false;
        }

    }
}

            //for(var i=0;i<input.Length;i++)
            //{
            //    if (input[i] == '(' || input[i] == '{' || input[i] == '['||input[i] == ')' || input[i] == '}' || input[i] == ']')
            //    {
            //        if (input[i] == '(' || input[i] == '{' || input[i] == '[')
            //        {
            //            stack.Push(input[i]);
            //        }
            //        else
            //        {

            //            if (stack.Count == 0)
            //            {
            //                return false;
            //            }
                       
            //            top = stack.Pop();

            //            if ((top == '(' && input[i] != ')') || (top == '{' && input[i] != '}'))
            //                return false;
            //            if (stack.Count == 0)
            //                return true;
            //        }
            //    }
            //}
            //return false;
      

