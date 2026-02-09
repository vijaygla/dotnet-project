using HealthClinicApp.DAL.Repositories;
using HealthClinicApp.Models.Entities;

namespace HealthClinicApp.BLL.Services;

public class DoctorService
{
    private readonly DoctorRepository repo = new();

    public void AddDoctor(Doctor d)
    {
        repo.Add(d);
    }

    public List<Doctor> GetAllDoctors()
    {
        return repo.GetAll();
    }
}
