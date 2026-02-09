using HealthClinicApp.DAL.Repositories;
using HealthClinicApp.Models.Entities;

namespace HealthClinicApp.BLL.Services;

public class BillingService
{
    BillingRepository repo = new();

    public void CreateBill(Bill b)
    {
        if (b.TotalAmount <= 0)
            throw new Exception("Amount must be greater than zero");

        repo.Add(b);
    }

    public void UpdateBillStatus(int billId, string status)
    {
        if (string.IsNullOrWhiteSpace(status))
            throw new Exception("Status required");

        repo.UpdateStatus(billId, status);
    }

    public void RecordPayment(Payment payment)
    {
        if (payment.AmountPaid <= 0)
            throw new Exception("Payment amount must be greater than zero");

        repo.AddPayment(payment);
    }

    public List<Bill> GetAllBills()
    {
        return repo.GetAll();
    }

    public Bill? GetBillById(int billId)
    {
        return repo.GetById(billId);
    }

    public List<Payment> GetPaymentsForBill(int billId)
    {
        return repo.GetPaymentsByBillId(billId);
    }
}
