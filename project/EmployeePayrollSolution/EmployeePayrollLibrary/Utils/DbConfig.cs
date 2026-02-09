using System.Configuration;

namespace EmployeePayrollLibrary.Utils
{
    public static class DbConfig
    {
        // Put this connection string into appsettings or config in real app.
        public static string ConnectionString =>
            "Data Source=localhost\\SQLEXPRESS;" +
            "Initial Catalog=payroll_service;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";
    }
}
