namespace Users.API.Application.Commands.CreateUser
{
    public class CreateUserCommand
    {
        public CreateUserCommand(string surname, string email, string password, string name, int phoneNumber,
            int postalCode, string countryCode)
        {
            Surname = surname;
            Email = email;
            Password = password;
            Name = name;
            PhoneNumber = phoneNumber;
            PostalCode = postalCode;
            CountryCode = countryCode;
        }

        public string Surname { get; }
        public string Email { get; }
        public string Password { get; }
        public string Name { get; }
        public int PhoneNumber { get; }
        public int PostalCode { get; }
        public string CountryCode { get; }
    }
}