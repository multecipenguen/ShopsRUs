using AutoMapper;
using ShopsRUs.Application.Customers.Commands;
using ShopsRUs.Application.ProfileMapping;
using ShopsRUs.Domain.Entities;

namespace ShopsRUs.Application.Customers.Models
{
    public class CreateCustomerDto : IMapFrom<Customer>
    {
        public string Name { get; set; }
        public bool IsAffliate { get; set; }
        public bool IsEmployee { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCustomerDto, CreateCustomerCommand>();
            profile.CreateMap<CreateCustomerCommand, Customer>();
        }
    }
}
