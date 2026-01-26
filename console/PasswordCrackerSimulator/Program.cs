using System;

namespace PasswordCrackerSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🔐 Password Cracker Simulator (Backtracking)");

            Console.Write("\nEnter password length: ");
            int length = int.Parse(Console.ReadLine());

            Console.Write("Enter password to crack: ");
            string password = Console.ReadLine();

            // Interface reference – Loose Coupling
            IPasswordCracker cracker = new PasswordCracker(password);

            // Start cracking
            cracker.CrackPassword(length);

            // Scenario C – Complexity
            ComplexityVisualizer.ShowComplexity(5, length);

            Console.WriteLine("\nSimulation Completed.");
        }
    }
}
