using DotnetBackend.Core.Entities.Interfaces;

namespace DotnetBackend.Core.Entities.Abstracts
{
    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity
    {
        public DateTimeOffset UpdatedDate { get; set; } = DateTimeOffset.Now;
        public string UpdatedBy { get; set; }
    }
}
