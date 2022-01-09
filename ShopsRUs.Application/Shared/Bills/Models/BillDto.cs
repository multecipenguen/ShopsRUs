using AutoMapper;
using ShopsRUs.Application.Invoices.Queries;
using ShopsRUs.Application.ProfileMapping;
using ShopsRUs.Domain.Entities;
using System;

namespace ShopsRUs.Application.Bills.Models
{
    public class BillDto : IMapFrom<Invoice>
    {
        public decimal Amount { get; set; }
        public Guid CustomerId { get; set; }
        public bool IsGrocery { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BillDto, GetTotalInvoiceAmountQuery>();
        }
    }
}
