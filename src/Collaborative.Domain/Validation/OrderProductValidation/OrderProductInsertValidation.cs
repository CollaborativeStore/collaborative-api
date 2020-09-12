using Collaborative.Domain.Models;
using FluentValidation;

namespace Collaborative.Domain.Validation.OrderProductValidation
{
    public class OrderProductInsertValidation : AbstractValidator<OrderProduct>
    {
        public OrderProductInsertValidation()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty()
                .NotNull()
                .WithMessage("OrderId cannot be null or empty");

            RuleFor(x => x.ProductId)
                .NotEmpty()
                .NotNull()
                .WithMessage("ProductId cannot be null or empty");

            RuleFor(x => x.Quantity)
                .NotEmpty()
                .NotNull()
                .WithMessage("Quantity cannot be null or empty");
        }
    }
}
