using System;

namespace BookBuddy
{
    internal class BookMenu
    {
        public void ShowMenu()
        {
            BookUtility utility = new BookUtility();

            while (true)
            {
                Console.WriteLine("\n📚 BookBuddy Menu");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Sort Books Alphabetically");
                Console.WriteLine("3. Search Book by Author");
                Console.WriteLine("4. Export Books");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter book title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter author name: ");
                        string author = Console.ReadLine();
                        utility.AddBook(title, author);
                        break;

                    case 2:
                        utility.SortBooksAlphabetically();
                        break;

                    case 3:
                        Console.Write("Enter author name to search: ");
                        string searchAuthor = Console.ReadLine();
                        utility.SearchByAuthor(searchAuthor);
                        break;

                    case 4:
                        utility.ExportBooks();
                        break;

                    case 5:
                        Console.WriteLine("Exiting BookBuddy...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
}
