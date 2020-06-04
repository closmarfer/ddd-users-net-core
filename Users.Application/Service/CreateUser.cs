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
                generateUserUuid(),
                email,
                HashPassword.handle(password),
                name,
                surname,
                phoneNumber,
                postalCode,
                countryCode
                );

            _userRepository.Create(newUser);
            
            //Fixme event
        }

        private UserUuid generateUserUuid()
        {
            var guid = Guid.NewGuid();
            UserUuid uuid = new UserUuid(guid.ToString());
            return uuid;
        }
    }
}
