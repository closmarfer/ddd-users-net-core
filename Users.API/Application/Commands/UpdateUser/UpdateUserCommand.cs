namespace Users.API.Application.Commands.UpdateUser
{
    public class UpdateUserCommand
    {
        public UpdateUserCommand(string userUuid,
            string surname,
            string email,
            string name,
            int phoneNumber,
            int postalCode, string countryCode)
        {
            UserUuid = userUuid;
            Surname = surname;
            Email = email;
            Name = name;
            PhoneNumber = phoneNumber;
            PostalCode = postalCode;
            CountryCode = countryCode;
        }

        public string Surname { get; }
        public string Email { get; }
        public string Name { get; }
        public int PhoneNumber { get; }
        public int PostalCode { get; }
        public string CountryCode { get; }
        public string UserUuid { get; }
    }
}