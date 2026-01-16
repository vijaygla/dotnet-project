using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeWage
{
    public interface IEmployee
    {
        void CheckAttendance();
        void CalculateDailyWage();
        void CalculatePartTimeWage();
        void CalculateWageUsingSwitch();
        void CalculateMonthlyWage();
        void CalculateWageTillCondition();
        Employee AddEmployee();
    }
}
