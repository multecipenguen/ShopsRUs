using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopsRUs.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ShopsRUs.Persistence.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            var customer = new List<Customer>
            {
                new Customer
                {
                    Id = Guid.NewGuid(),
                    IsAffliate = true,
                    Name = "Özgür",
                    CreatedAt = DateTime.Now

                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    IsEmployee = true,
                    Name = "Burcu",
                    CreatedAt = DateTime.Now

                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Mısra",
                    CreatedAt = DateTime.Now
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Duygu",
                    CreatedAt = DateTime.Now.AddYears(-5)
                }
            };

            builder.HasData(customer);
        }
    }
}
