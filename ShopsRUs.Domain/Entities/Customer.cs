using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Domain.Entities
{
    public class Customer : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public bool IsAffliate { get; set; }
        public bool IsEmployee { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
