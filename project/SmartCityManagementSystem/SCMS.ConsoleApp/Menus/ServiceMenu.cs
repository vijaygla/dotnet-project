using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCMS.Application.Services;
using SCMS.Infrastructure.IO;
using SCMS.Domain.Entities;

namespace SCMS.ConsoleApp.Menus
{
    public class ServiceMenu
    {
        private readonly ServiceManager _serviceManager;
        private readonly Logger _logger;

        public ServiceMenu(ServiceManager serviceManager, Logger logger)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Service Management ===");
                Console.WriteLine("1. Book Healthcare Service");
                Console.WriteLine("2. Book Education Service");
                Console.WriteLine("3. View All Services");
                Console.WriteLine("4. Cancel Service");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Select option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BookHealthcareService();
                        break;
                    case "2":
                        BookEducationService();
                        break;
                    case "3":
                        ViewAllServices();
                        break;
                    case "4":
                        CancelService();
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

        private void BookHealthcareService()
        {
            try
            {
                Console.Write("Enter Citizen ID: ");
                string citizenId = Console.ReadLine();
                Console.Write("Enter Service Type (e.g., General Checkup, Dental): ");
                string serviceType = Console.ReadLine();
                _serviceManager.BookHealthcareService(citizenId, serviceType);
                Console.WriteLine("Healthcare service booked successfully.");
                _logger.Log($"Healthcare service booked for citizen {citizenId}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                _logger.Log($"Error booking healthcare service: {ex.Message}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void BookEducationService()
        {
            try
            {
                Console.Write("Enter Citizen ID: ");
                string citizenId = Console.ReadLine();
                Console.Write("Enter Course Level (e.g., Bachelor's, Master's): ");
                string courseLevel = Console.ReadLine();
                _serviceManager.BookEducationService(citizenId, courseLevel);
                Console.WriteLine("Education service booked successfully.");
                _logger.Log($"Education service booked for citizen {citizenId}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                _logger.Log($"Error booking education service: {ex.Message}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void ViewAllServices()
        {
            var services = _serviceManager.GetAllServices();
            if (services.Any())
            {
                foreach (var service in services)
                {
                    Console.WriteLine($"ID: {service.Id}, Citizen ID: {service.CitizenId}, Type: {service.GetType().Name}, Status: {(service.IsActive ? "Active" : "Cancelled")}");
                }
            }
            else
            {
                Console.WriteLine("No services booked.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void CancelService()
        {
            try
            {
                Console.Write("Enter Service ID to cancel: ");
                string serviceId = Console.ReadLine();
                _serviceManager.CancelService(serviceId);
                Console.WriteLine("Service cancelled successfully.");
                _logger.Log($"Service {serviceId} cancelled.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                _logger.Log($"Error cancelling service: {ex.Message}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
