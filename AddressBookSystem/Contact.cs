namespace AddressBookSystem
{
    internal class Contact
    {
        // Private fields for encapsulation
        private string FirstName;
        private string LastName;
        private string Address;
        private string City;
        private string State;
        private string PinCode;
        private string PhoneNumber;
        private string Email;

        // Constructor to initialize contact data
        public Contact(
            string FirstName,
            string LastName,
            string Address,
            string City,
            string State,
            string PinCode,
            string PhoneNumber,
            string Email)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.City = City;
            this.State = State;
            this.PinCode = PinCode;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
        }

        // Getter methods
        public string GetFirstName()
        {
            return FirstName;
        }

        // Update all contact details
        public void UpdateContact(Contact NewData)
        {
            LastName = NewData.LastName;
            Address = NewData.Address;
            City = NewData.City;
            State = NewData.State;
            PinCode = NewData.PinCode;
            PhoneNumber = NewData.PhoneNumber;
            Email = NewData.Email;
        }

        // Display contact information
        public void Display()
        {
            System.Console.WriteLine(
                FirstName + " " + LastName + " | " +
                City + " | " + State + " | " +
                PhoneNumber);
        }
    }
}
