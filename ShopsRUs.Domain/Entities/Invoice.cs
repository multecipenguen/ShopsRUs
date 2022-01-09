using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public decimal Amount { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
