using DotnetBackend.Core.Entities.Abstracts;

namespace DotnetBackend.Core.Entities
{
    public class LGA : Entity<int>
    {
        public string Name { get; set; }

        public int StateId { get; set; }
        public virtual State State { get; set; }
    }
}
