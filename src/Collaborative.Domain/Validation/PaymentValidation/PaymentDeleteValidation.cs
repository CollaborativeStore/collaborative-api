using Collaborative.Domain.Models;
using FluentValidation;

namespace Collaborative.Domain.Validation.PaymentValidation
{
    public class PaymentDeleteValidation : AbstractValidator<Payment>
    {
        public PaymentDeleteValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("Id cannot be null or empty");
        }
    }
}
