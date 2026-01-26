namespace AddressBookSystem.Models
{
    public class Person
    {
        // Person details
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        // Override Equals to prevent duplicate entries
        public override bool Equals(object obj)
        {
            if (obj is Person other)
                return FirstName.Equals(other.FirstName, StringComparison.OrdinalIgnoreCase)
                    && LastName.Equals(other.LastName, StringComparison.OrdinalIgnoreCase);
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName);
        }
    }
}
