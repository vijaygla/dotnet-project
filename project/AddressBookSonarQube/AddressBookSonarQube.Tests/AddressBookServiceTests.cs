using NUnit.Framework;
using AddressBookSonarQube.Core.Services;
using AddressBookSonarQube.Core.Models;
using System.IO;

[TestFixture]
public class AddressBookServiceTests
{
    private AddressBookService _service;
    private string _filePath;

    [SetUp]
    public void Setup()
    {
        _filePath = Path.GetTempFileName();
        _service = new AddressBookService(_filePath);
        _service.CreateAddressBook("Test");
    }

    [TearDown]
    public void TearDown()
    {
        if (File.Exists(_filePath))
        {
            File.Delete(_filePath);
        }
    }

    [Test]
    public void AddContact_ShouldIncreaseCount()
    {
        _service.AddContact("Test", new Contact { FirstName = "A", City = "Pune" });
        Assert.That(_service.GetAllContacts("Test").Count, Is.EqualTo(1));
    }
}

