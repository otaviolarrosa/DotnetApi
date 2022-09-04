namespace Events.User
{
    public class RequestCreateUserEvent
    {
        public RequestCreateUserEvent(string firstName, string lastName, string address) : base()
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