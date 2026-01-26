using System;
using System.Collections.Generic;
using FitnessApp;

class Program
{
    static void Main()
    {
        List<User> users = new List<User>
        {
            new User("Alice", 8500),
            new User("Bob", 7200),
            new User("Charlie", 9100),
            new User("Diana", 6800),
            new User("Eve", 8900),
            new User("Frank", 7500),
            new User("Grace", 9500),
            new User("Henry", 6500)
        };

        var board = new Leaderboard(users);

        Console.WriteLine("🏃 Welcome to the Fitness Tracker App! 🏃");
        Console.WriteLine("Bubble Sort Leaderboard with Real-time Updates\n");

        board.Display();

        Console.WriteLine("⏱️ Simulating real-time step updates...\n");

        board.UpdateSteps("Bob", 2000);
        board.Display();

        board.UpdateSteps("Diana", 2500);
        board.Display();

        board.UpdateSteps("Henry", 3200);
        board.Display();

        board.UpdateSteps("Charlie", 500);
        board.Display();

        board.UpdateSteps("Frank", 1800);
        board.Display();

        Console.WriteLine("✅ End of day report generated!");
        Console.WriteLine($"Total users tracked: {board.Count}");
        Console.WriteLine($"Top performer: {board.Top.Name} with {board.Top.Steps} steps");
    }
}
