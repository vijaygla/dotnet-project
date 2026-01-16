using System;

namespace ConsoleApp
{
    public class EmployeeManagement
    {
        public void AcceptEmployeeDetails(Employee employee)
        {
            Console.Write("Enter Employee Number: ");
            employee.EmpNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Employee Name: ");
            employee.EmpName = Console.ReadLine();

            Console.Write("Enter Basic Salary: ");
            employee.Salary = Convert.ToDouble(Console.ReadLine());

            employee.CalculateSalary();
        }
    }
}
