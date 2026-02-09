public interface IBookable
{
    bool CanBook();
    void Cancel();
    decimal CalculateCost();
}
