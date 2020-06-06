using System.Collections.Generic;
using Users.Domain.Contract;

namespace Users.Infrastructure.EventDispatcher
{
    public class EventDispatcher: IEventDispatcher
    {
        private ICollection<IDomainEvent> _domainEvents;
        
        public EventDispatcher()
        {
            _domainEvents = new List<IDomainEvent>();
        }

        public void Dispatch(IDomainEvent domainEvent)
        {
            //TODO use queue to publish events
            _domainEvents.Add(domainEvent);
        }
    }
}