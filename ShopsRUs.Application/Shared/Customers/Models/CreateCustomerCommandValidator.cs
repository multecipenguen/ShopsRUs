using FluentValidation;
using ShopsRUs.Application.Customers.Commands;

namespace ShopsRUs.Application.Customers.Models
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }
}
