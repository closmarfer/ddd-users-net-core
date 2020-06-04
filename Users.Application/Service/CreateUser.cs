using System;
using Users.Domain.Contract;
using Users.Domain.Entity;
using Users.Domain.ValueObject;

namespace Users.Domain.Service
{
    public class CreateUser
    {
        private readonly IUserRepository _userRepository;
        private readonly HashPassword _hashPassword;

        public CreateUser(IUserRepository userRepository, HashPassword hashPassword)
        {
            _userRepository = userRepository;
            _hashPassword = hashPassword;
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
                _hashPassword.handle(password),
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
