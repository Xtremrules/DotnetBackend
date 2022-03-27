namespace DotnetBackend.Core.Entities.Interfaces
{
    public interface IAuditableEntity
    {
        DateTimeOffset UpdatedDate { get; set; }
        string UpdatedBy { get; set; }
    }
}
