using LogVaultApp.Models;
using LogVaultApp.Utilities;

namespace LogVaultApp.Services;

public class FileLoggerService
{
    private readonly string filePath;

    public FileLoggerService(string path)
    {
        filePath = path;
    }

    // Write one record to file
    public void Write(ActivityRecord record)
    {
        try
        {
            // validate first
            if (!ValidatorHelper.IsValid(record))
                return;

            File.AppendAllText(filePath, record.ToFileString() + Environment.NewLine);
        }
        catch
        {
            // skip if error happens
        }
    }
}
