using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeWage
{
    public static class Constants
    {
        // Wage Constants
        public const int WAGE_PER_HOUR = 20;
        public const int FULL_DAY_HOUR = 8;
        public const int PART_TIME_HOUR = 4;
        public const int WORKING_DAYS_PER_MONTH = 20;
        public const int MAX_WORKING_HOURS = 100;
        public const int MAX_WORKING_DAYS = 20;

        // Employee Type Constants
        public const int EMPLOYEE_ABSENT = 0;
        public const int EMPLOYEE_FULL_TIME = 1;
        public const int EMPLOYEE_PART_TIME = 2;
    }
}
