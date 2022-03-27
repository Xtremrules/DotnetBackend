using System.ComponentModel.DataAnnotations;

namespace DotnetBackend.Core.Entities.Abstracts
{
    public abstract class BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        public string CreatedBy { get; set; }

        public T Clone<T>() where T : BaseEntity
        {
            return (T)this.MemberwiseClone();
        }
    }
}
