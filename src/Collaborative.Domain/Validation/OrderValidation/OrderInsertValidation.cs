using Collaborative.Domain.Models;
using FluentValidation;

namespace Collaborative.Domain.Validation.OrderValidation
{
    class OrderInsertValidation : AbstractValidator<Order>
    {
        public OrderInsertValidation()
        {
            RuleFor(x => x.Status)
                .Must(x => x.Equals(1) || x.Equals(0))
                .WithMessage("Status invalid");
        }
    }
}