using CoreDomain.Interfaces;

namespace CoreDomain
{
    public abstract class AggregateBase<TKey> : DomainEventBase<TKey>, IAggregate<TKey>
    {
        public TKey Id { get; protected set; }

        protected void RaiseEvent<TEvent>(TEvent @event)
            where TEvent : DomainEventBase<TKey>
        {
            IDomainEvent<TKey> eventWithAggregate = @event.WithAggregate(
              Equals(Id, default(TKey)) ? @event.AggregateId : Id,
              Version);

            ((IDomainEvent<TKey>)this).ApplyEvent(eventWithAggregate, Version + 1);

            UncommittedEvents.Add(@event);
        }
    }
}
