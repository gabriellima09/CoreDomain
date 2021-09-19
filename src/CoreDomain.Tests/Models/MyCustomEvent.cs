using CoreDomain.Interfaces;
using System;

namespace CoreDomain.Tests.Models
{
    public class MyCustomEvent : DomainEventBase<Guid>
    {
        public MyCustomEvent() : base()
        {

        }

        public MyCustomEvent(Guid aggregateId, long version) : base(aggregateId, version)
        {

        }

        public override IDomainEvent<Guid> WithAggregate(Guid aggregateId, long aggregateVersion)
        {
            return new MyCustomEvent(aggregateId, aggregateVersion);
        }
    }
}
