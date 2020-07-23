using System;
using System.Text.RegularExpressions;

namespace ValidationWithRegularExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            var pin = string.Empty;
            var mobile= string.Empty;
            var email = string.Empty;
            do
            {
                Console.WriteLine("Enter pin code (e.g 500084): ");
                pin = Console.ReadLine();
            } while (!IsValidPin(pin));

            Console.WriteLine("Your pin is Valid");

            do
            {
                Console.WriteLine("Enter mobile code (e.g +91-1234567890): ");
                mobile = Console.ReadLine();
            } while (!IsValidMobileNo(mobile));

            Console.WriteLine("Your mobile no. is Valid");

            do
            {
                Console.WriteLine("Enter email id (e.g text.text@gmail.com): ");
                email = Console.ReadLine();
            } while (!IsValidEmailId(email));

            Console.WriteLine("Your email is Valid");

        }
        private static bool IsValidPin(string pin)
        {
            var pinCodePattern = @"^\d{6}$";
            Regex regex = new Regex(pinCodePattern);
            return regex.IsMatch(pin);
        }
        private static bool IsValidMobileNo(string mobile)
        {
            var mobileNoPattern =  @"^([+][9][1][-])?\d{10}$";
            Regex regex = new Regex(mobileNoPattern);
            return regex.IsMatch(mobile);
        }

        private static bool IsValidEmailId(string email)
        {
            //var emailPattern = @"^[a-z0-9]+[.]?[a-z0-9]+@[a-z]+.com$";
            var emailPattern = @"^([a-z0-9]+[.])?[a-z0-9]+@[a-z]+.com$";
            Regex regex = new Regex(emailPattern);
            return regex.IsMatch(email);
        }
    }
}
