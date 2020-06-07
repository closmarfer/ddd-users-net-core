using Users.Domain.Contract;

namespace Users.Domain.Event
{
    public class UserEmailWasUpdatedEvent: IDomainEvent
    {
        public string PreviousEmail { get; }
        public string NewEmail { get; }

        public UserEmailWasUpdatedEvent(string previousEmail, string newEmail)
        {
            PreviousEmail = previousEmail;
            NewEmail = newEmail;
        }
    }
}