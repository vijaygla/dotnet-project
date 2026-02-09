using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCMS.Application.Services;
using SCMS.Domain.Entities;
using SCMS.Infrastructure.IO;

namespace SCMS.ConsoleApp.Menus
{
    public class CitizenMenu
    {
        private readonly CitizenService _citizenService;
        private readonly Logger _logger;

        public CitizenMenu(CitizenService citizenService, Logger logger)
        {
            _citizenService = citizenService;
            _logger = logger;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Citizen Management ===");
                Console.WriteLine("1. Register Citizen");
                Console.WriteLine("2. View All Citizens");
                Console.WriteLine("3. Find Citizen by ID");
                Console.WriteLine("4. Update Income");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Select option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RegisterCitizen();
                        break;
                    case "2":
                        ViewAllCitizens();
                        break;
                    case "3":
                        FindCitizenById();
                        break;
                    case "4":
                        UpdateIncome();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press any key...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void RegisterCitizen()
        {
            try
            {
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Age: ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("Income: ");
                decimal income = decimal.Parse(Console.ReadLine());
                Console.Write("Residency Years: ");
                int residencyYears = int.Parse(Console.ReadLine());

                var citizen = _citizenService.RegisterCitizen(name, age, income, residencyYears);
                Console.WriteLine($"Citizen registered with ID: {citizen.Id}");
                _logger.Log($"New citizen registered: {citizen.Id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                _logger.Log($"Error registering citizen: {ex.Message}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void ViewAllCitizens()
        {
            var citizens = _citizenService.GetAllCitizens();
            foreach (var citizen in citizens)
            {
                Console.WriteLine($"ID: {citizen.Id}, Name: {citizen.Name}, Age: {citizen.Age}, Score: {citizen.EligibilityScore}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void FindCitizenById()
        {
            Console.Write("Enter Citizen ID: ");
            string id = Console.ReadLine();
            var citizen = _citizenService.FindById(id);
            if (citizen != null)
            {
                Console.WriteLine($"ID: {citizen.Id}, Name: {citizen.Name}, Age: {citizen.Age}, Score: {citizen.EligibilityScore}");
            }
            else
            {
                Console.WriteLine("Citizen not found.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void UpdateIncome()
        {
            try
            {
                Console.Write("Enter Citizen ID: ");
                string id = Console.ReadLine();
                Console.Write("Enter new income: ");
                decimal newIncome = decimal.Parse(Console.ReadLine());
                _citizenService.UpdateIncome(id, newIncome);
                Console.WriteLine("Income updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
