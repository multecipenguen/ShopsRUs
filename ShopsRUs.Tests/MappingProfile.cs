using AutoMapper;
using ShopsRUs.Application.Customers.Commands;
using ShopsRUs.Application.Customers.Models;
using ShopsRUs.Application.Discounts.Commands;
using ShopsRUs.Application.Discounts.Models;
using ShopsRUs.Domain.Entities;

namespace ShopsRUs.Tests
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CreateCustomerDto, CreateCustomerCommand>();
            CreateMap<CreateCustomerCommand, Customer>();

            CreateMap<Discount, DiscountDto>();
            CreateMap<CreateDiscountDto, CreateDiscountCommand>();
            CreateMap<CreateDiscountCommand, Discount>();
        }
    }
}
