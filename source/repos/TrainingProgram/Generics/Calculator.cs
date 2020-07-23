using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class Calculator<T>
    {

        public T GetSum(T num1,T num2)
        {
            return num1 + num2;
        }
    }
}
