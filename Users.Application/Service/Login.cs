using Users.Domain.Contract;
using Users.Domain.Exception;
using Users.Domain.ValueObject;

namespace Users.Domain.Service
{
    public class Login
    {
        private readonly IUserRepository _userRepository;
        private readonly HashPassword _hashPassword;

        public Login(IUserRepository userRepository, HashPassword hashPassword)
        {
            _userRepository = userRepository;
            _hashPassword = hashPassword;
        }

        public void Handle(
            Email email,
            Password password
        )
        {
            var existentUser = _userRepository.GetByEmail(email);

            if (null == existentUser)
            {
                throw new InvalidPasswordException();
            }

            var hashedPassword = _hashPassword.Handle(password);

            if (!existentUser.IsSamePassword(hashedPassword))
            {
                throw new InvalidPasswordException();
            }
        }
    }
}