using Microsoft.Data.SqlClient;
using HealthClinicApp.DAL.Db;
using HealthClinicApp.Models.Entities;

namespace HealthClinicApp.DAL.Repositories;

public class BillingRepository
{
    public void Add(Bill b)
    {
        using var con = DbConnectionFactory.GetConnection();
        var cmd = new SqlCommand(
            "INSERT INTO Bills(TotalAmount,PaymentStatus) VALUES(@amt,@status)", con);

        cmd.Parameters.AddWithValue("@amt", b.TotalAmount);
        cmd.Parameters.AddWithValue("@status", b.PaymentStatus ?? "PENDING");

        con.Open();
        cmd.ExecuteNonQuery();
    }

    public void UpdateStatus(int billId, string status)
    {
        using var con = DbConnectionFactory.GetConnection();
        var cmd = new SqlCommand(
            "UPDATE Bills SET PaymentStatus=@status WHERE BillId=@id", con);

        cmd.Parameters.AddWithValue("@status", status);
        cmd.Parameters.AddWithValue("@id", billId);

        con.Open();
        cmd.ExecuteNonQuery();
    }

    public void AddPayment(Payment p)
    {
        using var con = DbConnectionFactory.GetConnection();
        var cmd = new SqlCommand(
            @"INSERT INTO Payments(BillId,AmountPaid,PaymentDate,PaymentMethod,TransactionId)
              VALUES(@bid,@amt,@dt,@method,@tid)", con);

        cmd.Parameters.AddWithValue("@bid", p.BillId);
        cmd.Parameters.AddWithValue("@amt", p.AmountPaid);
        cmd.Parameters.AddWithValue("@dt", p.PaymentDate);
        cmd.Parameters.AddWithValue("@method", p.PaymentMethod ?? "CASH");
        cmd.Parameters.AddWithValue("@tid", p.TransactionId ?? "");

        con.Open();
        cmd.ExecuteNonQuery();
    }

    public List<Bill> GetAll()
    {
        var list = new List<Bill>();

        using var con = DbConnectionFactory.GetConnection();
        var cmd = new SqlCommand("SELECT * FROM Bills", con);

        con.Open();
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            list.Add(new Bill
            {
                BillId = (int)reader["BillId"],
                TotalAmount = (decimal)reader["TotalAmount"],
                PaymentStatus = reader["PaymentStatus"].ToString()!
            });
        }

        return list;
    }

    public Bill? GetById(int billId)
    {
        using var con = DbConnectionFactory.GetConnection();
        var cmd = new SqlCommand("SELECT * FROM Bills WHERE BillId=@id", con);

        cmd.Parameters.AddWithValue("@id", billId);

        con.Open();
        using var reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return new Bill
            {
                BillId = (int)reader["BillId"],
                TotalAmount = (decimal)reader["TotalAmount"],
                PaymentStatus = reader["PaymentStatus"].ToString()!
            };
        }

        return null;
    }

    public List<Payment> GetPaymentsByBillId(int billId)
    {
        var list = new List<Payment>();

        using var con = DbConnectionFactory.GetConnection();
        var cmd = new SqlCommand("SELECT * FROM Payments WHERE BillId=@bid", con);

        cmd.Parameters.AddWithValue("@bid", billId);

        con.Open();
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            list.Add(new Payment
            {
                PaymentId = (int)reader["PaymentId"],
                BillId = (int)reader["BillId"],
                AmountPaid = (decimal)reader["AmountPaid"],
                PaymentDate = (DateTime)reader["PaymentDate"],
                PaymentMethod = reader["PaymentMethod"].ToString()!,
                TransactionId = reader["TransactionId"].ToString()!
            });
        }

        return list;
    }
}
