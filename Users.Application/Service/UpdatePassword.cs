using Users.Domain.Contract;
using Users.Domain.Exception;
using Users.Domain.ValueObject;

namespace Users.Domain.Service
{
    public class UpdatePassword
    {
        private readonly IUserRepository _userRepository;
        private readonly HashPassword _hashPassword;

        public UpdatePassword(IUserRepository userRepository, HashPassword hashPassword)
        {
            _userRepository = userRepository;
            _hashPassword = hashPassword;
        }

        public void Handle(
            Email email,
            Password oldPassword,
            Password newPassword
        )
        {
            var existentUser = _userRepository.GetByEmail(email);

            if (null == existentUser)
            {
                throw new UserNotFoundException();
            }

            var oldHashedPassword = _hashPassword.Handle(oldPassword);

            if (!existentUser.IsSamePassword(oldHashedPassword))
            {
                throw new InvalidPasswordException();
            }
            
            var newHashedPassword = _hashPassword.Handle(newPassword);
            
            existentUser.HashedPassword = newHashedPassword;

            _userRepository.Update(existentUser);
            
            //Fixme event
        }
    }
}