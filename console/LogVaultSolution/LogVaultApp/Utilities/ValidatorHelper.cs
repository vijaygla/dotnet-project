using System.ComponentModel.DataAnnotations;

namespace LogVaultApp.Utilities;

public static class ValidatorHelper
{
    // Check if object is valid
    public static bool IsValid(object obj)
    {
        var context = new ValidationContext(obj);
        var results = new List<ValidationResult>();

        return Validator.TryValidateObject(obj, context, results, true);
    }
}
