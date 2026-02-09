namespace HealthClinicApp.Models.Entities;

public class Patient
{
    public int PatientId { get; set; }
    public required string FirstName { get; set; }
    public required string Phone { get; set; }
}
