using System;
using Users.Domain.Contract;
using Users.Domain.Entity;
using Users.Domain.Exception;
using Users.Domain.ValueObject;

namespace Users.Domain.Service
{
    public class UpdateUser
    {
        private IUserRepository _userRepository;

        public UpdateUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void handle(
            UserUuid userUuid,
            Email email,
            Name name,
            Surname surname,
            PhoneNumber phoneNumber,
            PostalCode postalCode,
            CountryCode countryCode
        )
        {
            var existentUser = _userRepository.GetUser(userUuid);

            if (null == existentUser)
            {
                throw new UserNotFoundException();
            }

            existentUser.Email = email;
            existentUser.Name = name;
            existentUser.Surname = surname;
            existentUser.PhoneNumber = phoneNumber;
            existentUser.PostalCode = postalCode;
            existentUser.CountryCode = countryCode;

            _userRepository.Update(existentUser);
            
            //TODO event
            //TODO si el email ha cambiado, event de que es diferente
        }
    }
}