using System.Collections.Generic;
using EmployeePayrollLibrary.Models;

namespace EmployeePayrollLibrary.Data
{
    public interface IPayrollRepository
    {
        int InsertEmployeeWithDetails(EmployeeDetails emp);
        void UpdateEmployeeSalaryAndDetails(EmployeeDetails emp);
        List<EmployeeDetails> GetAllEmployees();
    }
}
