using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Domain.Entities
{
    public class Discount : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        public double Percentage { get; set; }
        public decimal Amount { get; set; }
        public bool IsPercentage { get { return Percentage > 0; } }
    }
}
