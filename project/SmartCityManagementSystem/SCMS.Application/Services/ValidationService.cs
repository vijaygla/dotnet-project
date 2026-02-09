using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCMS.Common.Utilities;
using SCMS.Common.Exceptions;

namespace SCMS.Application.Services
{
    public class ValidationService
    {
        public void ValidateCitizenData(string name, int age, decimal income, int residencyYears)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 2)
                throw new ArgumentException("Name must be at least 2 characters");

            if (age < 0 || age > 120)
                throw new ArgumentException("Invalid age");

            if (income < 0)
                throw new ArgumentException("Income cannot be negative");

            if (residencyYears < 0)
                throw new ArgumentException("Residency years cannot be negative");

            if (!RegexValidator.IsValidEmail("test@techville.com")) // Example validation
                throw new ArgumentException("Invalid email format");
        }
    }
}
