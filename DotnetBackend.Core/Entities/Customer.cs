using DotnetBackend.Core.Entities.Abstracts;
using DotnetBackend.Core.Entities.Interfaces;

namespace DotnetBackend.Core.Entities
{
    public class Customer : AuditableEntity, ISoftDelete
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Status Status = Status.INACTIVE;
        public long LGAId { get; set; }
        public virtual LGA LGA { get; set; }
        public virtual ICollection<OTP> OTPs { get; set; }
    }
}
