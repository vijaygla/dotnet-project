using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeWage
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; };
        public int EmployeeSalary { get; set; }

        public override string ToString()
        {
            return $"Employee ID: {EmployeeId}, Name: {EmployeeName}, Salary: {EmployeeSalary}";
        }
    }
}
