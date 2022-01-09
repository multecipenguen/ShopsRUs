using AutoMapper;
using FluentAssertions;
using Moq;
using ShopsRUs.Application;
using ShopsRUs.Application.Customers.Models;
using ShopsRUs.Application.Customers.Queries;
using ShopsRUs.Application.ProfileMapping;
using ShopsRUs.Application.Repository;
using ShopsRUs.Tests.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ShopsRUs.Tests.Customers.Queries
{
    public class CustomerQueryTest
    {

        private readonly Mock<ICustomerRepository> _customerRepository;
        private readonly IMapper _mapper;
        public CustomerQueryTest()
        {
            _customerRepository = CustomerMock.GetCustomerRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }


        [Fact]
        public async Task GetAllCustomers()
        {
            var handler = new GetAllCustomerQueryHandler(_customerRepository.Object, _mapper);

            var result = await handler.Handle(new GetAllCustomerQuery(), CancellationToken.None);

            result.Should().HaveCount(4);
        }

        [Fact]
        public async Task GetCustomerById()
        {
            var id = Guid.Parse("3934A23B-EA17-4470-9C9D-A46DFAFB09D6");

            var handler = new GetCustomerByIdQueryHandler(_customerRepository.Object, _mapper);

            var result = await handler.Handle(new GetCustomerByIdQuery(id), CancellationToken.None);

            var matchedResult = result.Match<CustomerDto>(x => x, x => new CustomerDto());

            matchedResult.Id.Should().Be(id);
        }


        [Fact]
        public async Task GetCustomerById_ReturnsNotFound()
        {
            var id = Guid.Parse("4a3becd7-34eb-4160-91ba-b5d3447ebb16");

            var handler = new GetCustomerByIdQueryHandler(_customerRepository.Object, _mapper);

            var result = await handler.Handle(new GetCustomerByIdQuery(id), CancellationToken.None);

            var matchedResult = result.Match<NotFound>(x => null, x => x);

            matchedResult.Description.Should().Be("Customer does not exist");
        }

        [Fact]
        public async Task GetCustomerByName_ReturnsCustomer()
        {
            var name = "Özgür";

            var handler = new GetCustomerByNameQueryHandler(_customerRepository.Object, _mapper);

            var result = await handler.Handle(new GetCustomerByNameQuery(name), CancellationToken.None);

            var matchedResult = result.Match<CustomerDto>(x => x, x => new CustomerDto());

            matchedResult.Name.Should().Be(name);
        }


        [Fact]
        public async Task GetCustomerByName_ReturnsNotFound()
        {
            var name = "Erkin";

            var handler = new GetCustomerByNameQueryHandler(_customerRepository.Object, _mapper);

            var result = await handler.Handle(new GetCustomerByNameQuery(name), CancellationToken.None);

            var matchedResult = result.Match<NotFound>(x => null, x => x);

            matchedResult.Description.Should().Be("Customer does not exist");
        }
    }
}
