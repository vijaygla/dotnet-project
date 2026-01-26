using AddressBookSystem.Models;
using AddressBookSystem.Utils;

namespace AddressBookSystem.Services
{
    public class AddressBookService
    {
        // Dictionary to store multiple address books
        private Dictionary<string, AddressBook> addressBooks = new();

        private AddressBook GetAddressBook()
        {
            string name = InputHelper.ReadString("Enter Address Book Name: ");
            if (!addressBooks.ContainsKey(name))
            {
                Console.WriteLine("Address Book not found.");
                return null;
            }
            return addressBooks[name];
        }

        // UC6
        public void AddAddressBook()
        {
            string name = InputHelper.ReadString("Enter new Address Book name: ");
            if (!addressBooks.ContainsKey(name))
            {
                addressBooks[name] = new AddressBook { Name = name };
                Console.WriteLine("Address Book added.");
            }
            else
            {
                Console.WriteLine("Address Book already exists.");
            }
        }

        // UC2 + UC7
        public void AddContact()
        {
            AddressBook book = GetAddressBook();
            if (book == null) return;

            Person person = new Person
            {
                FirstName = InputHelper.ReadString("First Name: "),
                LastName = InputHelper.ReadString("Last Name: "),
                Address = InputHelper.ReadString("Address: "),
                City = InputHelper.ReadString("City: "),
                State = InputHelper.ReadString("State: "),
                Zip = InputHelper.ReadString("Zip: "),
                Phone = InputHelper.ReadString("Phone: "),
                Email = InputHelper.ReadString("Email: ")
            };

            if (book.Persons.Contains(person))
                Console.WriteLine("Duplicate contact not allowed.");
            else
            {
                book.Persons.Add(person);
                Console.WriteLine("Contact added successfully.");
            }
        }

        // UC3
        public void EditContact()
        {
            AddressBook book = GetAddressBook();
            if (book == null) return;

            string name = InputHelper.ReadString("Enter First Name to edit: ");
            Person person = book.Persons.FirstOrDefault(p => p.FirstName == name);

            if (person == null)
            {
                Console.WriteLine("Person not found.");
                return;
            }

            person.City = InputHelper.ReadString("New City: ");
            person.State = InputHelper.ReadString("New State: ");
            Console.WriteLine("Contact updated.");
        }

        // UC4
        public void DeleteContact()
        {
            AddressBook book = GetAddressBook();
            if (book == null) return;

            string name = InputHelper.ReadString("Enter First Name to delete: ");
            book.Persons.RemoveAll(p => p.FirstName == name);
            Console.WriteLine("Contact deleted if existed.");
        }

        // UC5
        public void DisplayContacts()
        {
            AddressBook book = GetAddressBook();
            if (book == null) return;

            foreach (var p in book.Persons)
                Console.WriteLine($"{p.FirstName} {p.LastName} | {p.City}, {p.State}");
        }

        // UC8
        public void SearchByCityOrState()
        {
            string value = InputHelper.ReadString("Enter City or State: ");
            foreach (var book in addressBooks.Values)
            {
                var results = book.Persons
                    .Where(p => p.City == value || p.State == value);

                foreach (var p in results)
                    Console.WriteLine($"{p.FirstName} - {p.City}, {p.State}");
            }
        }

        // UC10
        public void CountByCityOrState()
        {
            string value = InputHelper.ReadString("Enter City or State: ");
            int count = addressBooks.Values
                .SelectMany(b => b.Persons)
                .Count(p => p.City == value || p.State == value);

            Console.WriteLine($"Total Contacts: {count}");
        }

        // UC11
        public void SortByName()
        {
            AddressBook book = GetAddressBook();
            if (book == null) return;

            var sorted = book.Persons.OrderBy(p => p.FirstName);
            foreach (var p in sorted)
                Console.WriteLine($"{p.FirstName} {p.LastName}");
        }

        // UC12
        public void SortByCityStateZip()
        {
            AddressBook book = GetAddressBook();
            if (book == null) return;

            var sorted = book.Persons
                .OrderBy(p => p.City)
                .ThenBy(p => p.State)
                .ThenBy(p => p.Zip);

            foreach (var p in sorted)
                Console.WriteLine($"{p.FirstName} | {p.City} | {p.Zip}");
        }
    }
}
