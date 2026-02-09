using System.Text.RegularExpressions;

public static class RegexValidator
{
    private static readonly Regex emailRegex = new(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
    private static readonly Regex citizenIdRegex = new(@"^TC-\d{4}-\d{5}$");
    private static readonly Regex phoneRegex = new(@"^\+91[-\s]?\d{10}$");

    public static bool IsValidEmail(string email)
    {
        return emailRegex.IsMatch(email);
    }

    public static bool IsValidCitizenId(string id)
    {
        return citizenIdRegex.IsMatch(id);
    }

    public static bool IsValidPhone(string phone)
    {
        return phoneRegex.IsMatch(phone);
    }
}
