using LogVaultApp.Models;
using LogVaultApp.Services;

string path = "logs.txt";

FileLoggerService logger = new(path);
RecordReaderService reader = new(path);

while (true)
{
    Console.WriteLine("\n===== LOG VAULT =====");
    Console.WriteLine("1. Add Record");
    Console.WriteLine("2. Show All Records");
    Console.WriteLine("3. Show Error Records");
    Console.WriteLine("4. Most Frequent Error Module");
    Console.WriteLine("5. Exit");

    Console.Write("Enter choice: ");
    int choice = int.Parse(Console.ReadLine());

    if (choice == 5) break;

    switch (choice)
    {
        case 1:
            Console.Write("ID: ");
            string id = Console.ReadLine();

            Console.Write("Module: ");
            string module = Console.ReadLine();

            Console.Write("Severity (Info/Warning/Error/Critical): ");
            SeverityLevel sev = Enum.Parse<SeverityLevel>(Console.ReadLine());

            Console.Write("Message: ");
            string msg = Console.ReadLine();

            logger.Write(new ActivityRecord
            {
                RecordId = id,
                SourceModule = module,
                Severity = sev,
                Message = msg
            });

            Console.WriteLine("Saved!");
            break;

        case 2:
            var all = reader.ReadAll();
            all.ForEach(r => Console.WriteLine(r.ToFileString()));
            break;

        case 3:
            var service = new AnalysisService(reader.ReadAll());
            var errors = service.GetBySeverity(SeverityLevel.Error);
            errors.ForEach(r => Console.WriteLine(r.ToFileString()));
            break;

        case 4:
            var analysis = new AnalysisService(reader.ReadAll());
            Console.WriteLine("Module: " + analysis.MostFrequentErrorModule());
            break;
    }
}
