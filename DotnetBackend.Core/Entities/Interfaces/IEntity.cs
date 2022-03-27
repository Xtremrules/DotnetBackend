namespace DotnetBackend.Core.Entities.Interfaces
{
    public interface IEntity<T>
    {
        T Id { get; set; }

        DateTimeOffset CreatedDate { get; set; }
        string CreatedBy { get; set; }
    }
}
