using System;

namespace CoreDomain.Interfaces
{
    public interface IDomainEvent<TKey>
    {
        Guid EventId { get; }
        TKey AggregateId { get; }
        long AggregateVersion { get; }
        public DateTime CreatedAt { get; }
    }
}
