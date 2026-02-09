namespace HealthClinicApp.Models.Entities;

public class Visit
{
    public int VisitId { get; set; }
    public int AppointmentId { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime VisitDate { get; set; }
    public required string Diagnosis { get; set; }
    public required string Treatment { get; set; }
    public required string Notes { get; set; }
}
