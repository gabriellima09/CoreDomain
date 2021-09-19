using CoreDomain.Tests.Common;
using System;
using Xunit;

namespace CoreDomain.Tests.Models
{
    public class EntityTest
    {
        [Fact]
        public void EqualityTest_Int()
        {
            int id = Generator.GetRandomInt();

            MyCustomEntity<int> myClass1 = Generator<int>.GetCustomEntityInstance(id);
            MyCustomEntity<int> myClass2 = Generator<int>.GetCustomEntityInstance(id);
           
            ValidateEquality(myClass1, myClass2);
        }

        [Fact]
        public void NonEqualityTest_Int()
        {
            MyCustomEntity<int> myClass1 = Generator<int>.GetCustomEntityInstance(Generator.GetRandomInt());
            MyCustomEntity<int> myClass2 = Generator<int>.GetCustomEntityInstance(Generator.GetRandomInt());

            ValidateNonEquality(myClass1, myClass2);
        }

        [Fact]
        public void EqualityTest_Long()
        {
            long id = Generator.GetRandomLong();

            MyCustomEntity<long> myClass1 = Generator<long>.GetCustomEntityInstance(id);
            MyCustomEntity<long> myClass2 = Generator<long>.GetCustomEntityInstance(id);

            ValidateEquality(myClass1, myClass2);
        }

        [Fact]
        public void NonEqualityTest_Long()
        {
            MyCustomEntity<long> myClass1 = Generator<long>.GetCustomEntityInstance(Generator.GetRandomLong());
            MyCustomEntity<long> myClass2 = Generator<long>.GetCustomEntityInstance(Generator.GetRandomLong());

            ValidateNonEquality(myClass1, myClass2);
        }

        [Fact]
        public void EqualityTest_String()
        {
            string id = Generator.GetRandomString(20);

            MyCustomEntity<string> myClass1 = Generator<string>.GetCustomEntityInstance(id);
            MyCustomEntity<string> myClass2 = Generator<string>.GetCustomEntityInstance(id);

            ValidateEquality(myClass1, myClass2);
        }

        [Fact]
        public void NonEqualityTest_String()
        {
            MyCustomEntity<string> myClass1 = Generator<string>.GetCustomEntityInstance(Generator.GetRandomString(20));
            MyCustomEntity<string> myClass2 = Generator<string>.GetCustomEntityInstance(Generator.GetRandomString(20));

            ValidateNonEquality(myClass1, myClass2);
        }

        [Fact]
        public void EqualityTest_Guid()
        {
            Guid id = Generator.GetRandomGuid();

            MyCustomEntity<Guid> myClass1 = Generator<Guid>.GetCustomEntityInstance(id);
            MyCustomEntity<Guid> myClass2 = Generator<Guid>.GetCustomEntityInstance(id);

            ValidateEquality(myClass1, myClass2);
        }

        [Fact]
        public void NonEqualityTest_Guid()
        {
            MyCustomEntity<Guid> myClass1 = Generator<Guid>.GetCustomEntityInstance(Generator.GetRandomGuid());
            MyCustomEntity<Guid> myClass2 = Generator<Guid>.GetCustomEntityInstance(Generator.GetRandomGuid());

            ValidateNonEquality(myClass1, myClass2);
        }

        private static void ValidateEquality<T>(MyCustomEntity<T> myClass1, MyCustomEntity<T> myClass2)
        {
            Assert.True(myClass1 == myClass2);
            Assert.False(myClass1 != myClass2);
            Assert.True(myClass1.Equals(myClass2));
            Assert.Equal(myClass1, myClass2);
            Assert.Equal(myClass1.Id, myClass2.Id);
        }

        private static void ValidateNonEquality<T>(MyCustomEntity<T> myClass1, MyCustomEntity<T> myClass2)
        {
            Assert.False(myClass1 == myClass2);
            Assert.True(myClass1 != myClass2);
            Assert.False(myClass1.Equals(myClass2));
            Assert.NotEqual(myClass1, myClass2);
            Assert.NotEqual(myClass1.Id, myClass2.Id);
        }
    }
}
