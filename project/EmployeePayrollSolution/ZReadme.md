```
✦ I have used the following technologies in this project:


   * C# and .NET: The primary programming language and framework.
   * ADO.NET with `Microsoft.Data.SqlClient`: For direct database interactions, including managing connections, executing SQL commands, and handling
     transactions within the PayrollRepository.
   * MSTest: The unit testing framework used for EmployeePayrollTests.
   * Moq: A mocking library utilized in the tests to create mock implementations of the IPayrollRepository, allowing for isolated testing of the
     EmployeePayrollService and EmployeePayrollThreadService without a live database connection.
   * Task Parallel Library (TPL): Employed in EmployeePayrollService and EmployeePayrollThreadService to manage and execute concurrent operations for adding
     employees.
```
