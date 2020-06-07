using Users.Domain.Contract;
using Users.Domain.Entity;
using Users.Domain.Event;
using Users.Domain.Exception;
using Users.Domain.ValueObject;

namespace Users.Domain.Service
{
    public class UpdateUser : CheckUserEmail
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

            existentUser.AddDomainEvent(new UserWasUpdatedEvent(userUuid.Value));
            
            _userRepository.Update(existentUser);
        }

        private void CheckUserEmail(User existentUser, Email email)
        {
            if (existentUser.Email.Equals(email))
            {
                return;
            }

            existentUser.AddDomainEvent(
                new UserEmailWasUpdatedEvent(existentUser.Email.Value, email.Value)
            );
            base.CheckEmail(email);
        }
    }
}