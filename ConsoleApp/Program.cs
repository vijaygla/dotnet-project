using System;
using ConsoleApp;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            EmployeeManagement employeeManagement = new EmployeeManagement();

            employeeManagement.AcceptEmployeeDetails(employee);
            employee.DisplayEmployeeDetails();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
