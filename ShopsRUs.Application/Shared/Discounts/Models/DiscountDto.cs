using ShopsRUs.Application.ProfileMapping;
using ShopsRUs.Domain.Entities;
using System;

namespace ShopsRUs.Application.Discounts.Models
{
    public class DiscountDto : IMapFrom<Discount>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Percentage { get; set; }
        public decimal Amount { get; set; }
    }
}
