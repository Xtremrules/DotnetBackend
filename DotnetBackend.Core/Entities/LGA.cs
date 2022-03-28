using DotnetBackend.Core.Entities.Abstracts;

namespace DotnetBackend.Core.Entities
{
    public class LGA : BaseEntity
    {
        public string Name { get; set; }

        public long StateId { get; set; }
        public virtual State State { get; set; }
        //public virtual ICollection<Customer> Customers { get; set; }
    }
}
