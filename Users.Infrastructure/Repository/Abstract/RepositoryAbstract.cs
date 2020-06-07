using Users.Domain.Contract;
using Users.Domain.Entity;

namespace Users.Infrastructure.Repository.Abstract
{
    public abstract class RepositoryAbstract
    {
        private readonly IEventDispatcher _eventDispatcher;

        protected RepositoryAbstract(IEventDispatcher eventDispatcher)
        {
            _eventDispatcher = eventDispatcher;
        }

        protected void DispatchEvents(EntityAbstract entity)
        {
            foreach (var domainEvent in entity.DomainEvents)
            {
                _eventDispatcher.Dispatch(domainEvent);
            }

            RemoveEvents(entity);
        }

        private static void RemoveEvents(EntityAbstract entity)
        {
            foreach (var domainEvent in entity.DomainEvents)
            {
                entity.RemoveDomainEvent(domainEvent);
            }
        }
    }
}