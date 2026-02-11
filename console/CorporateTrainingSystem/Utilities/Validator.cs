using System.Text.RegularExpressions;

namespace CorporateTrainingSystem.Utilities;

public static class Validator
{
    public static bool ValidateEmployeeId(string id)
    {
        return Regex.IsMatch(id, @"^EMP[0-9]{3}$");
    }

    public static bool ValidateName(string name)
    {
        return Regex.IsMatch(name, @"^[A-Za-z ]+$");
    }
}
