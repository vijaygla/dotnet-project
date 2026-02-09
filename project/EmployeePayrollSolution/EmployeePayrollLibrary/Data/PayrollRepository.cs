using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using EmployeePayrollLibrary.Models;
using EmployeePayrollLibrary.Utils;

namespace EmployeePayrollLibrary.Data
{
    public class PayrollRepository : IPayrollRepository
    {
        public int InsertEmployeeWithDetails(EmployeeDetails emp)
        {
            using (SqlConnection connection = new SqlConnection(DbConfig.ConnectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int employeeId = InsertEmployee(emp, connection, transaction);
                        InsertPayrollDetails(emp, employeeId, connection, transaction);
                        transaction.Commit();
                        return employeeId;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private int InsertEmployee(EmployeeDetails emp, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"INSERT INTO employee_payroll
                             (employee_name, phone_number, address, department, basic_pay, start_date)
                             VALUES (@name, @phone, @address, @dept, @basic, @startDate);
                             SELECT SCOPE_IDENTITY();";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@name", emp.EmployeeName);
                command.Parameters.AddWithValue("@phone", emp.PhoneNumber);
                command.Parameters.AddWithValue("@address", emp.Address);
                command.Parameters.AddWithValue("@dept", emp.Department);
                command.Parameters.AddWithValue("@basic", emp.BasicPay);
                command.Parameters.AddWithValue("@startDate", emp.StartDate);

                object result = command.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        private void InsertPayrollDetails(EmployeeDetails emp, int employeeId, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"INSERT INTO payroll_details
                             (employee_id, basic_pay, deductions, taxable_pay, income_tax, net_pay)
                             VALUES (@empId, @basic, @deductions, @taxable, @tax, @net);";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@empId", employeeId);
                command.Parameters.AddWithValue("@basic", emp.BasicPay);
                command.Parameters.AddWithValue("@deductions", emp.Deductions);
                command.Parameters.AddWithValue("@taxable", emp.TaxablePay);
                command.Parameters.AddWithValue("@tax", emp.IncomeTax);
                command.Parameters.AddWithValue("@net", emp.NetPay);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateEmployeeSalaryAndDetails(EmployeeDetails emp)
        {
            using (SqlConnection connection = new SqlConnection(DbConfig.ConnectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string updatePayroll = @"UPDATE employee_payroll
                                                 SET basic_pay = @basic
                                                 WHERE employee_id = @id;";

                        using (SqlCommand command = new SqlCommand(updatePayroll, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@basic", emp.BasicPay);
                            command.Parameters.AddWithValue("@id", emp.EmployeeId);
                            command.ExecuteNonQuery();
                        }

                        string updateDetails = @"UPDATE payroll_details
                                                 SET basic_pay = @basic,
                                                     deductions = @deductions,
                                                     taxable_pay = @taxable,
                                                     income_tax = @tax,
                                                     net_pay = @net
                                                 WHERE employee_id = @id;";

                        using (SqlCommand command = new SqlCommand(updateDetails, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@basic", emp.BasicPay);
                            command.Parameters.AddWithValue("@deductions", emp.Deductions);
                            command.Parameters.AddWithValue("@taxable", emp.TaxablePay);
                            command.Parameters.AddWithValue("@tax", emp.IncomeTax);
                            command.Parameters.AddWithValue("@net", emp.NetPay);
                            command.Parameters.AddWithValue("@id", emp.EmployeeId);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<EmployeeDetails> GetAllEmployees()
        {
            List<EmployeeDetails> list = new List<EmployeeDetails>();

            using (SqlConnection connection = new SqlConnection(DbConfig.ConnectionString))
            {
                connection.Open();
                string query = @"SELECT e.employee_id, e.employee_name, e.phone_number, e.address, e.department,
                                        e.basic_pay, e.start_date,
                                        d.deductions, d.taxable_pay, d.income_tax, d.net_pay
                                 FROM employee_payroll e
                                 LEFT JOIN payroll_details d ON e.employee_id = d.employee_id;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EmployeeDetails emp = new EmployeeDetails();
                            emp.EmployeeId = reader.GetInt32(0);
                            emp.EmployeeName = reader.GetString(1);
                            emp.PhoneNumber = reader.IsDBNull(2) ? null : reader.GetString(2);
                            emp.Address = reader.IsDBNull(3) ? null : reader.GetString(3);
                            emp.Department = reader.IsDBNull(4) ? null : reader.GetString(4);
                            emp.BasicPay = reader.GetDecimal(5);
                            emp.StartDate = reader.GetDateTime(6);
                            emp.Deductions = reader.IsDBNull(7) ? 0 : reader.GetDecimal(7);
                            emp.TaxablePay = reader.IsDBNull(8) ? 0 : reader.GetDecimal(8);
                            emp.IncomeTax = reader.IsDBNull(9) ? 0 : reader.GetDecimal(9);
                            emp.NetPay = reader.IsDBNull(10) ? 0 : reader.GetDecimal(10);
                            list.Add(emp);
                        }
                    }
                }
            }

            return list;
        }
    }
}
