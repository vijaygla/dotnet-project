using CityManagementSystem.Models;

namespace CityManagementSystem.Services;

public class IssueService
{
    private readonly List<Issue> issues = new();

    public void AddIssue(Issue issue)
    {
        issues.Add(issue);
    }

    public List<Issue> GetAll()
    {
        return issues;
    }

    public List<Issue> GetLast24Hours()
    {
        return issues
            .Where(x => x.CreatedTime >= DateTime.Now.AddHours(-24))
            .ToList();
    }

    public void DepartmentSummary()
    {
        var groups = issues.GroupBy(x => x.Department);

        foreach (var g in groups)
            Console.WriteLine($"{g.Key} -> {g.Count()} issues");

        var max = groups.OrderByDescending(x => x.Count()).FirstOrDefault();

        if (max != null)
            Console.WriteLine($"\nDepartment with most issues: {max.Key}");
    }
}
