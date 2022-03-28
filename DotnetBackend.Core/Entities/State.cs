using DotnetBackend.Core.Entities.Abstracts;

namespace DotnetBackend.Core.Entities
{
    public class State: BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<LGA> LGAs { get; set; }
    }
}
