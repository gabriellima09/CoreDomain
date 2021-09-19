using CoreDomain.Tests.Common;
using CoreDomain.Tests.Models;
using System;
using Xunit;

namespace CoreDomain.Tests
{
    public class DomainEventBaseTest
    {
        [Fact]
        public void InstanceTest()
        {
            MyCustomEvent customEvent = new MyCustomEvent(Generator.GetRandomGuid(), 1);

            Assert.NotNull(customEvent);
            Assert.True(customEvent.AggregateId != Guid.Empty);
            Assert.True(customEvent.EventId != Guid.Empty);
            Assert.True(customEvent.AggregateVersion > -1);
            Assert.True(customEvent.CreatedAt != DateTime.MinValue);
        }

        [Fact]
        public void NonEqualityTest()
        {
            MyCustomEvent customEvent1 = new MyCustomEvent(Generator.GetRandomGuid(), 1);
            MyCustomEvent customEvent2 = new MyCustomEvent(Generator.GetRandomGuid(), 1);

            Assert.False(customEvent1.Equals(customEvent2));
            Assert.NotEqual(customEvent1, customEvent2);
        }
    }
}
