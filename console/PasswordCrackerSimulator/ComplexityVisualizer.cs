using System;

namespace PasswordCrackerSimulator
{
    // Displays TIME & SPACE complexity information
    public static class ComplexityVisualizer
    {
        public static void ShowComplexity(int charsetSize, int length)
        {
            double totalCombinations = Math.Pow(charsetSize, length);

            Console.WriteLine("\n--- Complexity Visualization ---");

            // -------- Scenario C --------
            Console.WriteLine($"Character Set Size (k): {charsetSize}");
            Console.WriteLine($"Password Length (n): {length}");
            Console.WriteLine($"Total Possible Combinations: k^n = {totalCombinations}");

            Console.WriteLine("\nTime Complexity:");
            Console.WriteLine("O(k^n)  -> Exponential");

            Console.WriteLine("\nSpace Complexity:");
            Console.WriteLine("O(n)    -> Recursion stack depth");
        }
    }
}
