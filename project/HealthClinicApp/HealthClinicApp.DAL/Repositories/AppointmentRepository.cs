using Microsoft.Data.SqlClient;
using HealthClinicApp.DAL.Db;
using HealthClinicApp.Models.Entities;

namespace HealthClinicApp.DAL.Repositories;

public class AppointmentRepository
{
    public void Book(Appointment a)
    {
        using var con = DbConnectionFactory.GetConnection();
        var cmd = new SqlCommand(
            @"INSERT INTO Appointments
              (PatientId,DoctorId,AppointmentDate,Status)
              VALUES(@p,@d,@dt,'SCHEDULED')", con);

        cmd.Parameters.AddWithValue("@p", a.PatientId);
        cmd.Parameters.AddWithValue("@d", a.DoctorId);
        cmd.Parameters.AddWithValue("@dt", a.AppointmentDate);

        con.Open();
        cmd.ExecuteNonQuery();
    }

    public void UpdateStatus(int appointmentId, string status)
    {
        using var con = DbConnectionFactory.GetConnection();
        var cmd = new SqlCommand(
            "UPDATE Appointments SET Status=@status WHERE AppointmentId=@id", con);

        cmd.Parameters.AddWithValue("@status", status);
        cmd.Parameters.AddWithValue("@id", appointmentId);

        con.Open();
        cmd.ExecuteNonQuery();
    }

    public List<Appointment> GetAll()
    {
        var list = new List<Appointment>();

        using var con = DbConnectionFactory.GetConnection();
        var cmd = new SqlCommand("SELECT * FROM Appointments", con);

        con.Open();
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
                {
            list.Add(new Appointment
            {
                AppointmentId = (int)reader["AppointmentId"],
                PatientId = (int)reader["PatientId"],
                DoctorId = (int)reader["DoctorId"],
                AppointmentDate = (DateTime)reader["AppointmentDate"],
                Status = reader["Status"].ToString()!
            });
        }

        return list;
    }

    public Appointment? GetById(int appointmentId)
    {
        using var con = DbConnectionFactory.GetConnection();
        var cmd = new SqlCommand("SELECT * FROM Appointments WHERE AppointmentId=@id", con);

        cmd.Parameters.AddWithValue("@id", appointmentId);

        con.Open();
        using var reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return new Appointment
            {
                AppointmentId = (int)reader["AppointmentId"],
                PatientId = (int)reader["PatientId"],
                DoctorId = (int)reader["DoctorId"],
                AppointmentDate = (DateTime)reader["AppointmentDate"],
                Status = reader["Status"].ToString()!
            };
        }

        return null;
    }
}