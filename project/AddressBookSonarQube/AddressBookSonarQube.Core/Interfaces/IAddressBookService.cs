using AddressBookSonarQube.Core.Models;
using System.Collections.Generic;


namespace AddressBookSonarQube.Core.Interfaces;


public interface IAddressBookService
{
    void CreateAddressBook(string name);
    void AddContact(string bookName, Contact contact);
    void EditContact(string bookName, string firstName, Contact updated);
    void DeleteContact(string bookName, string firstName);
    List<Contact> GetAllContacts(string bookName);
    List<Contact> SearchByCity(string city);
    List<Contact> SearchByState(string state);
    Dictionary<string, int> CountByCity();
    Dictionary<string, int> CountByState();
    List<Contact> SortBy(Func<Contact, string> keySelector);
}