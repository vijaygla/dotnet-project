namespace AdharSortingSystem
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter number of Aadhar entries : ");
            int n = int.Parse(Console.ReadLine());

            long[] adharNumber = new long[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter 12-digit Aadhar {i + 1}: ");
                adharNumber[i] = long.Parse(Console.ReadLine());
            }

            AdharManager manager = new AdharManager(adharNumber);

            while (true)
            {
                Console.WriteLine("\n--- Aadhar Sorting System ---");
                Console.WriteLine("1. Sort Aadhar Numbers");
                Console.WriteLine("2. Display Aadhar Numbers");
                Console.WriteLine("3. Search Aadhar Number");
                Console.WriteLine("4. Exit");
                Console.Write("Choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        manager.SortAdharNumber();
                        break;

                    case 2:
                        manager.Display();
                        break;

                    case 3:
                        Console.Write("Enter Aadhar to search: ");
                        long search = long.Parse(Console.ReadLine());
                        manager.Search(search);
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}
