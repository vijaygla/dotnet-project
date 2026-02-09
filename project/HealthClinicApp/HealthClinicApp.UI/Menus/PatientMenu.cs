using HealthClinicApp.BLL.Services;
using HealthClinicApp.Models.Entities;

namespace HealthClinicApp.UI.Menus;

public class PatientMenu
{
    private readonly PatientService service = new();

    public void Start()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("=== PATIENT MANAGEMENT ===");
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. Update Patient");
            Console.WriteLine("3. Search by Phone");
            Console.WriteLine("4. View All Patients");
            Console.WriteLine("0. Back");
            Console.Write("\nSelect option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddPatient();
                    break;

                case "2":
                    UpdatePatient();
                    break;

                case "3":
                    SearchPatient();
                    break;

                case "4":
                    ViewAll();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid choice!");
                    Pause();
                    break;
            }
        }
    }

    // -------------------------
    // ADD PATIENT
    // -------------------------
    private void AddPatient()
    {
        Console.Clear();
        Console.WriteLine("Add New Patient\n");

        Console.Write("Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Phone: ");
        string phone = Console.ReadLine() ?? "";

        service.Register(new Patient
        {
            FirstName = name,
            Phone = phone
        });

        Console.WriteLine("\n✅ Patient Added Successfully!");
        Pause();
    }

    // -------------------------
    // UPDATE PATIENT
    // -------------------------
    private void UpdatePatient()
    {
        Console.Clear();
        Console.WriteLine("Update Patient\n");

        Console.Write("Patient Id: ");
        int id = int.TryParse(Console.ReadLine(), out int pid) ? pid : 0;

        Console.Write("New Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Phone: ");
        string phone = Console.ReadLine() ?? "";

        service.Update(new Patient
        {
            PatientId = id,
            FirstName = name,
            Phone = phone
        });

        Console.WriteLine("\n✅ Patient Updated Successfully!");
        Pause();
    }

    // -------------------------
    // SEARCH PATIENT
    // -------------------------
    private void SearchPatient()
    {
        Console.Clear();
        Console.WriteLine("Search Patient\n");

        Console.Write("Phone: ");
        string phone = Console.ReadLine() ?? "";

        var p = service.SearchByPhone(phone);

        if (p == null)
            Console.WriteLine("❌ Patient Not Found");
        else
            Console.WriteLine($"{p.PatientId} | {p.FirstName} | {p.Phone}");

        Pause();
    }

    // -------------------------
    // VIEW ALL PATIENTS
    // -------------------------
    private void ViewAll()
    {
        Console.Clear();
        Console.WriteLine("Patient List\n");

        var list = service.GetAll();

        if (list.Count == 0)
        {
            Console.WriteLine("No patients found.");
        }
        else
        {
            foreach (var p in list)
            {
                Console.WriteLine($"{p.PatientId} | {p.FirstName} | {p.Phone}");
            }
        }

        Pause();
    }

    // -------------------------
    private void Pause()
    {
        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
