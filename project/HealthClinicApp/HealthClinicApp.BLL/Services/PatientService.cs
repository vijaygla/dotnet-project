using HealthClinicApp.DAL.Repositories;
using HealthClinicApp.Models.Entities;

namespace HealthClinicApp.BLL.Services;

public class PatientService
{
    private readonly PatientRepository repo = new();

    // -------------------------
    // ADD
    // -------------------------
    public void Register(Patient patient)
    {
        if (string.IsNullOrWhiteSpace(patient.FirstName))
            throw new Exception("Patient name required");

        if (string.IsNullOrWhiteSpace(patient.Phone))
            throw new Exception("Phone required");

        repo.Add(patient);
    }

    // -------------------------
    // UPDATE
    // -------------------------
    public void Update(Patient patient)
    {
        repo.Update(patient);
    }

    // -------------------------
    // SEARCH
    // -------------------------
    public Patient? SearchByPhone(string phone)
    {
        return repo.GetByPhone(phone);
    }

    // -------------------------
    // LIST ALL
    // -------------------------
    public List<Patient> GetAll()
    {
        return repo.GetAll();
    }
}
