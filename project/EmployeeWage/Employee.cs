using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeWage
{
    internal class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeSalary { get; set; }

        public override string ToString()
        {
            return "Employee ID: " + EmployeeId +
                   "\nEmployee Name: " + EmployeeName +
                   "\nEmployee Salary: " + EmployeeSalary;
        }
    }
}
