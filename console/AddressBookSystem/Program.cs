using AddressBookSystem.Services;
using AddressBookSystem.Utils;

namespace AddressBookSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            AddressBookService service = new AddressBookService();

            Console.WriteLine("Welcome to Address Book System");

            while (isRunning)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. Add Address Book");
                Console.WriteLine("2. Add Contact");
                Console.WriteLine("3. Edit Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Display Contacts");
                Console.WriteLine("6. Search Person by City/State");
                Console.WriteLine("7. Count by City/State");
                Console.WriteLine("8. Sort by Name");
                Console.WriteLine("9. Sort by City/State/Zip");
                Console.WriteLine("0. Exit");

                int choice = InputHelper.ReadInt("Enter choice: ");

                switch (choice)
                {
                    case 1: service.AddAddressBook(); break;
                    case 2: service.AddContact(); break;
                    case 3: service.EditContact(); break;
                    case 4: service.DeleteContact(); break;
                    case 5: service.DisplayContacts(); break;
                    case 6: service.SearchByCityOrState(); break;
                    case 7: service.CountByCityOrState(); break;
                    case 8: service.SortByName(); break;
                    case 9: service.SortByCityStateZip(); break;
                    case 0:
                        isRunning = false;   // stop program
                        Console.WriteLine("Exiting Address Book System...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
