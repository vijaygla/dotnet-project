using HealthClinicApp.DAL.Repositories;
using HealthClinicApp.Models.Entities;

namespace HealthClinicApp.BLL.Services;

public class AppointmentService
{
    private readonly AppointmentRepository repo = new();

    public void Book(Appointment a)
    {
        repo.Book(a);
    }

    public List<Appointment> GetAllAppointments()
    {
        return repo.GetAll();
    }
}
