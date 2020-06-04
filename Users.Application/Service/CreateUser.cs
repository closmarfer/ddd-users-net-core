using System;
using Users.Domain.Contract;
using Users.Domain.Entity;
using Users.Domain.ValueObject;

namespace Users.Domain.Service
{
    public class CreateUser: CheckUserEmail
    {
        private readonly IUserRepository _userRepository;
        private readonly HashPassword _hashPassword;

        public CreateUser(IUserRepository userRepository, HashPassword hashPassword) : base(userRepository)
        {
            _userRepository = userRepository;
            _hashPassword = hashPassword;
        }

        public void Handle(
            Email email,
            Password password,
            Name name,
            Surname surname,
            PhoneNumber phoneNumber,
            PostalCode postalCode,
            CountryCode countryCode
            )
        {
            
            CheckEmail(email);
            
            var newUser = User.create(
                generateUserUuid(),
                email,
                _hashPassword.Handle(password),
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
