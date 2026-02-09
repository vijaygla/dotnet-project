using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SCMS.Domain.Entities;
using System.Text.Json;

namespace SCMS.Infrastructure.IO
{
    public static class FileManager
    {
        private static readonly string citizensFile = "citizens.json";

        public static List<Citizen> LoadCitizens()
        {
            try
            {
                if (File.Exists(citizensFile))
                {
                    string json = File.ReadAllText(citizensFile);
                    return JsonSerializer.Deserialize<List<Citizen>>(json) ?? new List<Citizen>();
                }
            }
            catch
            {
                // Handle file read errors silently
            }
            return new List<Citizen>();
        }

        public static void SaveCitizens(List<Citizen> citizens)
        {
            try
            {
                string json = JsonSerializer.Serialize(citizens, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(citizensFile, json);
            }
            catch
            {
                // Handle file write errors silently
            }
        }
    }
}
