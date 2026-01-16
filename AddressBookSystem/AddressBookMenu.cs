using System;

namespace AddressBookSystem
{
    internal class AddressBookMenu
    {
        public void StartMenu()
        {
            AddressBookManager Manager = new AddressBookManager();
            AddressBook Book = Manager.GetAddressBook();

            while (true)
            {
                Console.WriteLine("1 Add  2 Edit  3 Delete  4 Display  5 Sort  6 Exit");
                int Choice = Convert.ToInt32(Console.ReadLine());

                if (Choice == 6)
                {
                    break;
                }

                if (Choice == 1)
                {
                    Console.WriteLine("Enter first name:");
                    string FirstName = Console.ReadLine();

                    Console.WriteLine("Enter last name:");
                    string LastName = Console.ReadLine();

                    Console.WriteLine("Enter address:");
                    string Address = Console.ReadLine();

                    Console.WriteLine("Enter city:");
                    string City = Console.ReadLine();

                    Console.WriteLine("Enter state:");
                    string State = Console.ReadLine();

                    Console.WriteLine("Enter pin code:");
                    string PinCode = Console.ReadLine();

                    Console.WriteLine("Enter phone number:");
                    string PhoneNumber = Console.ReadLine();

                    Console.WriteLine("Enter email:");
                    string Email = Console.ReadLine();

                    Contact NewContact =
                        new Contact(
                            FirstName,
                            LastName,
                            Address,
                            City,
                            State,
                            PinCode,
                            PhoneNumber,
                            Email);

                    Book.AddContact(NewContact);
                }
                else if (Choice == 2)
                {
                    Console.WriteLine("Enter first name to edit:");
                    Book.EditContact(Console.ReadLine());
                }
                else if (Choice == 3)
                {
                    Console.WriteLine("Enter first name to delete:");
                    Book.DeleteContact(Console.ReadLine());
                }
                else if (Choice == 4)
                {
                    Book.DisplayContacts();
                }
                else if (Choice == 5)
                {
                    Book.SortByName();
                }
            }
        }
    }
}
