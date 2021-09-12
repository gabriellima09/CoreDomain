namespace CoreDomain.Interfaces
{
    public interface IAggregate<TKey>
    {
        TKey Id { get; }
    }
}
