using System;

namespace PasswordCrackerSimulator
{
    public class PasswordCracker : IPasswordCracker
    {
        // Character set used to generate combinations
        private char[] charSet = { 'a', 'b', 'c', '1', '2' };

        private string targetPassword;
        private bool isFound = false;
        private int attempt = 0;

        // Constructor (Encapsulation)
        public PasswordCracker(string password)
        {
            targetPassword = password;
        }

        // Entry method
        public void CrackPassword(int length)
        {
            char[] current = new char[length];

            // Start Backtracking
            Backtrack(0, current);

            Console.WriteLine($"\nTotal number of attempts made: {attempt}");
        }

        // ================= BACKTRACKING =================
        private void Backtrack(int index, char[] current)
        {
            // -------- Scenario B --------
            // Stop recursion once password is found
            if (isFound)
                return;

            // -------- Scenario A --------
            // One full combination generated
            if (index == current.Length)
            {
                attempt++;
                string guess = new string(current);

                Console.WriteLine($"Trying guess: {guess}");

                // -------- Scenario B --------
                // Check if password matches
                if (guess.Equals(targetPassword))
                {
                    Console.WriteLine("\n✅ Password cracked successfully!");
                    Console.WriteLine($"Password: {guess}");
                    isFound = true;
                }
                return; // stop this branch
            }

            // Try all characters at current index
            foreach (char ch in charSet)
            {
                current[index] = ch;
                Backtrack(index + 1, current);
            }
        }
    }
}
