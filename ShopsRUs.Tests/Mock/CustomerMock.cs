using Moq;
using ShopsRUs.Application.Repository;
using ShopsRUs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ShopsRUs.Tests.Mock
{
    public class CustomerMock
    {
        public static Mock<ICustomerRepository> GetCustomerRepository()
        {
            var customers = new List<Customer>
            {
                new Customer
                {
                    Id = Guid.Parse("FDF83730-67E7-4961-B842-9244FFA5032A"),
                    IsAffliate = true,
                    Name = "Özgür",
                    CreatedAt = DateTime.Now

                },
                new Customer
                {
                    Id = Guid.Parse("FC7491B8-21D3-4122-A015-6E1D17606DA1"),
                    IsEmployee = false,
                    Name = "Mısra",
                    CreatedAt = DateTime.Now

                },
                new Customer
                {
                    Id = Guid.Parse("F82F86E5-B247-46B0-9676-C6754A95C2E2"),
                    Name = "Burcu",
                    IsEmployee = true,
                    CreatedAt = DateTime.Now
                },
                new Customer
                {
                    Id = Guid.Parse("3934A23B-EA17-4470-9C9D-A46DFAFB09D6"),
                    Name = "Duygu",
                    CreatedAt = DateTime.Now.AddYears(-5)
                }
            };


            var mockedcustomerRepository = new Mock<ICustomerRepository>();
            mockedcustomerRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(customers);

            mockedcustomerRepository.Setup(x => x.Add(It.IsAny<Customer>()));

            mockedcustomerRepository.Setup(x => x.Exists(It.IsAny<Expression<Func<Customer, bool>>>()))
            .Returns((Expression<Func<Customer, bool>> func) =>
            {
                return customers.Any(func.Compile());
            });

            mockedcustomerRepository.Setup(x => x.SingleOrDefaultAsync(It.IsAny<Expression<Func<Customer, bool>>>()))
           .ReturnsAsync((Expression<Func<Customer, bool>> func) =>
           {
               return customers.Where(func.Compile()).FirstOrDefault();
           });




            return mockedcustomerRepository;
        }
    }
}
