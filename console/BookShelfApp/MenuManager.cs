public class MenuManager
{
    private LibraryService libraryService;

    public MenuManager()
    {
        libraryService = new LibraryService();
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("=== Welcome to BookShelf App ===");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. Display Library");
            Console.WriteLine("4. Exit");
            Console.Write("Choose Option: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    libraryService.AddBook();
                    break;
                case 2:
                    libraryService.RemoveBook();
                    break;
                case 3:
                    libraryService.DisplayLibrary();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
