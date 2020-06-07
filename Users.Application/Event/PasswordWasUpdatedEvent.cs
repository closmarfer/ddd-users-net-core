using Users.Domain.Contract;

namespace Users.Domain.Event
{
    public class PasswordWasUpdatedEvent: IDomainEvent
    {
        public string UserUuid { get; }

        public PasswordWasUpdatedEvent(string userUuid)
        {
            UserUuid = userUuid;
        }
    }
}