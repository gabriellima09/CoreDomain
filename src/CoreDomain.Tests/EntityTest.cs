using Xunit;

namespace CoreDomain.Tests
{
    public class EntityTest
    {
        [Fact]
        public void EqualityTest()
        {
            MyIntClass myClass1 = new MyIntClass();
            MyIntClass myClass2 = new MyIntClass();

            Assert.True(myClass1 == myClass2);
            Assert.False(myClass1 != myClass2);
            Assert.True(myClass1.Equals(myClass2));
            Assert.Equal(myClass1, myClass2);
        }

        [Fact]
        public void EqualityTestWithId()
        {
            MyIntClass myClass1 = new MyIntClass(1);
            MyIntClass myClass2 = new MyIntClass(1);

            Assert.True(myClass1 == myClass2);
            Assert.False(myClass1 != myClass2);
            Assert.True(myClass1.Equals(myClass2));
            Assert.Equal(myClass1, myClass2);
        }

        [Fact]
        public void EqualityTestWithDifferentId()
        {
            MyIntClass myClass1 = new MyIntClass(1);
            MyIntClass myClass2 = new MyIntClass(2);

            Assert.False(myClass1 == myClass2);
            Assert.True(myClass1 != myClass2);
            Assert.False(myClass1.Equals(myClass2));
            Assert.NotEqual(myClass1, myClass2);
        }
    }
    public class MyIntClass : EntityBase<int>
    {
        public MyIntClass() { }

        public MyIntClass(int id) => Id = id;
    }
}
