using System;
using Users.Domain.Contract;
using Users.Domain.Entity;
using Users.Domain.ValueObject;

namespace Users.Domain.Service
{
    public class CreateUser
    {
        private IUserRepository _userRepository;

        public CreateUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void handle(
            Email email,
            Password password,
            Name name,
            Surname surname,
            PhoneNumber phoneNumber,
            PostalCode postalCode,
            CountryCode countryCode
            )
        {
      
            var newUser = User.create(
                uuid: generateUserUuid(),
                email: email,
                hashedPassword: HashPassword.handle(password),
                name: name,
                surname: surname,
                phoneNumber: phoneNumber,
                postalCode: postalCode,
                countryCode: countryCode
                );

            _userRepository.create(newUser);
        }

        private UserUuid generateUserUuid()
        {
            var guid = Guid.NewGuid();
            UserUuid uuid = new UserUuid(guid.ToString());
            return uuid;
        }
    }
}
