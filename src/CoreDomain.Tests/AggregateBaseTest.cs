using CoreDomain.Tests.Common;
using CoreDomain.Tests.Models;
using System;
using System.Linq;
using Xunit;

namespace CoreDomain.Tests
{
    public class AggregateBaseTest
    {
        [Fact]
        public void InstanceTest()
        {
            MyCustomAggregate<Guid> customAggregate = Generator.GetAggregateInstace<Guid>();

            Assert.NotNull(customAggregate.ValueObject);
            Assert.NotNull(customAggregate.Entity);
            Assert.NotNull(customAggregate);
            Assert.True(customAggregate.Id != Guid.Empty);
            Assert.True(customAggregate.Version > -1);
            Assert.NotNull(customAggregate.GetUncommittedEvents());
            Assert.True(customAggregate.GetUncommittedEvents().Any());
        }

        [Fact]
        public void AddEventTest()
        {
            MyCustomAggregate<Guid> customAggregate = Generator.GetAggregateInstace<Guid>();

            customAggregate.ApplyEvent();
            
            Assert.NotNull(customAggregate.ValueObject);
            Assert.NotNull(customAggregate.Entity);
            Assert.NotNull(customAggregate);
            Assert.True(customAggregate.Id != Guid.Empty);
            Assert.True(customAggregate.Version > -1);
            Assert.NotNull(customAggregate.GetUncommittedEvents());
            Assert.True(customAggregate.GetUncommittedEvents().Count() == 2);
        }
    }
}
