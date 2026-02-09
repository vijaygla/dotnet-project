namespace HealthClinicApp.Models.Entities;

public class Doctor
{
    public int DoctorId { get; set; }
    public required string Name { get; set; }
    public int SpecialtyId { get; set; }
    public decimal Fee { get; set; }
}
