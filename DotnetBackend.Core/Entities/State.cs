using DotnetBackend.Core.Entities.Abstracts;

namespace DotnetBackend.Core.Entities
{
    public class State: Entity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<LGA> LGAs { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
