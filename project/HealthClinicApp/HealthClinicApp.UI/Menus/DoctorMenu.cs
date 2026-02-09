using HealthClinicApp.BLL.Services;
using HealthClinicApp.Models.Entities;

namespace HealthClinicApp.UI.Menus;

public class DoctorMenu
{
    private readonly DoctorService service = new();
    private readonly SpecialtyService _specialtyService = new();

    public void Start()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("=== DOCTOR MANAGEMENT ===");
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. View Doctors");
            Console.WriteLine("0. Back");
            Console.Write("\nSelect option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddDoctor();
                    break;

                case "2":
                    ViewDoctors();
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
    // Add Doctor
    // -------------------------
    private void AddDoctor()
    {
        Console.Clear();
        Console.WriteLine("Add New Doctor\n");

        Console.Write("Doctor Name: ");
        string name = Console.ReadLine() ?? "";

        Console.WriteLine("\n--- Available Specialties ---");
        var specialties = _specialtyService.GetAll();
        foreach (var s in specialties)
        {
            Console.WriteLine($"{s.SpecialtyId}. {s.SpecialtyName} ({s.Description})");
        }
        Console.WriteLine("-----------------------------");

        int specialtyId = 0;
        bool isValidSpecialtyId = false;
        while (!isValidSpecialtyId)
        {
            Console.Write("Enter Specialty Id: ");
            if (int.TryParse(Console.ReadLine(), out int sid) && specialties.Any(s => s.SpecialtyId == sid))
            {
                specialtyId = sid;
                isValidSpecialtyId = true;
            }
            else
            {
                Console.WriteLine("Invalid Specialty Id. Please choose from the list above.");
            }
        }

        Console.Write("Consultation Fee: ");
        decimal fee = decimal.TryParse(Console.ReadLine(), out decimal f) ? f : 0;

        service.AddDoctor(new Doctor
        {
            Name = name,
            SpecialtyId = specialtyId,
            Fee = fee
        });

        Console.WriteLine("\n✅ Doctor Added Successfully!");
        Pause();
    }

    // -------------------------
    // View Doctors
    // -------------------------
    private void ViewDoctors()
    {
        Console.Clear();
        Console.WriteLine("Doctor List\n");

        var doctors = service.GetAllDoctors();   // service method

        if (doctors.Count == 0)
        {
            Console.WriteLine("No doctors found.");
        }
        else
        {
            foreach (var d in doctors)
            {
                Console.WriteLine(
                    $"{d.DoctorId} | {d.Name} | Specialty:{d.SpecialtyId} | Fee:{d.Fee}");
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
