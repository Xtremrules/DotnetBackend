using DotnetBackend.Core.Entity.Abstract;
using DotnetBackend.Core.Entity.Interface;

namespace DotnetBackend.Core.Entity
{
    public class Customer : AuditableEntity<Guid>, ISoftDelete
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDeleted { get; set; }

        public int StateID { get; set; }
        public virtual State State { get; set; }
    }
}
