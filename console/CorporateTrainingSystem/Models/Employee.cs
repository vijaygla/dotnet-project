using System.Collections.Generic;

namespace CorporateTrainingSystem.Models;

public class Employee
{
    public string EmployeeId { get; set; } = "";
    public string Name { get; set; } = "";
    public TrainingTrack Track { get; set; } = new();
    public DateTime EnrollmentDate { get; set; }

    public ProgressStatus Status { get; set; }

    public List<ActivityLog> Activities { get; set; } = new();
}
