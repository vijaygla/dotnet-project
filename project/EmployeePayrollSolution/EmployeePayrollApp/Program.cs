using System;
using System.Collections.Generic;
using EmployeePayrollLibrary.Models;
using EmployeePayrollLibrary.Services;

namespace EmployeePayrollApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<EmployeeDetails> employees = GetSampleEmployees();

            EmployeePayrollService service = new EmployeePayrollService();

            Console.WriteLine("=== UC1: Add employees without threads ===");
            TimeSpan durationNoThread = service.AddEmployeesToPayroll(employees);
            Console.WriteLine("Duration without thread: " + durationNoThread);

            Console.WriteLine();
            Console.WriteLine("=== UC2–UC4: Add employees with threads ===");
            TimeSpan durationWithThread = service.AddEmployeesToPayrollWithThreads(employees);
            Console.WriteLine("Duration with thread: " + durationWithThread);

            Console.WriteLine();
            Console.WriteLine("Employee count in memory: " + service.EmployeeCount());

            EmployeePayrollThreadService internalThreadService = new EmployeePayrollThreadService();
            Console.WriteLine();
            Console.WriteLine("=== UC5: Add employees using internal DB threads ===");
            TimeSpan durationInternalThreads = internalThreadService.AddEmployeesToPayrollUsingInternalThreads(employees);
            Console.WriteLine("Duration with internal DB threads: " + durationInternalThreads);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static List<EmployeeDetails> GetSampleEmployees()
        {
            List<EmployeeDetails> list = new List<EmployeeDetails>();

            for (int i = 1; i <= 10; i++)
            {
                EmployeeDetails emp = new EmployeeDetails();
                emp.EmployeeName = "Emp" + i;
                emp.PhoneNumber = "999999999" + (i % 10);
                emp.Address = "Some Address " + i;
                emp.Department = "Dept" + (i % 3);
                emp.BasicPay = 30000 + (i * 1000);
                emp.Deductions = 1000;
                emp.TaxablePay = emp.BasicPay - emp.Deductions;
                emp.IncomeTax = emp.TaxablePay * 0.1m;
                emp.NetPay = emp.TaxablePay - emp.IncomeTax;
                emp.StartDate = DateTime.Now.Date;
                list.Add(emp);
            }

            return list;
        }
    }
}
