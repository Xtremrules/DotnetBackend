using DotnetBackend.Core.Entities.Interfaces;

namespace DotnetBackend.Core.Entities.Abstracts
{
    public abstract class AuditableEntity : BaseEntity, IAuditableEntity
    {
        public DateTimeOffset UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
