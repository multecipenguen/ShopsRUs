using AutoMapper;
using ShopsRUs.Application.Discounts.Commands;
using ShopsRUs.Application.ProfileMapping;
using ShopsRUs.Domain.Entities;

namespace ShopsRUs.Application.Discounts.Models
{
    public class CreateDiscountDto : IMapFrom<Discount>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Percentage { get; set; }
        public decimal Amount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDiscountDto, CreateDiscountCommand>();
            profile.CreateMap<CreateDiscountCommand, Discount>();
        }
    }
}
