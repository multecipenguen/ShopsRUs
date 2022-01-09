using Moq;
using ShopsRUs.Application.Constants;
using ShopsRUs.Application.Repository;
using ShopsRUs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ShopsRUs.Tests.Mock
{
    public class DiscountMock
    {
        public static Mock<IDiscountRepository> GetDiscountRepository()
        {
            var discounts = new List<Discount>
            {
              new Discount
              {
                  Id = Guid.NewGuid(),
                  Percentage = 10,
                  Name = "Affliate Discount",
                  Type = CampaignDiscounts.AffliateDiscount,
                  CreatedAt = DateTime.Now
              },
              new Discount
              {
                  Id = Guid.NewGuid(),
                  Percentage = 30,
                  Name = "Employee Discount",
                  Type = CampaignDiscounts.EmployeeDiscount,
                  CreatedAt = DateTime.Now
              },
              new Discount
              {
                  Id = Guid.NewGuid(),
                  Percentage = 5,
                  Name = "Old Customer Discount",
                  Type = CampaignDiscounts.OldCustomerDiscount,
                  CreatedAt = DateTime.Now
              },
              new Discount
              {
                  Id = Guid.NewGuid(),
                  Percentage = 5,
                  Name = "Percent Per 100 Dollar Bill Discount",
                  Type = CampaignDiscounts.Per100DollarDiscount,
                  CreatedAt = DateTime.Now
              }
            };

            var mockeddiscountRepository = new Mock<IDiscountRepository>();
            mockeddiscountRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(discounts);

            mockeddiscountRepository.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<Discount, bool>>>()))
           .ReturnsAsync((Expression<Func<Discount, bool>> func) =>
           {
               return discounts.Where(func.Compile()).ToList();
           });

            mockeddiscountRepository.Setup(x => x.Add(It.IsAny<Discount>()));

            mockeddiscountRepository.Setup(x => x.Exists(It.IsAny<Expression<Func<Discount, bool>>>()))
              .Returns((Expression<Func<Discount, bool>> func) =>
              {
                  return discounts.Any(func.Compile());
              });

            mockeddiscountRepository.Setup(x => x.SingleOrDefaultAsync(It.IsAny<Expression<Func<Discount, bool>>>()))
           .ReturnsAsync((Expression<Func<Discount, bool>> func) =>
           {
               return discounts.Where(func.Compile()).FirstOrDefault();
           });

            return mockeddiscountRepository;
        }
    }
}
