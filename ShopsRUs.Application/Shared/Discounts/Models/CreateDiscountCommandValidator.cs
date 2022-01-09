using FluentValidation;
using ShopsRUs.Application.Discounts.Commands;

namespace ShopsRUs.Application.Discounts.Models
{
    public class CreateDiscountCommandValidator : AbstractValidator<CreateDiscountCommand>
    {
        public CreateDiscountCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Type).NotEmpty().MaximumLength(50);
        }
    }
}
