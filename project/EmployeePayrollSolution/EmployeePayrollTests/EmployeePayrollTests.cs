using System;
using System.Collections.Generic;
using System.Diagnostics;
using EmployeePayrollLibrary.Data;
using EmployeePayrollLibrary.Models;
using EmployeePayrollLibrary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EmployeePayrollTests
{
    [TestClass]
    public class EmployeePayrollTests
    {
        private Mock<IPayrollRepository>? _repositoryMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _repositoryMock = new Mock<IPayrollRepository>();
            _repositoryMock.Setup(r => r.InsertEmployeeWithDetails(It.IsAny<EmployeeDetails>())).Returns(1);
        }

        private List<EmployeeDetails> CreateEmployees()
        {
            List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();

            employeeDetails.Add(new EmployeeDetails
            {
                EmployeeName = "Bruce",
                PhoneNumber = "9999999999",
                Address = "Gotham",
                Department = "IT",
                BasicPay = 40000,
                Deductions = 1000,
                TaxablePay = 39000,
                IncomeTax = 3900,
                NetPay = 35100,
                StartDate = DateTime.Now.Date
            });

            employeeDetails.Add(new EmployeeDetails
            {
                EmployeeName = "Wayne",
                PhoneNumber = "9999999999",
                Address = "Gotham",
                Department = "HR",
                BasicPay = 42000,
                Deductions = 1000,
                TaxablePay = 41000,
                IncomeTax = 4100,
                NetPay = 36900,
                StartDate = DateTime.Now.Date
            });

            // Add more up to 10 as required
            for (int i = 3; i <= 10; i++)
            {
                employeeDetails.Add(new EmployeeDetails
                {
                    EmployeeName = "Emp" + i,
                    PhoneNumber = "9999999999",
                    Address = "City" + i,
                    Department = "Dept" + (i % 3),
                    BasicPay = 30000 + (i * 1000),
                    Deductions = 1000,
                    TaxablePay = 30000 + (i * 1000) - 1000,
                    IncomeTax = (30000 + (i * 1000) - 1000) * 0.1m,
                    NetPay = (30000 + (i * 1000) - 1000) * 0.9m,
                    StartDate = DateTime.Now.Date
                });
            }

            return employeeDetails;
        }

        [TestMethod]
        public void UC1_AddMultipleEmployees_NoThreads()
        {
            List<EmployeeDetails> employees = CreateEmployees();
            EmployeePayrollService service = new EmployeePayrollService(_repositoryMock!.Object);

            TimeSpan duration = service.AddEmployeesToPayroll(employees);

            Assert.AreEqual(employees.Count, service.EmployeeCount());
            Console.WriteLine("UC1 Duration (no threads): " + duration);
        }

        [TestMethod]
        public void UC2_AddMultipleEmployees_WithThreads()
        {
            List<EmployeeDetails> employees = CreateEmployees();
            EmployeePayrollService service = new EmployeePayrollService(_repositoryMock!.Object);

            TimeSpan durationNoThread = service.AddEmployeesToPayroll(employees);
            TimeSpan durationWithThread = service.AddEmployeesToPayrollWithThreads(employees);

            Assert.AreEqual(employees.Count * 2, service.EmployeeCount());
            Console.WriteLine("UC2 Duration no thread: " + durationNoThread);
            Console.WriteLine("UC2 Duration with threads: " + durationWithThread);
        }

        [TestMethod]
        public void UC4_AddEmployees_ThreadExecutionUsingConsoleLogs()
        {
            List<EmployeeDetails> employees = CreateEmployees();
            EmployeePayrollService service = new EmployeePayrollService(_repositoryMock!.Object);

            TimeSpan duration = service.AddEmployeesToPayrollWithThreads(employees);

            Assert.AreEqual(employees.Count, service.EmployeeCount());
            Console.WriteLine("UC4 Duration with threads (console logs show execution): " + duration);
        }

        [TestMethod]
        public void UC5_AddEmployees_ThreadsInsideDBService()
        {
            List<EmployeeDetails> employees = CreateEmployees();
            EmployeePayrollThreadService threadService = new EmployeePayrollThreadService(_repositoryMock!.Object);

            TimeSpan duration = threadService.AddEmployeesToPayrollUsingInternalThreads(employees);

            Console.WriteLine("UC5 Duration with internal DB threads: " + duration);
        }

        [TestMethod]
        public void UC6_UpdateSalary_MultipleEmployees_WithThreads()
        {
            List<EmployeeDetails> employees = CreateEmployees();
            EmployeePayrollService service = new EmployeePayrollService(_repositoryMock!.Object);

            service.AddEmployeesToPayroll(employees);

            List<EmployeeDetails> updates = new List<EmployeeDetails>();
            foreach (EmployeeDetails emp in employees)
            {
                EmployeeDetails update = new EmployeeDetails();
                update.EmployeeId = emp.EmployeeId;
                update.BasicPay = emp.BasicPay + 5000;
                update.Deductions = emp.Deductions + 500;
                update.TaxablePay = update.BasicPay - update.Deductions;
                update.IncomeTax = update.TaxablePay * 0.1m;
                update.NetPay = update.TaxablePay - update.IncomeTax;
                updates.Add(update);
            }

            TimeSpan duration = service.UpdateSalaryForEmployeesWithThreads(updates);

            Console.WriteLine("UC6 Duration updating salaries with threads: " + duration);
        }
    }
}
