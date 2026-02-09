using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCMS.ConsoleApp.Menus;
using SCMS.Application.Services;
using SCMS.Infrastructure.IO;
using SCMS.Infrastructure.Repositories;

namespace SCMS.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Logger logger = new Logger();
            CitizenService citizenService = new CitizenService();
            ServiceManager serviceManager = new ServiceManager();

            MainMenu mainMenu = new MainMenu(citizenService, serviceManager, logger);
            mainMenu.Show();
        }
    }
}
