using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesScheduleManager
{
    internal class MoviesUtility
    {
        private string[] movieTitles;
        private string[] showTime;
        private int movieCount = 0;

        // Add movie
        public void AddMovie()
        {
            Console.WriteLine("Enter number of movies");
            int numberMovies = int.Parse(Console.ReadLine());
            movieTitles = new string[numberMovies];
            showTime = new string[numberMovies];
            for (int i = 0; i < numberMovies; i++)
            {
                Console.Write($"Enter movie name{i + 1}:");
                movieTitles[i] = Console.ReadLine();
                Console.Write($"Enter show time{i + 1}:");
                showTime[i] = Console.ReadLine();
                Console.WriteLine("Movie added succesfully!");
                movieCount++;


            }
        }

        // Search movie 
        public void SearchMovie()
        {
            string name = Console.ReadLine();

            for (int i = 0; i < movieCount; i++)
            {
                if (movieTitles[i].Contains(name))
                {
                    Console.WriteLine("Movie Found: " + movieTitles[i] + " at " + showTime[i]);
                    return;
                }
            }


            Console.WriteLine("Movie not Found.");

        }

        // Display all movies
        public void DisplayMovie()
        {
            Console.WriteLine("\nMovie List:");

            if (movieCount == 0)
            {
                Console.WriteLine("No movies available.");
                return;
            }

            for (int i = 0; i < movieCount; i++)
            {
                Console.WriteLine(movieTitles[i] + " : " + showTime[i]);
            }
        }
    }
}
