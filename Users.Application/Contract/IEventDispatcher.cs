namespace Users.Domain.Contract
{
    public interface IEventDispatcher
    {
        void Dispatch(IDomainEvent domainEvent);
    }
}