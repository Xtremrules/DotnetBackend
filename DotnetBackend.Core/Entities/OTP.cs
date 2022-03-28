using DotnetBackend.Core.Entities.Abstracts;

namespace DotnetBackend.Core.Entities
{
    public class OTP: AuditableEntity
    {
        public string HashOTPCode { get; set; }
        public string Status { get; set; } = Constants.UNUSED;
        public long CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
