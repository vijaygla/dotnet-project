namespace HealthClinicApp.Models.Entities;

public class Bill
{
    public int BillId { get; set; }
    public decimal TotalAmount { get; set; }
    public required string PaymentStatus { get; set; }
}
