using AutoMapper;
using MediatR;
using ShopsRUs.Application.Customers.Models;
using ShopsRUs.Application.Repository;
using ShopsRUs.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShopsRUs.Application.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<CustomerDto>
    {
        public string Name { get; set; }
        public bool IsAffliate { get; set; }
        public bool IsEmployee { get; set; }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);

            if(_customerRepository.Exists(x=>x.Name==request.Name))
            {
                throw new Exception("Customer for that name already exists");
            }

            customer.Id = Guid.NewGuid();
            customer.CreatedAt = DateTime.Now;

            _customerRepository.Add(customer);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
