namespace CoreDomain.Interfaces
{
    public interface IEntity<out TKey>
    {
        TKey Id { get; }
    }
}
