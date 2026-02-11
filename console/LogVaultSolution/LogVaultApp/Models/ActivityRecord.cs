using System.ComponentModel.DataAnnotations;

namespace LogVaultApp.Models;

public class ActivityRecord
{
    // Required fields 
    [Required]
    public string RecordId { get; set; }

    [Required]
    public string SourceModule { get; set; }

    [Required]
    public SeverityLevel Severity { get; set; }

    [Required]
    public string Message { get; set; }

    // Auto timestamp
    public DateTime TimeStamp { get; set; } = DateTime.Now;

    // Convert object to text (save in file)
    public string ToFileString()
    {
        return $"{RecordId}|{SourceModule}|{Severity}|{Message}|{TimeStamp}";
    }

    // Convert text to object (read from file)
    public static ActivityRecord FromFileString(string line)
    {
        var parts = line.Split('|');

        return new ActivityRecord
        {
            RecordId = parts[0],
            SourceModule = parts[1],
            Severity = Enum.Parse<SeverityLevel>(parts[2]),
            Message = parts[3],
            TimeStamp = DateTime.Parse(parts[4])
        };
    }
}
