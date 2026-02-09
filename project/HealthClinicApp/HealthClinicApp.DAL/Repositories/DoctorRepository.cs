using Microsoft.Data.SqlClient;
using HealthClinicApp.DAL.Db;
using HealthClinicApp.Models.Entities;

namespace HealthClinicApp.DAL.Repositories;

public class DoctorRepository
{
    public void Add(Doctor d)
    {
        using var con = DbConnectionFactory.GetConnection();
        var cmd = new SqlCommand(
            "INSERT INTO Doctors(Name,SpecialtyId,Fee) VALUES(@n,@s,@f)", con);

        cmd.Parameters.AddWithValue("@n", d.Name);
        cmd.Parameters.AddWithValue("@s", d.SpecialtyId);
        cmd.Parameters.AddWithValue("@f", d.Fee);

        con.Open();
        cmd.ExecuteNonQuery();
    }

    public void Update(Doctor d)
    {
        using var con = DbConnectionFactory.GetConnection();
        var cmd = new SqlCommand(
            "UPDATE Doctors SET Name=@n, SpecialtyId=@s, Fee=@f WHERE DoctorId=@id", con);

        cmd.Parameters.AddWithValue("@n", d.Name);
        cmd.Parameters.AddWithValue("@s", d.SpecialtyId);
        cmd.Parameters.AddWithValue("@f", d.Fee);
        cmd.Parameters.AddWithValue("@id", d.DoctorId);

        con.Open();
        cmd.ExecuteNonQuery();
    }

    public List<Doctor> GetAll()
    {
        var list = new List<Doctor>();

        using var con = DbConnectionFactory.GetConnection();
        var cmd = new SqlCommand("SELECT * FROM Doctors", con);

        con.Open();
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            list.Add(new Doctor
            {
                DoctorId = (int)reader["DoctorId"],
                Name = reader["Name"].ToString()!,
                SpecialtyId = (int)reader["SpecialtyId"],
                Fee = (decimal)reader["Fee"]
            });
        }

        return list;
    }

    public Doctor? GetById(int doctorId)
    {
        using var con = DbConnectionFactory.GetConnection();
        var cmd = new SqlCommand("SELECT * FROM Doctors WHERE DoctorId=@id", con);

        cmd.Parameters.AddWithValue("@id", doctorId);

        con.Open();
        using var reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return new Doctor
            {
                DoctorId = (int)reader["DoctorId"],
                Name = reader["Name"].ToString()!,
                SpecialtyId = (int)reader["SpecialtyId"],
                Fee = (decimal)reader["Fee"]
            };
        }

        return null;
    }
}