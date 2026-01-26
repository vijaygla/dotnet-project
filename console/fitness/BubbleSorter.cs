using System.Collections.Generic;

namespace FitnessApp
{
    public static class BubbleSorter
    {
        // Sort descending by Steps
        public static void Sort(List<User> users)
        {
            int n = users.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (users[j].Steps < users[j + 1].Steps)
                    {
                        var tmp = users[j];
                        users[j] = users[j + 1];
                        users[j + 1] = tmp;
                    }
                }
            }
        }
    }
}
