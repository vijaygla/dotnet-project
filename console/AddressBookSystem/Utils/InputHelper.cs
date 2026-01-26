namespace AddressBookSystem.Utils
{
    public static class InputHelper
    {
        public static int ReadInt(string msg)
        {
            Console.Write(msg);
            int val;
            while (!int.TryParse(Console.ReadLine(), out val))
                Console.Write("Invalid input, try again: ");
            return val;
        }

        public static string ReadString(string msg)
        {
            Console.Write(msg);
            return Console.ReadLine();
        }
    }
}
