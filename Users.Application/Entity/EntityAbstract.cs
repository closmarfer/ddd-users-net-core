using System.Collections.Generic;
using Users.Domain.Contract;

namespace Users.Domain.Entity
{
    public abstract class EntityAbstract
    {
        private List<IDomainEvent> _domainEvents;
        public List<IDomainEvent> DomainEvents => _domainEvents;

        public void AddDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents ??= new List<IDomainEvent>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }
    }
}