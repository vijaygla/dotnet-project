using AddressBookSonarQube.Core.Exceptions;
using AddressBookSonarQube.Core.Interfaces;
using AddressBookSonarQube.Core.Models;
using AddressBookSonarQube.Core.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookSonarQube.Core.Services;

public class AddressBookService : IAddressBookService
{
    private Dictionary<string, AddressBook> _books;
    private readonly string _filePath;

    public AddressBookService(string filePath)
    {
        _filePath = filePath;
        _books = FileManager.LoadFromFile(_filePath);
    }

    public void CreateAddressBook(string name)
    {
        if (_books.ContainsKey(name))
            throw new AddressBookException("Address Book already exists");

        _books[name] = new AddressBook(name);
        FileManager.SaveToFile(_books, _filePath);
    }

    public void AddContact(string bookName, Contact contact)
    {
        var book = GetBook(bookName);
        if (book.Contacts.Any(c => c.FirstName == contact.FirstName))
            throw new AddressBookException("Duplicate contact");

        book.Contacts.Add(contact);
        FileManager.SaveToFile(_books, _filePath);
    }

    public void EditContact(string bookName, string firstName, Contact updated)
    {
        var book = GetBook(bookName);
        var contact = book.Contacts.FirstOrDefault(c => c.FirstName == firstName)
        ?? throw new AddressBookException("Contact not found");

        contact.LastName = updated.LastName;
        contact.Address = updated.Address;
        contact.City = updated.City;
        contact.State = updated.State;
        contact.Zip = updated.Zip;
        contact.PhoneNumber = updated.PhoneNumber;
        contact.Email = updated.Email;
        FileManager.SaveToFile(_books, _filePath);
    }

    public void DeleteContact(string bookName, string firstName)
    {
        var book = GetBook(bookName);
        var contact = book.Contacts.FirstOrDefault(c => c.FirstName == firstName)
        ?? throw new AddressBookException("Contact not found");

        book.Contacts.Remove(contact);
        FileManager.SaveToFile(_books, _filePath);
    }

    public List<Contact> GetAllContacts(string bookName)
    => GetBook(bookName).Contacts;

    public List<Contact> SearchByCity(string city)
    => _books.Values.SelectMany(b => b.Contacts)
    .Where(c => c.City == city).ToList();

    public List<Contact> SearchByState(string state)
    => _books.Values.SelectMany(b => b.Contacts)
    .Where(c => c.State == state).ToList();

    public Dictionary<string, int> CountByCity()
    => _books.Values.SelectMany(b => b.Contacts)
        .GroupBy(c => c.City)
        .ToDictionary(g => g.Key, g => g.Count());

    public Dictionary<string, int> CountByState()
    => _books.Values.SelectMany(b => b.Contacts)
        .GroupBy(c => c.State)
        .ToDictionary(g => g.Key, g => g.Count());

    public List<Contact> SortBy(Func<Contact, string> keySelector)
    => _books.Values.SelectMany(b => b.Contacts)
        .OrderBy(keySelector).ToList();

    private AddressBook GetBook(string name)
    => _books.GetValueOrDefault(name)
    ?? throw new AddressBookException("Address Book not found");
}
