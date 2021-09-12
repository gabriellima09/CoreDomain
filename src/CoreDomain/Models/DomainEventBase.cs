using CoreDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDomain
{
    public abstract class DomainEventBase<TKey> : IDomainEvent<TKey>, IEquatable<DomainEventBase<TKey>>
    {
        public const long NewVersion = -1;

        public Guid EventId { get; }
        public TKey AggregateId { get; }
        public long Version { get; private set; } = NewVersion;
        public ICollection<IDomainEvent<TKey>> UncommittedEvents { get; }

        protected DomainEventBase()
        {
            EventId = Guid.NewGuid();
        }

        protected DomainEventBase(TKey aggregateId) : this()
        {
            AggregateId = aggregateId;
        }

        protected DomainEventBase(TKey aggregateId, long aggregateVersion) : this(aggregateId)
        {
            Version = aggregateVersion;
        }

        public void ApplyEvent(IDomainEvent<TKey> @event, long version)
        {
            if (!UncommittedEvents.Any(x => Equals(x.EventId, @event.EventId)))
            {
                ((dynamic)this).Apply((dynamic)@event);
                Version = version;
            }
        }

        public void ClearUncommittedEvents() => UncommittedEvents.Clear();
        public IEnumerable<IDomainEvent<TKey>> GetUncommittedEvents() => UncommittedEvents.AsEnumerable();

        public abstract IDomainEvent<TKey> WithAggregate(TKey aggregateId, long aggregateVersion);
        
        public override bool Equals(object obj)
        {
            return base.Equals(obj as DomainEventBase<TKey>);
        }

        public bool Equals(DomainEventBase<TKey> other)
        {
            return other != null && EventId.Equals(other.EventId);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GetType(), EqualityComparer<Guid>.Default.GetHashCode(EventId));
        }
    }
}
