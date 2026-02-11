using CorporateTrainingSystem.Models;
using CorporateTrainingSystem.Services;
using CorporateTrainingSystem.Utilities;

EnrollmentService enrollService = new();
TrackService trackService = new();
EvaluationService evaluationService = new();

while (true)
{
    Console.WriteLine("\n===== Corporate Training System =====");
    Console.WriteLine("1. Enroll Employee");
    Console.WriteLine("2. View All Employees");
    Console.WriteLine("3. Employees by Date Range");
    Console.WriteLine("4. Run Evaluations (Multithread)");
    Console.WriteLine("5. Track Failure Summary");
    Console.WriteLine("0. Exit");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            try
            {
                Console.Write("Employee ID (EMP001): ");
                string id = Console.ReadLine()!;

                if (!Validator.ValidateEmployeeId(id))
                    throw new Exception("Invalid ID format!");

                Console.Write("Name: ");
                string name = Console.ReadLine()!;

                if (!Validator.ValidateName(name))
                    throw new Exception("Invalid name!");

                Console.Write("Track (Backend/Frontend/Database/Cloud): ");
                string trackName = Console.ReadLine()!;

                var track = trackService.GetByName(trackName);

                Employee emp = new()
                {
                    EmployeeId = id,
                    Name = name,
                    Track = track,
                    EnrollmentDate = DateTime.Now,
                    Status = ProgressStatus.Enrolled
                };

                enrollService.Enroll(emp);

                Console.WriteLine("Enrolled Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            break;

        case "2":
            foreach (var e in enrollService.GetAll())
                Console.WriteLine($"{e.EmployeeId} | {e.Name} | {e.Track.Name} | {e.Status}");
            break;

        case "3":
            Console.Write("Start days ago: ");
            int s = int.Parse(Console.ReadLine()!);

            Console.Write("End days ago: ");
            int eDays = int.Parse(Console.ReadLine()!);

            var list = enrollService.ByDateRange(
                DateTime.Now.AddDays(-s),
                DateTime.Now.AddDays(-eDays));

            foreach (var emp in list)
                Console.WriteLine($"{emp.EmployeeId} | {emp.Name}");
            break;

        case "4":
            evaluationService.RunEvaluations(enrollService.GetAll());
            Console.WriteLine("Evaluations Completed!");
            break;

        case "5":
            enrollService.TrackFailureSummary();
            break;

        case "0":
            return;
    }
}
