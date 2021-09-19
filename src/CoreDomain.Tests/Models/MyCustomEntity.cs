namespace CoreDomain.Tests.Models
{
    public class MyCustomEntity<T> : EntityBase<T>
    {
        public MyCustomEntity() { }

        public MyCustomEntity(T id) => Id = id;
    }
}
