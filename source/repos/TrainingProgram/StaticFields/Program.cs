using System;

namespace StaticFields
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            Console.WriteLine(User.id);
            User user1 = new User();
            Console.WriteLine(User.id);
        }
    }
}
