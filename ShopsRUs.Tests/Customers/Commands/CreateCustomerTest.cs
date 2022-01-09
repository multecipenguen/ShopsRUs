using AutoMapper;
using Moq;
using ShopsRUs.Application.Customers.Commands;
using ShopsRUs.Application.Customers.Models;
using ShopsRUs.Application.ProfileMapping;
using ShopsRUs.Application.Repository;
using ShopsRUs.Domain.Entities;
using ShopsRUs.Tests.Mock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace ShopsRUs.Tests.Customers.Commands
{
    public class CreateCustomerTest
    {
        private readonly Mock<ICustomerRepository> _customerRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly IMapper _mapper;
        public CreateCustomerTest()
        {
            _customerRepository = CustomerMock.GetCustomerRepository();
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCustomer_AddsCustomerToRepo()
        {
            var handler = new CreateCustomerCommandHandler(_customerRepository.Object, _unitOfWork.Object, _mapper);

            var result = await handler.Handle(new CreateCustomerCommand { Name = "Tarık" }, CancellationToken.None);


            _customerRepository.Verify(x => x.Add(It.IsAny<Customer>()), Times.Once);
            _unitOfWork.Verify(x => x.SaveChangesAsync(), Times.Once);
            result.Should().BeOfType<CustomerDto>();
        }


    }
}
