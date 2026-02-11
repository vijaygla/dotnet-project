namespace CorporateTrainingSystem.Models;

public class ActivityLog
{
    public DateTime TimeStamp { get; set; }
    public string Message { get; set; } = "";
    public SeverityLevel Severity { get; set; }
}
