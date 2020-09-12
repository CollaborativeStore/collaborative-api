using Collaborative.Domain.Models;
using FluentValidation;

namespace Collaborative.Domain.Validation.OrderProductValidation
{
    public class OrderProductDeleteValidation : AbstractValidator<OrderProduct>
    {
        public OrderProductDeleteValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("Id cannot be null or empty");
        }
    }
}
