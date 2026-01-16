using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeWage
{
    public sealed class EmployeeMenu
    {
        private IEmployee employeeUtility;

      
        public void Start()
        {
            employeeUtility = new EmployeeUtilityImpl();
            int choice;
            do
            {
                Console.WriteLine("\n===== Employee Wage Menu =====");
                Console.WriteLine("1. Check Attendance");
                Console.WriteLine("2. Calculate Daily Wage");
                Console.WriteLine("3. Calculate Part Time Wage");
                Console.WriteLine("4. Calculate Wage Using Switch");
                Console.WriteLine("5. Calculate Monthly Wage");
                Console.WriteLine("6. Calculate Wage Till Condition");
                Console.WriteLine("7. Add Employee (Id, Name, Salary)");
                Console.WriteLine("8. Show All Employees");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1: employeeUtility.CheckAttendance(); break;
                        case 2: employeeUtility.CalculateDailyWage(); break;
                        case 3: employeeUtility.CalculatePartTimeWage(); break;
                        case 4: employeeUtility.CalculateWageUsingSwitch(); break;
                        case 5: employeeUtility.CalculateMonthlyWage(); break;
                        case 6: employeeUtility.CalculateWageTillCondition(); break;
                        case 7: employeeUtility.AddEmployee(); break;
                        case 8: ShowAllEmployees(); break;
                        case 0: Console.WriteLine("Exiting program..."); break;
                        default: Console.WriteLine("Invalid choice. Please try again."); break;
                    }
                }
            } while (choice != 0);
        }

        private void ShowAllEmployees()
        {
            var employees = EmployeeUtilityImpl.Employees;
            Console.WriteLine("\n----- Employee List -----");
            if (!employees.Any())
            {
                Console.WriteLine("No employees added yet.");
            }
            else
            {
                foreach (var e in employees)
                {
                    Console.WriteLine(e.ToString());
                }
                Console.WriteLine("-------------------------");
            }
        }
    }
}
