namespace DotnetBackend.Core.DTO
{
    public class LGADTO
    {
        public long StateId { get; set; }

        public IEnumerable<lga> Lgas { get; set; }
    }

    public class lga
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}