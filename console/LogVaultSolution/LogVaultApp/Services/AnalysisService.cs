using LogVaultApp.Models;

namespace LogVaultApp.Services;

public class AnalysisService
{
    private readonly List<ActivityRecord> records;

    public AnalysisService(List<ActivityRecord> records)
    {
        this.records = records;
    }

    // Filter by severity
    public List<ActivityRecord> GetBySeverity(SeverityLevel level)
    {
        return records.Where(r => r.Severity == level).ToList();
    }

    // Group by module
    public Dictionary<string, int> CountByModule()
    {
        return records
            .GroupBy(r => r.SourceModule)
            .ToDictionary(g => g.Key, g => g.Count());
    }

    // Most frequent error module
    public string MostFrequentErrorModule()
    {
        var result = records
            .Where(r => r.Severity == SeverityLevel.Error || r.Severity == SeverityLevel.Critical)
            .GroupBy(r => r.SourceModule)
            .OrderByDescending(g => g.Count())
            .FirstOrDefault();

        return result?.Key ?? "None";
    }
}
