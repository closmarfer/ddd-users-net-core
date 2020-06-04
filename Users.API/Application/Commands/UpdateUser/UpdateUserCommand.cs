namespace Users.API.Application.Commands.UpdateUser
{
    public class UpdateUserCommand
    {
        public UpdateUserCommand(string userUuid,
            string surname,
            string email,
            string password,
            string name,
            int phoneNumber,
            int postalCode, string countryCode)
        {
            UserUuid = userUuid;
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
        public string UserUuid { get; }
    }
}