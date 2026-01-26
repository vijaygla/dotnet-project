using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeWage
{
    internal interface IEmployee
    {
        void CheckAttendance();
        void CalculateDailyWage();
        void CalculatePartTimeWage();
        void CalculateWageUsingSwitch();
        void CalculateMonthlyWage();
        void CalculateWageTillCondition();

        // New method to add employee
        Employee AddEmployee();
    }
}
