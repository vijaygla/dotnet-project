using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using EmployeePayrollLibrary.Data;
using EmployeePayrollLibrary.Models;

namespace EmployeePayrollLibrary.Services
{
    public class EmployeePayrollThreadService
    {
        private readonly IPayrollRepository _repository;

        public EmployeePayrollThreadService() : this(new PayrollRepository())
        {
        }

        public EmployeePayrollThreadService(IPayrollRepository repository)
        {
            _repository = repository;
        }

        // UC5: threads used inside DB service, ensure synchronization between employee_payroll and payroll_details.
        public TimeSpan AddEmployeesToPayrollUsingInternalThreads(List<EmployeeDetails> employees)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            List<Task> tasks = new List<Task>();

            foreach (EmployeeDetails emp in employees)
            {
                Task task = new Task(() =>
                {
                    Console.WriteLine("Employee being added (thread): " + emp.EmployeeName);
                    _repository.InsertEmployeeWithDetails(emp);
                    Console.WriteLine("Employee added (thread): " + emp.EmployeeName);
                });

                tasks.Add(task);
                task.Start();
            }

            Task.WaitAll(tasks.ToArray());
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }
    }
}
