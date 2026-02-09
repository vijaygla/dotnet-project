using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeWage
{
    internal class EmployeeMain
    {
        public static void Main(string[] args)
        {
            EmployeeMenu menu = new EmployeeMenu();
            menu.Start();
        }
    }
}
