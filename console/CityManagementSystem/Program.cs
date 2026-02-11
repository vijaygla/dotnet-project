using CityManagementSystem.Models;
using CityManagementSystem.Services;
using CityManagementSystem.Utilities;

IssueService service = new();
ProcessingService processor = new();

while (true)
{
    Console.WriteLine("\n===== City Management System =====");
    Console.WriteLine("1. Report Issue");
    Console.WriteLine("2. View All Issues");
    Console.WriteLine("3. Issues from Last 24 Hours");
    Console.WriteLine("4. Department Summary");
    Console.WriteLine("5. Process Issues (Multithread)");
    Console.WriteLine("0. Exit");

    Console.Write("Choose: ");
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            try
            {
                Console.Write("Citizen Name: ");
                string name = Console.ReadLine()!;

                if (!Validator.ValidateName(name))
                    throw new Exception("Invalid name!");

                Console.Write("Location: ");
                string location = Console.ReadLine()!;

                Console.Write("Description: ");
                string desc = Console.ReadLine()!;

                var issue = new Issue
                {
                    Id = IdGenerator.Generate(),
                    CitizenName = name,
                    Location = location,
                    Description = desc,
                    CreatedTime = DateTime.Now,
                    Department = DepartmentService.GetDepartment(desc),
                    Status = IssueStatus.Created
                };

                service.AddIssue(issue);

                Console.WriteLine("Issue Added Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            break;

        case "2":
            foreach (var i in service.GetAll())
                Console.WriteLine($"{i.Id} | {i.CitizenName} | {i.Department} | {i.Status}");
            break;

        case "3":
            foreach (var i in service.GetLast24Hours())
                Console.WriteLine($"{i.Id} | {i.CitizenName} | {i.Department}");
            break;

        case "4":
            service.DepartmentSummary();
            break;

        case "5":
            processor.ProcessIssues(service.GetAll());
            Console.WriteLine("Processing Completed!");
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Invalid choice");
            break;
    }
}
