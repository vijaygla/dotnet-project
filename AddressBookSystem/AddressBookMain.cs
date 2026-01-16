using System;

namespace AddressBookSystem
{
    internal class AddressBookMain
    {
        static void Main(string[] Args)
        {
            // uc-0
            Console.WriteLine("Welcome to Address Book System");

            AddressBookMenu Menu = new AddressBookMenu();
            Menu.StartMenu();
        }
    }
}
