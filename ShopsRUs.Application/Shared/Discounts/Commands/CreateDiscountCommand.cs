using AutoMapper;
using MediatR;
using OneOf;
using ShopsRUs.Application.Discounts.Models;
using ShopsRUs.Application.Repository;
using ShopsRUs.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShopsRUs.Application.Discounts.Commands
{
    public class CreateDiscountCommand : IRequest<OneOf<DiscountDto, Error>>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Percentage { get; set; }
        public decimal Amount { get; set; }
    }

    public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, OneOf<DiscountDto, Error>>
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDiscountCommandHandler(IDiscountRepository discountRepository, IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _discountRepository = discountRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OneOf<DiscountDto, Error>> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            if (_discountRepository.Exists(x => x.Type.ToLower() == request.Type.ToLower()))
                return new Error("Discount already exist");

            var discount = _mapper.Map<Discount>(request);
            discount.Id = Guid.NewGuid();
            discount.CreatedAt = DateTime.Now;

            _discountRepository.Add(discount);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<DiscountDto>(discount);
        }
    }
}
