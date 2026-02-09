using AddressBookSonarQube.Core.Exceptions;
using AddressBookSonarQube.Core.Models;
using AddressBookSonarQube.Core.Services;

const string filePath = "addressbook.json";
var service = new AddressBookService(filePath);

while (true)
{
    Console.WriteLine("\n1.Create Book 2.Add 3.Edit 4.Delete 5.View 6.Search City 7.Search State\n8.Count City 9.Count State 10.Sort Name 11.Sort City 12.Sort State 13.Exit");
    if (!int.TryParse(Console.ReadLine(), out int choice))
    {
        Console.WriteLine("Invalid choice. Please enter a number.");
        continue;
    }

    try
    {
        switch (choice)
        {
            case 1:
                var bookName = Prompt("Book Name: ");
                service.CreateAddressBook(bookName);
                Console.WriteLine("Address book created successfully.");
                break;
            case 2:
                bookName = Prompt("Book: ");
                var c = new Contact
                {
                    FirstName = Prompt("First Name: "),
                    LastName = Prompt("Last Name: "),
                    Address = Prompt("Address: "),
                    City = Prompt("City: "),
                    State = Prompt("State: "),
                    Zip = Prompt("Zip: "),
                    PhoneNumber = Prompt("Phone Number: "),
                    Email = Prompt("Email: ")
                };
                service.AddContact(bookName, c);
                Console.WriteLine("Contact added successfully.");
                break;
            case 3:
                bookName = Prompt("Book: ");
                var firstName = Prompt("First Name of contact to edit: ");
                var updatedContact = new Contact
                {
                    FirstName = Prompt("New First Name: "),
                    LastName = Prompt("New Last Name: "),
                    Address = Prompt("New Address: "),
                    City = Prompt("New City: "),
                    State = Prompt("New State: "),
                    Zip = Prompt("New Zip: "),
                    PhoneNumber = Prompt("New Phone Number: "),
                    Email = Prompt("New Email: ")
                };
                service.EditContact(bookName, firstName, updatedContact);
                Console.WriteLine("Contact updated successfully.");
                break;
            case 4:
                bookName = Prompt("Book: ");
                firstName = Prompt("First Name of contact to delete: ");
                service.DeleteContact(bookName, firstName);
                Console.WriteLine("Contact deleted successfully.");
                break;
            case 5:
                bookName = Prompt("Book: ");
                var contacts = service.GetAllContacts(bookName);
                PrintContacts(contacts);
                break;
            case 6:
                var city = Prompt("City to search for: ");
                contacts = service.SearchByCity(city);
                PrintContacts(contacts);
                break;
            case 7:
                var state = Prompt("State to search for: ");
                contacts = service.SearchByState(state);
                PrintContacts(contacts);
                break;
            case 8:
                var cityCounts = service.CountByCity();
                foreach (var (cityName, count) in cityCounts)
                {
                    Console.WriteLine($"City: {cityName}, Count: {count}");
                }
                break;
            case 9:
                var stateCounts = service.CountByState();
                foreach (var (stateName, count) in stateCounts)
                {
                    Console.WriteLine($"State: {stateName}, Count: {count}");
                }
                break;
            case 10:
                contacts = service.SortBy(c => c.FirstName);
                PrintContacts(contacts);
                break;
            case 11:
                contacts = service.SortBy(c => c.City);
                PrintContacts(contacts);
                break;
            case 12:
                contacts = service.SortBy(c => c.State);
                PrintContacts(contacts);
                break;
            case 13:
                return;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
    catch (AddressBookException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
    }
}

string Prompt(string message)
{
    Console.Write(message);
    return Console.ReadLine() ?? string.Empty;
}

void PrintContacts(List<Contact> contacts)
{
    if (contacts.Count == 0)
    {
        Console.WriteLine("No contacts found.");
        return;
    }

    foreach (var contact in contacts)
    {
        Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}, City: {contact.City}, State: {contact.State}");
    }
}
