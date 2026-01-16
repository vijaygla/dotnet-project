using System;
using System.Collections.Generic;

namespace EmployeeWage
{
    internal class EmployeeUtilityImpl : IEmployee
    {

        public static List<Employee> Employees { get; private set; } = new List<Employee>();

        public void CheckAttendance()
        {
            Console.WriteLine("Welcome to Employee Wage Computation Program");
            Random random = new Random();
            int attendance = random.Next(0, 2);
            Console.WriteLine(attendance == 1 ? "Employee is Present" : "Employee is Absent");
        }

        public void CalculateDailyWage()
        {
            int dailyWage = Constants.WAGE_PER_HOUR * Constants.FULL_DAY_HOUR;
            Console.WriteLine($"Daily Employee Wage: {dailyWage}");
        }

        public void CalculatePartTimeWage()
        {
            int partTimeWage = Constants.WAGE_PER_HOUR * Constants.PART_TIME_HOUR;
            Console.WriteLine($"Part Time Employee Wage: {partTimeWage}");
        }

        public void CalculateWageUsingSwitch()
        {
            Random random = new Random();
            int empType = random.Next(0, 3);
            int totalWage = 0;

            switch (empType)
            {
                case Constants.EMPLOYEE_FULL_TIME:
                    totalWage = Constants.WAGE_PER_HOUR * Constants.FULL_DAY_HOUR;
                    Console.WriteLine($"Full Time Employee Wage: {totalWage}");
                    break;
                case Constants.EMPLOYEE_PART_TIME:
                    totalWage = Constants.WAGE_PER_HOUR * Constants.PART_TIME_HOUR;
                    Console.WriteLine($"Part Time Employee Wage: {totalWage}");
                    break;
                default:
                    Console.WriteLine("Employee is Absent");
                    break;
            }
        }

        public void CalculateMonthlyWage()
        {
            int monthlyWage = Constants.WAGE_PER_HOUR * Constants.FULL_DAY_HOUR * Constants.WORKING_DAYS_PER_MONTH;
            Console.WriteLine($"Monthly Employee Wage: {monthlyWage}");
        }

        public void CalculateWageTillCondition()
        {
            int totalHours = 0;
            int totalDays = 0;
            Random random = new Random();

            while (totalHours < Constants.MAX_WORKING_HOURS && totalDays < Constants.MAX_WORKING_DAYS)
            {
                totalDays++;
                int hoursWorked = random.Next(0, 2) == 1 ? Constants.FULL_DAY_HOUR : Constants.PART_TIME_HOUR;
                totalHours += hoursWorked;
            }

            int totalWage = totalHours * Constants.WAGE_PER_HOUR;
            Console.WriteLine($"Total Wage till condition reached: {totalWage}");
        }

        public Employee AddEmployee()
        {
            Employee emp = new Employee();
            Console.Write("Enter Employee Id: ");
            emp.EmployeeId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Employee Name: ");
            emp.EmployeeName = Console.ReadLine();
            Console.Write("Enter Employee Salary: ");
            emp.EmployeeSalary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEmployee added successfully:");
            Console.WriteLine(emp.ToString());
            Employees.Add(emp);  // Add to global list
            return emp;
        }
    }
}
