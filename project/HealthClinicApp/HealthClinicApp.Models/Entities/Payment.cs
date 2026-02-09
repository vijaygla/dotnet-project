namespace HealthClinicApp.Models.Entities;

public class Payment
{
    public int PaymentId { get; set; }
    public int BillId { get; set; }
    public decimal AmountPaid { get; set; }
    public DateTime PaymentDate { get; set; }
    public required string PaymentMethod { get; set; }
    public required string TransactionId { get; set; }
}
