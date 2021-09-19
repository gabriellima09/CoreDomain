using System;

namespace CoreDomain.Tests.Models
{
    public class MyCustomAggregate<T> : AggregateBase<Guid>
    {
        public MyCustomEntity<T> Entity { get; set; }
        public MyCustomValueObject ValueObject { get; set; }
        
        public MyCustomAggregate(MyCustomEntity<T> entity, MyCustomValueObject valueObject)
        {
            Id = Guid.NewGuid();
            Entity = entity ?? throw new ArgumentNullException(nameof(entity));
            ValueObject = valueObject ?? throw new ArgumentNullException(nameof(valueObject));

            RaiseEvent(new MyCustomEvent(Id, Version));
        }

        public void ApplyEvent()
        {
            RaiseEvent(new MyCustomEvent());
        }
    }
}
