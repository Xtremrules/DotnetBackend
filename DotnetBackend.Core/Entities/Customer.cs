using DotnetBackend.Core.Entities.Abstracts;
using DotnetBackend.Core.Entities.Interfaces;

namespace DotnetBackend.Core.Entities
{
    public class Customer : AuditableEntity<Guid>, ISoftDelete
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDeleted { get; set; }

        public int StateId { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<OTP> OTPs { get; set; }
    }
}
