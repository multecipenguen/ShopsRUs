using AutoMapper;
using MediatR;
using ShopsRUs.Application.Discounts.Models;
using ShopsRUs.Application.Repository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ShopsRUs.Application.Discounts.Queries
{
    public class GetAllDiscountQuery : IRequest<List<DiscountDto>>
    {
    }

    public class GetAllDiscountQueryHandler : IRequestHandler<GetAllDiscountQuery, List<DiscountDto>>
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;

        public GetAllDiscountQueryHandler(IDiscountRepository discountRepository, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
        }

        public async Task<List<DiscountDto>> Handle(GetAllDiscountQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<DiscountDto>>(await _discountRepository.GetAllAsync());
        }
    }
}
