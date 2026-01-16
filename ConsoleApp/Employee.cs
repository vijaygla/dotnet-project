using System;

namespace ConsoleApp
{
    public class Employee
    {
        private int empNo;
        private string empName;
        private double salary;
        private double hra;
        private double ta;
        private double da;
        private double pf;
        private double tds;
        private double grossSalary;
        private double netSalary;

        public int EmpNo
        {
            get { return empNo; }
            set { empNo = value; }
        }

        public string EmpName
        {
            get { return empName; }
            set { empName = value; }
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public double HRA { get { return hra; } }
        public double TA { get { return ta; } }
        public double DA { get { return da; } }
        public double PF { get { return pf; } }
        public double TDS { get { return tds; } }
        public double GrossSalary { get { return grossSalary; } }
        public double NetSalary { get { return netSalary; } }

        public void CalculateSalary()
        {
            if (salary < 5000)
            {
                hra = salary * 0.10;
                ta = salary * 0.05;
                da = salary * 0.15;
            }
            else if (salary < 10000)
            {
                hra = salary * 0.15;
                ta = salary * 0.10;
                da = salary * 0.20;
            }
            else if (salary < 15000)
            {
                hra = salary * 0.20;
                ta = salary * 0.15;
                da = salary * 0.25;
            }
            else if (salary < 20000)
            {
                hra = salary * 0.25;
                ta = salary * 0.20;
                da = salary * 0.30;
            }
            else
            {
                hra = salary * 0.30;
                ta = salary * 0.25;
                da = salary * 0.35;
            }

            grossSalary = salary + hra + ta + da;
            pf = grossSalary * 0.10;
            tds = grossSalary * 0.18;
            netSalary = grossSalary - (pf + tds);
        }

        public void DisplayEmployeeDetails()
        {
            Console.WriteLine("Employee Number : " + empNo);
            Console.WriteLine("Employee Name   : " + empName);
            Console.WriteLine("Basic Salary    : " + salary);
            Console.WriteLine("HRA             : " + hra);
            Console.WriteLine("TA              : " + ta);
            Console.WriteLine("DA              : " + da);
            Console.WriteLine("Gross Salary    : " + grossSalary);
            Console.WriteLine("PF              : " + pf);
            Console.WriteLine("TDS             : " + tds);
            Console.WriteLine("Net Salary      : " + netSalary);
        }
    }
}
