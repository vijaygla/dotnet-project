using System;
using System.Collections.Generic;

namespace FitnessApp
{
    public class Leaderboard
    {
        private List<User> users;

        public Leaderboard(List<User> users)
        {
            this.users = users;
            BubbleSorter.Sort(this.users);
        }

        public void UpdateSteps(string name, int delta)
        {
            var u = users.Find(x => x.Name == name);
            if (u != null)
            {
                u.Steps += delta;
                Console.WriteLine($"\n✓ {name} synced {delta} new steps! Total: {u.Steps}");
                BubbleSorter.Sort(users);
            }
        }

        public void Display()
        {
            Console.WriteLine("\n═══════════════════════════════════════");
            Console.WriteLine("       📊 FITNESS LEADERBOARD 📊");
            Console.WriteLine("═══════════════════════════════════════");

            for (int rank = 0; rank < users.Count; rank++)
            {
                string medal = rank switch
                {
                    0 => "🥇",
                    1 => "🥈",
                    2 => "🥉",
                    _ => $"#{rank + 1}"
                };
                Console.WriteLine($"{medal} {users[rank].Name.PadRight(15)} - {users[rank].Steps} steps");
            }
            Console.WriteLine("═══════════════════════════════════════\n");
        }

        public int Count => users.Count;

        public User Top => users.Count > 0 ? users[0] : null;
    }
}
