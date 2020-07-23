using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeList
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = new List<Employee>()
            {
                new Employee("vinay",101,new Address("hyd","Telengana")),
                new Employee("hari",102,new Address("blr","Karnataka")),
                new Employee("adiga",103,new Address("secunderabad","Telengana"))
            };

            SearchEmployeeByName(employeeList);
            string employeeInTelengana = SearchEmployeeInTelengana(employeeList);
            Console.WriteLine(employeeInTelengana);
        }

        public static List<Employee> SearchEmployeeByName(List<Employee> employeeList)
        {
            return employeeList.Where(e => e.Name.ToLower().StartsWith("v")).ToList();
            //foreach (var emp in employeeList)
            //{
            //    if (emp.Name.StartsWith("v"))
            //    {
            //        Console.WriteLine(emp.Name);
            //    }
            //}
        }
        private static string SearchEmployeeInTelengana(List<Employee> employeeList)
        {
            foreach (var emp in employeeList)
            {
                if (emp.Address.state.Equals("Telengana") && emp.Address.city.Equals("hyd"))
                    return emp.Name;
                else
                    return "not found";
            }
            return "";
        }
    }
}
