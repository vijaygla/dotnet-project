using System.Collections.Generic;

namespace CityManagementSystem.Models;

public class Issue
{
    public int Id { get; set; }
    public string CitizenName { get; set; } = "";
    public string Location { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime CreatedTime { get; set; }

    public DepartmentType Department { get; set; }
    public IssueStatus Status { get; set; }

    public List<ActivityLog> Activities { get; set; } = new();
}
