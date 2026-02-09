using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCMS.Domain.Entities;
using SCMS.Infrastructure.Repositories;
using SCMS.Common.Exceptions;
using SCMS.Common.Utilities;
using SCMS.Infrastructure.IO;

namespace SCMS.Application.Services
{
    public class CitizenService
    {
        private readonly CitizenRepository repository;
        private readonly ValidationService validationService;
        private readonly Logger logger;

        public CitizenService()
        {
            repository = new CitizenRepository();
            validationService = new ValidationService();
            logger = new Logger();
        }

        public Citizen RegisterCitizen(string name, int age, decimal income, int residencyYears)
        {
            validationService.ValidateCitizenData(name, age, income, residencyYears);

            string citizenId = IdGenerator.GenerateCitizenId();

            if (repository.Exists(citizenId))
                throw new DuplicateCitizenException("Citizen ID already exists");

            if (age < 18)
                throw new UnderageException("Citizen must be 18 or older");

            decimal eligibilityScore = CalculateEligibilityScore(age, income, residencyYears);

            Citizen citizen = new Citizen(citizenId, name, age, income, residencyYears, eligibilityScore);
            repository.Save(citizen);
            logger.Log($"Citizen registered: {citizenId}");

            return citizen;
        }

        public List<Citizen> GetAllCitizens()
        {
            return repository.GetAll();
        }

        public Citizen FindById(string id)
        {
            return repository.FindById(id);
        }

        public void UpdateIncome(string citizenId, decimal newIncome)
        {
            Citizen citizen = repository.FindById(citizenId) ?? throw new ArgumentException("Citizen not found");
            citizen.Income = newIncome;
            citizen.EligibilityScore = CalculateEligibilityScore(citizen.Age, newIncome, citizen.ResidencyYears);
            repository.Save(citizen);
        }

        private decimal CalculateEligibilityScore(int age, decimal income, int residencyYears)
        {
            decimal ageScore = age > 60 ? 30 : age > 30 ? 20 : 10;
            decimal incomeScore = income > 50000 ? 30 : income > 20000 ? 20 : 10;
            decimal residencyScore = residencyYears > 10 ? 40 : residencyYears > 5 ? 30 : 20;

            return ageScore + incomeScore + residencyScore;
        }
    }
}
