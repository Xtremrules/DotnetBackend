using DotnetBackend.Core.Entities.Abstracts;

namespace DotnetBackend.Core.Entities
{
    public class OTP: AuditableEntity
    {
        public string Code { get; set; }
        public Status Status { get; set; } = Status.UNUSED;

        public long CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
