using AddressBookSonarQube.Core.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace AddressBookSonarQube.Core.Utilities;

public static class FileManager
{
    public static void SaveToFile(Dictionary<string, AddressBook> books, string filePath)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(books, options);
        File.WriteAllText(filePath, json);
    }

    public static Dictionary<string, AddressBook> LoadFromFile(string filePath)
    {
        if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
            return new Dictionary<string, AddressBook>();

        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<Dictionary<string, AddressBook>>(json)
               ?? new Dictionary<string, AddressBook>();
    }
}
