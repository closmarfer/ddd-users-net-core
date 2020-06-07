using Users.Domain.Contract;

namespace Users.Domain.Event
{
    public class UserWasUpdatedEvent: IDomainEvent
    {
        public string UserUuid { get; }

        public UserWasUpdatedEvent(string userUuid)
        {
            UserUuid = userUuid;
        }
    }
}