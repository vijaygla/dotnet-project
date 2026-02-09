using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCMS.Application.Services;
using SCMS.Infrastructure.IO;
using SCMS.ConsoleApp.Menus;

namespace SCMS.ConsoleApp.Menus
{
    public class MainMenu
    {
        private readonly CitizenService citizenService;
        private readonly ServiceManager serviceManager;
        private readonly Logger logger;

        public MainMenu(CitizenService citizenService, ServiceManager serviceManager, Logger logger)
        {
            this.citizenService = citizenService;
            this.serviceManager = serviceManager;
            this.logger = logger;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== TechVille Smart City Management System ===");
                Console.WriteLine("1. Citizen Management");
                Console.WriteLine("2. Service Management");
                Console.WriteLine("3. Exit");
                Console.Write("Select option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CitizenMenu citizenMenu = new CitizenMenu(citizenService, logger);
                        citizenMenu.Show();
                        break;
                    case "2":
                        ServiceMenu serviceMenu = new ServiceMenu(serviceManager, logger);
                        serviceMenu.Show();
                        break;
                    case "3":
                        logger.Log("System shutdown");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press any key...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
