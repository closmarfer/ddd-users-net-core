using Users.Domain.Contract;
using Users.Domain.Event;
using Users.Domain.Exception;
using Users.Domain.ValueObject;

namespace Users.Domain.Service
{
    public class DeleteUser
    {
        private readonly IUserRepository _userRepository;

        public DeleteUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Handle(UserUuid userUuid)
        {
            var existentUser = _userRepository.GetUser(userUuid);

            if (null == existentUser)
            {
                throw new UserNotFoundException();
            }
            
            existentUser.AddDomainEvent(new UserWasDeletedEvent(existentUser.UserUuid.Value));
            
            _userRepository.Delete(existentUser);

            //Fixme event
        }
    }
}