using System.Collections.Generic;


namespace AddressBookSonarQube.Core.Models;


public class AddressBook
{
    public string Name { get; set; }
    public List<Contact> Contacts { get; set; } = new();


    public AddressBook(string name)
    {
        Name = name;
    }
}