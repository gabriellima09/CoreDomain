using System.Collections.Generic;

namespace CoreDomain.Interfaces
{
    public interface IAggregateEvent<TKey>
    {
        long Version { get; }
        IReadOnlyCollection<IDomainEvent<TKey>> UncommittedEvents { get; }

        IEnumerable<IDomainEvent<TKey>> GetUncommittedEvents();
        void ClearUncommittedEvents();
    }
}
