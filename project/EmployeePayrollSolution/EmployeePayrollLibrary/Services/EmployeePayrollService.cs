using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using EmployeePayrollLibrary.Data;
using EmployeePayrollLibrary.Models;

namespace EmployeePayrollLibrary.Services
{
    public class EmployeePayrollService
    {
        private readonly IPayrollRepository _repository;
        private readonly List<EmployeeDetails> _inMemoryList;

        public EmployeePayrollService() : this(new PayrollRepository())
        {
        }

        public EmployeePayrollService(IPayrollRepository repository)
        {
            _repository = repository;
            _inMemoryList = new List<EmployeeDetails>();
        }

        // UC1: add multiple employees to DB without threads, use transaction inside repo
        public TimeSpan AddEmployeesToPayroll(List<EmployeeDetails> employees)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            foreach (EmployeeDetails emp in employees)
            {
                Console.WriteLine("Employee being added (no thread): " + emp.EmployeeName);
                int id = _repository.InsertEmployeeWithDetails(emp);
                emp.EmployeeId = id;
                _inMemoryList.Add(emp);
                Console.WriteLine("Employee added (no thread): " + emp.EmployeeName);
            }

            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        // UC2–UC4: add multiple employees using Task (thread) for each
        public TimeSpan AddEmployeesToPayrollWithThreads(List<EmployeeDetails> employees)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            List<Task> tasks = new List<Task>();

            foreach (EmployeeDetails emp in employees)
            {
                Task task = new Task(() =>
                {
                    Console.WriteLine("Employee being added (thread): " + emp.EmployeeName);
                    int id = _repository.InsertEmployeeWithDetails(emp);
                    emp.EmployeeId = id;

                    lock (_inMemoryList)
                    {
                        _inMemoryList.Add(emp);
                    }

                    Console.WriteLine("Employee added (thread): " + emp.EmployeeName);
                });

                tasks.Add(task);
                task.Start();
            }

            Task.WaitAll(tasks.ToArray());
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        public int EmployeeCount()
        {
            lock (_inMemoryList)
            {
                return _inMemoryList.Count;
            }
        }

        public List<EmployeeDetails> GetInMemoryEmployees()
        {
            lock (_inMemoryList)
            {
                return new List<EmployeeDetails>(_inMemoryList);
            }
        }

        // UC6: update salary for multiple employees with threads
        public TimeSpan UpdateSalaryForEmployeesWithThreads(List<EmployeeDetails> employeesToUpdate)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            List<Task> tasks = new List<Task>();

            foreach (EmployeeDetails emp in employeesToUpdate)
            {
                Task task = new Task(() =>
                {
                    Console.WriteLine("Updating salary for employee (thread): " + emp.EmployeeId);
                    _repository.UpdateEmployeeSalaryAndDetails(emp);
                    Console.WriteLine("Updated salary for employee (thread): " + emp.EmployeeId);
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
