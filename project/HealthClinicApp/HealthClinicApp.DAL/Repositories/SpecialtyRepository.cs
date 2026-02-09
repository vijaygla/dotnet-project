using Microsoft.Data.SqlClient;
using HealthClinicApp.DAL.Db;
using HealthClinicApp.Models.Entities;

namespace HealthClinicApp.DAL.Repositories;

public class SpecialtyRepository
{
    public List<Specialty> GetAll()
    {
        var list = new List<Specialty>();

        using var con = DbConnectionFactory.GetConnection();
        var cmd = new SqlCommand("SELECT * FROM Specialties", con);

        con.Open();
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            list.Add(new Specialty
            {
                SpecialtyId = (int)reader["SpecialtyId"],
                SpecialtyName = reader["SpecialtyName"].ToString()!,
                Description = reader["Description"].ToString()!
            });
        }

        return list;
    }
}
