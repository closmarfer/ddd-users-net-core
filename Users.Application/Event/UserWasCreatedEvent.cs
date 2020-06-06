using Users.Domain.Contract;

namespace Users.Domain.Event
{
    public class UserWasCreatedEvent: IDomainEvent
    {
        public string UserUuid { get; }

        public UserWasCreatedEvent(string userUuid)
        {
            UserUuid = userUuid;
        }
    }
}