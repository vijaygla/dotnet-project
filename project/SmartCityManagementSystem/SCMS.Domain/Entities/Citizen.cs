using System;

namespace SCMS.Domain.Entities
{
    public class Citizen
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Income { get; set; }
        public int ResidencyYears { get; set; }
        public decimal EligibilityScore { get; set; }
        public DateTime RegistrationDate { get; set; }

        public Citizen(string id, string name, int age, decimal income, int residencyYears, decimal eligibilityScore)
        {
            Id = id;
            Name = name;
            Age = age;
            Income = income;
            ResidencyYears = residencyYears;
            EligibilityScore = eligibilityScore;
            RegistrationDate = DateTime.Now;
        }

        public string GetEligibilityStatus()
        {
            return EligibilityScore >= 80 ? "Platinum" :
                   EligibilityScore >= 60 ? "Gold" :
                   EligibilityScore >= 40 ? "Silver" : "Basic";
        }
    }
}
