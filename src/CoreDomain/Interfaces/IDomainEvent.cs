using System;
using System.Collections.Generic;

namespace CoreDomain.Interfaces
{
    public interface IDomainEvent<TKey>
    {
        Guid EventId { get; }
        TKey AggregateId { get; }
        long Version { get; }
        ICollection<IDomainEvent<TKey>> UncommittedEvents { get; }

        void ApplyEvent(IDomainEvent<TKey> @event, long version);
        IEnumerable<IDomainEvent<TKey>> GetUncommittedEvents();
        void ClearUncommittedEvents();
    }
}
