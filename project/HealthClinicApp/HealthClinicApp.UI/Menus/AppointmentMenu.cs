using HealthClinicApp.BLL.Services;
using HealthClinicApp.Models.Entities;

namespace HealthClinicApp.UI.Menus;

public class AppointmentMenu
{
    private readonly AppointmentService service = new();

    public void Start()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("=== APPOINTMENT MANAGEMENT ===");
            Console.WriteLine("1. Book Appointment");
            Console.WriteLine("2. View Appointments");
            Console.WriteLine("0. Back");
            Console.Write("\nSelect option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BookAppointment();
                    break;

                case "2":
                    ViewAppointments();
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
    // BOOK APPOINTMENT
    // -------------------------
    private void BookAppointment()
    {
        Console.Clear();
        Console.WriteLine("Book Appointment\n");

        Console.Write("Patient Id: ");
        int patientId = int.TryParse(Console.ReadLine(), out int pid) ? pid : 0;

        Console.Write("Doctor Id: ");
        int doctorId = int.TryParse(Console.ReadLine(), out int did) ? did : 0;

        Console.Write("Appointment Date (yyyy-MM-dd HH:mm): ");
        DateTime date =
            DateTime.TryParse(Console.ReadLine(), out DateTime dt) ? dt : DateTime.Now;

        service.Book(new Appointment
        {
            PatientId = patientId,
            DoctorId = doctorId,
            AppointmentDate = date,
            Status = "SCHEDULED"
        });

        Console.WriteLine("\n✅ Appointment Booked Successfully!");
        Pause();
    }

    // -------------------------
    // VIEW APPOINTMENTS
    // -------------------------
    private void ViewAppointments()
    {
        Console.Clear();
        Console.WriteLine("Appointment List\n");

        var list = service.GetAllAppointments();

        if (list.Count == 0)
        {
            Console.WriteLine("No appointments found.");
        }
        else
        {
            foreach (var a in list)
            {
                Console.WriteLine(
                    $"{a.AppointmentId} | Patient:{a.PatientId} | Doctor:{a.DoctorId} | {a.AppointmentDate} | {a.Status}");
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
