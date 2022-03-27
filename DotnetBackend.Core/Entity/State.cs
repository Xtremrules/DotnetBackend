using DotnetBackend.Core.Entity.Abstract;

namespace DotnetBackend.Core.Entity
{
    public class State: Entity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<LGA> LGAs { get; set; }
    }
}
