using ParcelTracker.Services;

namespace ParcelTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            ParcelTrackerService tracker = new ParcelTrackerService();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n === Parcel Tracker Menu ===");
                Console.WriteLine("1. Add Delivery Stage");
                Console.WriteLine("2. Add Checkpoint After Stage");
                Console.WriteLine("3. Track Parcel");
                Console.WriteLine("4. Mark Parcel as Lost");
                Console.WriteLine("5. Exit");
                Console.Write("Choose option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Enter stage name: ");
                        tracker.AddStage(Console.ReadLine());
                        break;

                    case "2":
                        Console.Write("Enter existing stage: ");
                        string existing = Console.ReadLine();
                        Console.Write("Enter new checkpoint: ");
                        string checkpoint = Console.ReadLine();
                        tracker.AddCheckpointAfter(existing, checkpoint);
                        break;

                    case "3":
                        tracker.TrackParcel();
                        break;

                    case "4":
                        tracker.MarkParcelLost();
                        break;

                    case "5":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
