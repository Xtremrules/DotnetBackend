using DotnetBackend.Core.Entity.Abstract;

namespace DotnetBackend.Core.Entity
{
    public class LGA : Entity<int>
    {
        public string Name { get; set; }

        public int StateID { get; set; }
        public virtual State State { get; set; }
    }
}
