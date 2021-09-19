using CoreDomain.Interfaces;
using System;
using System.Collections.Generic;

namespace CoreDomain
{
    public abstract class DomainEventBase<TKey> : IDomainEvent<TKey>, IEquatable<DomainEventBase<TKey>>
    {
        public const long NewVersion = 0;

        public Guid EventId { get; }
        public TKey AggregateId { get; }
        public long AggregateVersion { get; private set; } = NewVersion;
        public DateTime CreatedAt { get; }

        protected DomainEventBase()
        {
            EventId = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        protected DomainEventBase(TKey aggregateId) : this()
        {
            AggregateId = aggregateId;
        }

        protected DomainEventBase(TKey aggregateId, long aggregateVersion) : this(aggregateId)
        {
            AggregateVersion = aggregateVersion;
        }

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
