using Users.Domain.Contract;
using Users.Domain.Exception;
using Users.Domain.ValueObject;

namespace Users.Domain.Service
{
    public abstract class CheckUserEmail
    {
        private readonly IUserRepository _userRepository;

        public CheckUserEmail(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected void CheckEmail(Email email)
        {
            if (_userRepository.GetByEmail(email) != null)
            {
                throw new EmailAlreadyExistsException();
            }
        }
    }
}