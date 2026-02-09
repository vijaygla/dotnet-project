using System;
using System.IO;

namespace SCMS.Infrastructure.IO
{
    public class Logger
    {
        private readonly string logFile = "system.log";

        public void Log(string message)
        {
            try
            {
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}\n";
                File.AppendAllText(logFile, logEntry);
            }
            catch
            {
                // Silent fail for logging
            }
        }
    }
}
