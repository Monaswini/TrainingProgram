using System;
using System.Collections.Generic;
using System.Text;

namespace StaticFields
{
    class User
    {
        public static int id=0;
        public User()
        {
            Console.WriteLine(id);
            id++;
        }
    }
}
