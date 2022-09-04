namespace Domain.Entities
{
    public class User : EntityBase
    {
        public User(string firstName, string lastName, string address) : base()
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
