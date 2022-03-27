namespace DotnetBackend.Core.Entity.Interface
{
    public interface IEntity<T>
    {
        T ID { get; set; }
    }
}
