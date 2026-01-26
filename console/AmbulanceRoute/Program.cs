using AmbulanceRoute.DataStructures;
using AmbulanceRoute.Models;
using AmbulanceRoute.Utils;

namespace AmbulanceRoute
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            CircularLinkedList route = new CircularLinkedList();

            // Default hospital layout
            route.AddUnit(new HospitalUnit("Emergency", true));
            route.AddUnit(new HospitalUnit("Radiology", true));
            route.AddUnit(new HospitalUnit("Surgery", true));
            route.AddUnit(new HospitalUnit("ICU", true));

            while (isRunning)
            {
                Console.WriteLine("\n=== Ambulance Route System ===");
                Console.WriteLine("1. View Hospital Units");
                Console.WriteLine("2. Redirect Ambulance (Find Available Unit)");
                Console.WriteLine("3. Mark Unit Under Maintenance");
                Console.WriteLine("4. Restore Unit");
                Console.WriteLine("0. Exit");

                int choice = InputHelper.ReadInt("Enter choice: ");

                switch (choice)
                {
                    case 1:
                        route.DisplayUnits();
                        break;

                    case 2:
                        route.FindNearestAvailableUnit();
                        break;

                    case 3:
                        string remove = InputHelper.ReadString("Enter unit name to mark under maintenance: ");
                        route.MarkUnavailable(remove);
                        break;

                    case 4:
                        string restore = InputHelper.ReadString("Enter unit name to restore: ");
                        route.MarkAvailable(restore);
                        break;

                    case 0:
                        Console.WriteLine("Shutting down Ambulance Route System...");
                        isRunning = false;   // ✅ STOP CONDITION
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
