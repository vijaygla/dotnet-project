using CorporateTrainingSystem.Models;

namespace CorporateTrainingSystem.Services;

public class EnrollmentService
{
    private readonly List<Employee> employees = new();

    public void Enroll(Employee emp)
    {
        if (employees.Any(e => e.EmployeeId == emp.EmployeeId))
            throw new Exception("Duplicate enrollment!");

        employees.Add(emp);
    }

    public List<Employee> GetAll() => employees;

    public List<Employee> ByDateRange(DateTime start, DateTime end)
    {
        return employees
            .Where(e => e.EnrollmentDate >= start && e.EnrollmentDate <= end)
            .ToList();
    }

    public void TrackFailureSummary()
    {
        var groups = employees.GroupBy(e => e.Track.Name);

        foreach (var g in groups)
        {
            int failed = g.Count(x => x.Status == ProgressStatus.Failed);
            int total = g.Count();
            double rate = total == 0 ? 0 : (double)failed / total;

            Console.WriteLine($"{g.Key} -> Failure Rate: {rate:P}");
        }

        var worst = groups
            .OrderByDescending(g => g.Count(x => x.Status == ProgressStatus.Failed))
            .FirstOrDefault();

        if (worst != null)
            Console.WriteLine($"\nHighest Failure Track: {worst.Key}");
    }
}
