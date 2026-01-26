namespace AmbulanceRoute.Utils
{
    public static class InputHelper
    {
        public static int ReadInt(string message)
        {
            Console.Write(message);
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
                Console.Write("Invalid input. Try again: ");
            return value;
        }

        public static string ReadString(string message)
        {
            Console.Write(message);
            return Console.ReadLine() ?? "";
        }
    }
}
