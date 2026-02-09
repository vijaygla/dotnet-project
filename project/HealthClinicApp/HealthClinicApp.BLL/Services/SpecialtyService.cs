using HealthClinicApp.DAL.Repositories;
using HealthClinicApp.Models.Entities;

namespace HealthClinicApp.BLL.Services;

public class SpecialtyService
{
    SpecialtyRepository repo = new();

    public List<Specialty> GetAll()
    {
        return repo.GetAll();
    }
}
