using Collaborative.Domain.Models;
using FluentValidation;

namespace Collaborative.Domain.Validation.PaymentValidation
{
    public class PaymentInsertValidation : AbstractValidator<Payment>
    {
        public PaymentInsertValidation()
        {
            RuleFor(x => x.Total)
                .NotNull()
                .NotEmpty()
                .WithMessage("Total cannot be null or empty");

            RuleFor(x => x.OrderId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Order cannot be null or empty");

            RuleFor(x => x.FinancialAccountId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Financial Account cannot be null or empty");
        }
    }
}
