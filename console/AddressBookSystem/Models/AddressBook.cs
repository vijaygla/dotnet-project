using AddressBookSystem.Models;

namespace AddressBookSystem.Models
{
    public class AddressBook
    {
        public string Name { get; set; }

        // Collection to store multiple persons
        public List<Person> Persons { get; set; } = new List<Person>();
    }
}
