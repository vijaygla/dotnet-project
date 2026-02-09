using Microsoft.Data.SqlClient;

namespace HealthClinicApp.DAL.Db;

public static class DbConnectionFactory
{
    private static readonly string connectionString =
        "Server=localhost\\SQLEXPRESS;Database=HealthClinicDB;Trusted_Connection=True;TrustServerCertificate=True;";

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }
}
