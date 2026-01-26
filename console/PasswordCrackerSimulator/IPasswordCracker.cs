namespace PasswordCrackerSimulator
{
    // Abstraction using Interface
    public interface IPasswordCracker
    {
        // Method to start cracking password
        void CrackPassword(int length);
    }
}
