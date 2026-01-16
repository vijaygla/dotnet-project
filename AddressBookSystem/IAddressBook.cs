namespace AddressBookSystem
{
    internal interface IAddressBook
    {
        // UC-2: Add a new contact
        void AddContact(Contact ContactData);

        // UC-3: Edit an existing contact using first name
        void EditContact(string FirstName);

        // UC-4: Delete a contact using first name
        void DeleteContact(string FirstName);

        // UC-5: Display all contacts
        void DisplayContacts();

        // UC-11: Sort contacts by first name
        void SortByName();
    }
}
