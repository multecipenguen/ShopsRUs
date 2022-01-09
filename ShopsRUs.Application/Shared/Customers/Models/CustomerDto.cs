using ShopsRUs.Application.ProfileMapping;
using ShopsRUs.Domain.Entities;
using System;

namespace ShopsRUs.Application.Customers.Models
{
    public class CustomerDto : IMapFrom<Customer>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsAffliate { get; set; }
        public bool IsEmployee { get; set; }
    }
}
