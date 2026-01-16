using System;

namespace AddressBookSystem
{
    internal class AddressBook : IAddressBook
    {
        // Maximum contacts allowed (configurable, not hard-coded)
        private const int MaxContacts = 100;

        // Array to store contacts
        private Contact[] ContactList;

        // Tracks number of contacts stored
        private int ContactCount;

        // Constructor initializes array
        public AddressBook()
        {
            ContactList = new Contact[MaxContacts];
            ContactCount = 0;
        }

        // UC-2: Add contact with duplicate check
        public void AddContact(Contact ContactData)
        {
            if (ContactCount >= MaxContacts)
            {
                Console.WriteLine("Address book is full");
                return;
            }

            // Check for duplicate first name
            for (int Index = 0; Index < ContactCount; Index++)
            {
                if (ContactList[Index].GetFirstName() == ContactData.GetFirstName())
                {
                    Console.WriteLine("Duplicate contact not allowed");
                    return;
                }
            }

            ContactList[ContactCount] = ContactData;
            ContactCount++;

            Console.WriteLine("Contact added successfully");
        }

        // UC-3: Edit contact
        public void EditContact(string FirstName)
        {
            for (int Index = 0; Index < ContactCount; Index++)
            {
                if (ContactList[Index].GetFirstName() == FirstName)
                {
                    Console.WriteLine("Enter new last name:");
                    string LastName = Console.ReadLine();

                    Console.WriteLine("Enter new address:");
                    string Address = Console.ReadLine();

                    Console.WriteLine("Enter new city:");
                    string City = Console.ReadLine();

                    Console.WriteLine("Enter new state:");
                    string State = Console.ReadLine();

                    Console.WriteLine("Enter new pincode:");
                    string PinCode = Console.ReadLine();

                    Console.WriteLine("Enter new phone number:");
                    string PhoneNumber = Console.ReadLine();

                    Console.WriteLine("Enter new email:");
                    string Email = Console.ReadLine();

                    Contact UpdatedContact =
                        new Contact(
                            FirstName,
                            LastName,
                            Address,
                            City,
                            State,
                            PinCode,
                            PhoneNumber,
                            Email);

                    ContactList[Index].UpdateContact(UpdatedContact);

                    Console.WriteLine("Contact updated successfully");
                    return;
                }
            }

            Console.WriteLine("Contact not found");
        }

        // UC-4: Delete contact
        public void DeleteContact(string FirstName)
        {
            for (int Index = 0; Index < ContactCount; Index++)
            {
                if (ContactList[Index].GetFirstName() == FirstName)
                {
                    // Shift remaining contacts left
                    for (int Shift = Index; Shift < ContactCount - 1; Shift++)
                    {
                        ContactList[Shift] = ContactList[Shift + 1];
                    }

                    ContactList[ContactCount - 1] = null;
                    ContactCount--;

                    Console.WriteLine("Contact deleted successfully");
                    return;
                }
            }

            Console.WriteLine("Contact not found");
        }

        // UC-5: Display contacts
        public void DisplayContacts()
        {
            if (ContactCount == 0)
            {
                Console.WriteLine("No contacts available");
                return;
            }

            for (int Index = 0; Index < ContactCount; Index++)
            {
                ContactList[Index].Display();
            }
        }

        // UC-11: Sort contacts by first name (Bubble Sort)
        public void SortByName()
        {
            for (int Outer = 0; Outer < ContactCount - 1; Outer++)
            {
                for (int Inner = 0; Inner < ContactCount - Outer - 1; Inner++)
                {
                    if (string.Compare(
                        ContactList[Inner].GetFirstName(),
                        ContactList[Inner + 1].GetFirstName()) > 0)
                    {
                        Contact Temp = ContactList[Inner];
                        ContactList[Inner] = ContactList[Inner + 1];
                        ContactList[Inner + 1] = Temp;
                    }
                }
            }

            Console.WriteLine("Contacts sorted by first name");
        }
    }
}
