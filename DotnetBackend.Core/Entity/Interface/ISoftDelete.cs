namespace DotnetBackend.Core.Entity.Interface
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
