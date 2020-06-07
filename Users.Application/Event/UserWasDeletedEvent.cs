using Users.Domain.Contract;

namespace Users.Domain.Event
{
    public class UserWasDeletedEvent: IDomainEvent
    {
        public string UserUuid { get; }

        public UserWasDeletedEvent(string userUuid)
        {
            UserUuid = userUuid;
        }
    }
}