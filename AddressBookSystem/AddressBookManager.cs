namespace AddressBookSystem
{
    internal class AddressBookManager
    {
        // Only one address book instance (array-based approach simplified)
        private AddressBook Book;

        public AddressBookManager()
        {
            Book = new AddressBook();
        }

        public AddressBook GetAddressBook()
        {
            return Book;
        }
    }
}
