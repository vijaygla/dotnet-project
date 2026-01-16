using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesScheduleManager
{
    internal class MoviesMenu
    {
        public void ShowMenu()
        {
            MoviesUtility utility = new MoviesUtility();
            while (true)
            {
                Console.WriteLine("\nCinemaTime ");
                Console.WriteLine("1. Add Movie");
                Console.WriteLine("2. Search Movie");
                Console.WriteLine("3. Display All Movies");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        utility.AddMovie();
                        break;

                    case 2:
                        Console.Write("Enter movie name to search: ");
                        utility.SearchMovie();
                        break;

                    case 3:
                        utility.DisplayMovie();
                        break;

                    case 4:
                        Console.WriteLine("Exiting CinemaTime...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
