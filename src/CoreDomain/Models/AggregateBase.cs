using CoreDomain.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CoreDomain
{
    public abstract class AggregateBase<TKey> : IAggregate<TKey>, IAggregateEvent<TKey>
    {
        public TKey Id { get; protected set; }

        public const long NewAggregateVersion = 0;
        public long Version { get; private set; } = NewAggregateVersion;

        private readonly ICollection<IDomainEvent<TKey>> _uncommittedEvents = new Collection<IDomainEvent<TKey>>();
        IReadOnlyCollection<IDomainEvent<TKey>> IAggregateEvent<TKey>.UncommittedEvents => _uncommittedEvents as IReadOnlyCollection<IDomainEvent<TKey>>;

        public void ClearUncommittedEvents() => _uncommittedEvents.Clear();
        public IEnumerable<IDomainEvent<TKey>> GetUncommittedEvents() => _uncommittedEvents.AsEnumerable();

        protected void RaiseEvent<TEvent>(TEvent @event)
            where TEvent : DomainEventBase<TKey>
        {
            IDomainEvent<TKey> eventWithAggregate = @event.WithAggregate(
              Equals(Id, default(TKey)) ? @event.AggregateId : Id,
              Version);

            if (!_uncommittedEvents.Any(x => Equals(x.EventId, @event.EventId)))
            {
                _uncommittedEvents.Add(@event);
                Version++;
            }
        }
    }
}
