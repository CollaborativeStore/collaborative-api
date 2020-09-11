using Collaborative.Domain.Interfaces.Repository;
using Collaborative.Domain.Models;
using FluentValidation;

namespace Collaborative.Domain.Validation.OrderValidation
{
    public class OrderDeleteValidation : AbstractValidator<Order>
    {
        public OrderDeleteValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("Id cannot be null or empty");
        }
    }
}
