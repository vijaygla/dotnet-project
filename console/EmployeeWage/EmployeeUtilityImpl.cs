using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeWage
{
    internal class EmployeeUtilityImpl : IEmployee
    {
        public void CheckAttendance()
        {
            Console.WriteLine("Welcome to Employee Wage Computation Program on Master Branch");
            Random random = new Random();
            int attendance = random.Next(0, 2);
            if (attendance == 1)
                Console.WriteLine("Employee is Present");
            else
                Console.WriteLine("Employee is Absent");
        }

        public void CalculateDailyWage()
        {
            int wagePerHour = 20;
            int fullDayHour = 8;
            int dailyWage = wagePerHour * fullDayHour;
            Console.WriteLine("Daily Employee Wage: " + dailyWage);
        }

        public void CalculatePartTimeWage()
        {
            int wagePerHour = 20;
            int partTimeHour = 4;
            int partTimeWage = wagePerHour * partTimeHour;
            Console.WriteLine("Part Time Employee Wage: " + partTimeWage);
        }

        public void CalculateWageUsingSwitch()
        {
            int wagePerHour = 20;
            int fullDayHour = 8;
            int partTimeHour = 4;
            Random random = new Random();
            int empType = random.Next(0, 3);
            int totalWage = 0;

            switch (empType)
            {
                case 1:
                    totalWage = wagePerHour * fullDayHour;
                    Console.WriteLine("Full Time Employee Wage: " + totalWage);
                    break;
                case 2:
                    totalWage = wagePerHour * partTimeHour;
                    Console.WriteLine("Part Time Employee Wage: " + totalWage);
                    break;
                default:
                    Console.WriteLine("Employee is Absent");
                    break;
            }
        }

        public void CalculateMonthlyWage()
        {
            int wagePerHour = 20;
            int workingDays = 20;
            int fullDayHour = 8;
            int monthlyWage = wagePerHour * fullDayHour * workingDays;
            Console.WriteLine("Monthly Employee Wage: " + monthlyWage);
        }

        public void CalculateWageTillCondition()
        {
            int wagePerHour = 20;
            int totalHours = 0;
            int totalDays = 0;

            while (totalHours < 100 && totalDays < 20)
            {
                totalDays++;
                totalHours += 8;
            }

            int totalWage = totalHours * wagePerHour;
            Console.WriteLine("Total Wage till condition reached: " + totalWage);
        }

        // New method: take input and create Employee
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

            return emp;
        }
    }
}
