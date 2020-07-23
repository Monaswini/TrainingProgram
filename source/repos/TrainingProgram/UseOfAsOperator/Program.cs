using System;

namespace UseOfAsOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Dog();
            var dog = animal as Dog;
            //var dog = (Dog)animal;
            dog.Bark();
        }
    }
}
