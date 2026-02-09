namespace EmployeePayrollLibrary.Models
{
    public class EmployeeDetails
    {
        public int EmployeeId { get; set; }   // Will be filled from DB identity
        public string? EmployeeName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Department { get; set; }
        public decimal BasicPay { get; set; }
        public decimal Deductions { get; set; }
        public decimal TaxablePay { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal NetPay { get; set; }
        public System.DateTime StartDate { get; set; }
    }
}
