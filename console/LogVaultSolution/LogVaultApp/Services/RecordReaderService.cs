using LogVaultApp.Models;

namespace LogVaultApp.Services;

public class RecordReaderService
{
    private readonly string filePath;

    public RecordReaderService(string path)
    {
        filePath = path;
    }

    // Read all records
    public List<ActivityRecord> ReadAll()
    {
        List<ActivityRecord> list = new();

        if (!File.Exists(filePath))
            return list;

        foreach (var line in File.ReadAllLines(filePath))
        {
            try
            {
                list.Add(ActivityRecord.FromFileString(line));
            }
            catch
            {
                // skip bad record
            }
        }

        return list;
    }
}
