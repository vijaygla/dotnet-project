using System.Text.RegularExpressions;

namespace CityManagementSystem.Utilities;

public static class Validator
{
    public static bool ValidateName(string name)
    {
        return Regex.IsMatch(name, @"^[A-Za-z ]+$");
    }

    public static bool ValidateLocation(string location)
    {
        return location.Length >= 3;
    }
}
