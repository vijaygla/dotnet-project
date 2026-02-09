using HealthClinicApp.UI.Menus;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("🏥 HEALTH CLINIC MANAGEMENT SYSTEM");
            Console.WriteLine("==================================");
            Console.WriteLine("1. Patient Management");
            Console.WriteLine("2. Doctor Management");
            Console.WriteLine("3. Appointment Management");
            Console.WriteLine("0. Exit");
            Console.Write("\nSelect option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new PatientMenu().Start();
                    break;

                case "2":
                    new DoctorMenu().Start();
                    break;

                case "3":
                    new AppointmentMenu().Start();
                    break;

                case "0":
                    Console.WriteLine("Thank you. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Press any key...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
