using EmployeeList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestForEmployeeList
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SearchEmployeeByName_EmployeeExists()
        {
            var employees = new List<Employee>()
            {
                new Employee("Vinay",0,null),
                new Employee("Vishal",1,null)
            };


            var result = Program.SearchEmployeeByName(employees);
            Assert.AreEqual(2, result.Count);
        }
    }
}
