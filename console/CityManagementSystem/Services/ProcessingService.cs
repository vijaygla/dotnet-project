using CityManagementSystem.Models;

namespace CityManagementSystem.Services;

public class ProcessingService
{
    public void ProcessIssues(List<Issue> issues)
    {
        Parallel.ForEach(issues, issue =>
        {
            try
            {
                issue.Status = IssueStatus.Processing;

                issue.Activities.Add(new ActivityLog
                {
                    TimeStamp = DateTime.Now,
                    Message = "Processing started",
                    Severity = SeverityLevel.Medium
                });

                Thread.Sleep(1000);

                issue.Status = IssueStatus.Completed;

                issue.Activities.Add(new ActivityLog
                {
                    TimeStamp = DateTime.Now,
                    Message = "Completed",
                    Severity = SeverityLevel.Low
                });
            }
            catch
            {
                issue.Status = IssueStatus.Failed;
            }
        });
    }
}
