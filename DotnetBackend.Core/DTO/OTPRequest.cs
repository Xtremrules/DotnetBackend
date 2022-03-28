using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBackend.Core.DTO
{
    public class OTPValidateRequest: OTPRequest
    {
        [Required]
        public string code { get; set; }
    }

    public class OTPRequest
    {
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public long CustomerId { get; set; }
    }
}
