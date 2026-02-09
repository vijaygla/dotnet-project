using Microsoft.Data.SqlClient;
using HealthClinicApp.Models.Entities;
using HealthClinicApp.DAL.Db;

namespace HealthClinicApp.DAL.Repositories;

public class PatientRepository
{
    // -------------------------
    // INSERT
    // -------------------------
    public void Add(Patient p)
    {
        using var con = DbConnectionFactory.GetConnection();

        var cmd = new SqlCommand(
            "INSERT INTO Patients(FirstName, Phone) VALUES(@name,@phone)", con);

        cmd.Parameters.AddWithValue("@name", p.FirstName);
        cmd.Parameters.AddWithValue("@phone", p.Phone);

        con.Open();
        cmd.ExecuteNonQuery();
    }

    // -------------------------
    // UPDATE
    // -------------------------
    public void Update(Patient p)
    {
        using var con = DbConnectionFactory.GetConnection();

        var cmd = new SqlCommand(
            "UPDATE Patients SET FirstName=@name, Phone=@phone WHERE PatientId=@id", con);

        cmd.Parameters.AddWithValue("@name", p.FirstName);
        cmd.Parameters.AddWithValue("@phone", p.Phone);
        cmd.Parameters.AddWithValue("@id", p.PatientId);

        con.Open();
        cmd.ExecuteNonQuery();
    }

    // -------------------------
    // SEARCH BY PHONE
    // -------------------------
    public Patient? GetByPhone(string phone)
    {
        using var con = DbConnectionFactory.GetConnection();

        var cmd = new SqlCommand(
            "SELECT * FROM Patients WHERE Phone=@phone", con);

        cmd.Parameters.AddWithValue("@phone", phone);

        con.Open();

        using var reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return new Patient
            {
                PatientId = (int)reader["PatientId"],
                FirstName = reader["FirstName"].ToString(),
                Phone = reader["Phone"].ToString()
            };
        }

        return null;
    }

    // -------------------------
    // GET ALL
    // -------------------------
    public List<Patient> GetAll()
    {
        var list = new List<Patient>();

        using var con = DbConnectionFactory.GetConnection();

        var cmd = new SqlCommand("SELECT * FROM Patients", con);

        con.Open();

        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            list.Add(new Patient
            {
                PatientId = (int)reader["PatientId"],
                FirstName = reader["FirstName"].ToString(),
                Phone = reader["Phone"].ToString()
            });
        }

        return list;
    }
}
