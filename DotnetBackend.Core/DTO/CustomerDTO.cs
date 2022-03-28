using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBackend.Core.DTO
{
    public class CustomerDTO : Customer
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Status { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
