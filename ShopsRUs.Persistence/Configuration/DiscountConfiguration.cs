using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopsRUs.Application.Constants;
using ShopsRUs.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ShopsRUs.Persistence.Configuration
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            var discount = new List<Discount>
            {
              new Discount
              {
                  Id = Guid.NewGuid(),
                  Percentage = 10,
                  Name = "Affliate",
                  Type = CampaignDiscounts.AffliateDiscount,
                  CreatedAt = DateTime.Now
              },
              new Discount
              {
                  Id = Guid.NewGuid(),
                  Percentage = 30,
                  Name = "Employee",
                  Type = CampaignDiscounts.EmployeeDiscount,
                  CreatedAt = DateTime.Now
              },
              new Discount
              {
                  Id = Guid.NewGuid(),
                  Percentage = 5,
                  Name = "Old Customer",
                  Type = CampaignDiscounts.OldCustomerDiscount,
                  CreatedAt = DateTime.Now
              },
              new Discount
              {
                  Id = Guid.NewGuid(),
                  Percentage = 5,
                  Name = "100 Dollar Discount",
                  Type = CampaignDiscounts.Per100DollarDiscount,
                  CreatedAt = DateTime.Now
              }
            };

            builder.HasData(discount);
        }
    }
}
