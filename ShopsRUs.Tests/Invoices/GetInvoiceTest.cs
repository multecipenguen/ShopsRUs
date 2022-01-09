using FluentAssertions;
using Moq;
using ShopsRUs.Application;
using ShopsRUs.Application.Invoices.Models;
using ShopsRUs.Application.Invoices.Queries;
using ShopsRUs.Application.Repository;
using ShopsRUs.Domain.Entities;
using ShopsRUs.Tests.Mock;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ShopsRUs.Tests.Invoices
{
    public class GetInvoiceTest
    {

        private readonly Mock<ICustomerRepository> _customerRepository;
        private readonly Mock<IDiscountRepository> _discountRepository;
        private readonly Mock<IInvoiceRepository> _inventorypository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        public GetInvoiceTest()
        {
            _customerRepository = CustomerMock.GetCustomerRepository();
            _discountRepository = DiscountMock.GetDiscountRepository();
            _inventorypository = new Mock<IInvoiceRepository>();
            _inventorypository.Setup(x => x.Add(It.IsAny<Invoice>()));
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);
        }


        [Fact]
        public async Task Handle_NonExistingCustomer()
        {
            var id = Guid.Parse("B0788D2F-8003-43C1-92A4-EDC76A7C5DDD");

            var handler = new GetTotalInvoiceAmountQueryHandler(_inventorypository.Object, _customerRepository.Object,
                _discountRepository.Object, _unitOfWork.Object);

            var result = await handler.Handle(new GetTotalInvoiceAmountQuery
            {
                IsGrocery = false,
                Amount = 300,
                CustomerId = id
            }, CancellationToken.None);

            var matchedResult = result.Match<NotFound>(x => null, x => x);
            matchedResult.Description.Should().Be("Customer does not exist");
        }


        [Fact]
        public async Task Handle_AffliateCustomer()
        {
            var id = Guid.Parse("FDF83730-67E7-4961-B842-9244FFA5032A");

            var handler = new GetTotalInvoiceAmountQueryHandler(_inventorypository.Object, _customerRepository.Object,
                _discountRepository.Object, _unitOfWork.Object);

            var result = await handler.Handle(new GetTotalInvoiceAmountQuery
            {
                IsGrocery = false,
                Amount = 300,
                CustomerId = id
            }, CancellationToken.None);

            var matchedResult = result.Match<InvoiceDto>(x => x, x => null);

            matchedResult.Amount.Should().Be(270);
        }


        [Fact]
        public async Task Handle_EmployeeCustomer()
        {
            var id = Guid.Parse("F82F86E5-B247-46B0-9676-C6754A95C2E2");

            var handler = new GetTotalInvoiceAmountQueryHandler(_inventorypository.Object, _customerRepository.Object,
                _discountRepository.Object, _unitOfWork.Object);

            var result = await handler.Handle(new GetTotalInvoiceAmountQuery
            {
                IsGrocery = false,
                Amount = 100,
                CustomerId = id
            }, CancellationToken.None);

            var matchedResult = result.Match<InvoiceDto>(x => x, x => null);

            matchedResult.Amount.Should().Be(70);
        }

        [Fact]
        public async Task Handle_OldCustomer_ReturnDiscount()
        {
            var id = Guid.Parse("3934A23B-EA17-4470-9C9D-A46DFAFB09D6");

            var handler = new GetTotalInvoiceAmountQueryHandler(_inventorypository.Object, _customerRepository.Object,
                _discountRepository.Object, _unitOfWork.Object);

            var result = await handler.Handle(new GetTotalInvoiceAmountQuery
            {
                IsGrocery = false,
                Amount = 300,
                CustomerId = id
            }, CancellationToken.None);

            var matchedResult = result.Match<InvoiceDto>(x => x, x => null);

            matchedResult.Amount.Should().Be(285.00m);
        }

        [Fact]
        public async Task Handle_Over100DollarBill_ReturnDiscount()
        {
            var id = Guid.Parse("3934A23B-EA17-4470-9C9D-A46DFAFB09D6");

            var handler = new GetTotalInvoiceAmountQueryHandler(_inventorypository.Object, _customerRepository.Object,
                _discountRepository.Object, _unitOfWork.Object);

            var result = await handler.Handle(new GetTotalInvoiceAmountQuery
            {
                IsGrocery = false,
                Amount = 990,
                CustomerId = id
            }, CancellationToken.None);

            var matchedResult = result.Match<InvoiceDto>(x => x, x => null);

            matchedResult.Amount.Should().Be(940.50M);
        }

        [Fact]
        public async Task Handle_NormalCustomerWithLessThan100DollarBill_ReturnNoDiscount()
        {
            var id = Guid.Parse("3934A23B-EA17-4470-9C9D-A46DFAFB09D6");

            var handler = new GetTotalInvoiceAmountQueryHandler(_inventorypository.Object, _customerRepository.Object,
                _discountRepository.Object, _unitOfWork.Object);

            var result = await handler.Handle(new GetTotalInvoiceAmountQuery
            {
                IsGrocery = false,
                Amount = 90,
                CustomerId = id
            }, CancellationToken.None);

            var matchedResult = result.Match<InvoiceDto>(x => x, x => null);

            matchedResult.Amount.Should().Be(85.50m);
        }

        [Fact]
        public async Task Handle_GroceryBill_ReturnNoDiscount()
        {
            var id = Guid.Parse("3934A23B-EA17-4470-9C9D-A46DFAFB09D6");

            var handler = new GetTotalInvoiceAmountQueryHandler(_inventorypository.Object, _customerRepository.Object,
                _discountRepository.Object, _unitOfWork.Object);

            var result = await handler.Handle(new GetTotalInvoiceAmountQuery
            {
                IsGrocery = true,
                Amount = 990,
                CustomerId = id
            }, CancellationToken.None);

            var matchedResult = result.Match<InvoiceDto>(x => x, x => null);

            matchedResult.Amount.Should().Be(990);
        }
    }
}
