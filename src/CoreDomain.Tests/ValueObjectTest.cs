using CoreDomain.Tests.Models;
using Xunit;

namespace CoreDomain.Tests
{
    public class ValueObjectTest
    {
        [Theory]
        [InlineData(1, "test")]
        public void EqualityTest(int foo, string bar)
        {
            MyCustomValueObject valueObject1 = new MyCustomValueObject(foo, bar);
            MyCustomValueObject valueObject2 = new MyCustomValueObject(foo, bar);

            Assert.True(valueObject1 == valueObject2);
            Assert.False(valueObject1 != valueObject2);
            Assert.True(valueObject1.Equals(valueObject2));
            Assert.Equal(valueObject1, valueObject2);
        }

        [Fact]
        public void NonEqualityTest()
        {
            MyCustomValueObject valueObject1 = new MyCustomValueObject(1, "test");
            MyCustomValueObject valueObject2 = new MyCustomValueObject(2, "test");

            Assert.True(valueObject1 != valueObject2);
            Assert.False(valueObject1 == valueObject2);
            Assert.False(valueObject1.Equals(valueObject2));
            Assert.NotEqual(valueObject1, valueObject2);
        }
    }
}
