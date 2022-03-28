using System.ComponentModel.DataAnnotations;

namespace DotnetBackend.Core.DTO
{
    public class Customer
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
