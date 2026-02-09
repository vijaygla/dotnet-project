namespace HealthClinicApp.Models.Entities;

public class Prescription
{
    public int PrescriptionId { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public required string Medication { get; set; }
    public required string Dosage { get; set; }
    public int Quantity { get; set; }
    public DateTime IssuedDate { get; set; }
    public required string Instructions { get; set; }
}
