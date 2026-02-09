namespace HealthClinicApp.Models.Entities;

public class Specialty
{
    public int SpecialtyId { get; set; }
    public required string SpecialtyName { get; set; }
    public required string Description { get; set; }
}
