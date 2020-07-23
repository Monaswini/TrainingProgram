using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeList
{
    public class Employee
    {
        public string Name;
        public string FirstName { get;  }
        public int Id;
        public Address Address;
        public Employee(string name,int id,Address address)
        {
            Name = name;
            Id = id;
            Address = address;
        }
    }
}
