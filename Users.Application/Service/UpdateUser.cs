using System;
using Users.Domain.Contract;
using Users.Domain.Entity;
using Users.Domain.Exception;
using Users.Domain.ValueObject;

namespace Users.Domain.Service
{
    public class UpdateUser: CheckUserEmail
    {
        private IUserRepository _userRepository;

        public UpdateUser(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public void Handle(
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
            
            CheckUserEmail(existentUser, email);
            
            existentUser.Email = email;
            existentUser.Name = name;
            existentUser.Surname = surname;
            existentUser.PhoneNumber = phoneNumber;
            existentUser.PostalCode = postalCode;
            existentUser.CountryCode = countryCode;

            _userRepository.Update(existentUser);

            //Fixme event
            //Fixme si el email ha cambiado, event de que es diferente
        }

        private void CheckUserEmail(User existentUser, Email email)
        {
            if (existentUser.Email.Equals(email))
            {
                return;
            }

            base.CheckEmail(email);
        }
    }
}