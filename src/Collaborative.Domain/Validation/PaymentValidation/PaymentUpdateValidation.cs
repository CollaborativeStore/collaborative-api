using Collaborative.Domain.Interfaces.Repository;
using Collaborative.Domain.Models;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Collaborative.Domain.Validation.PaymentValidation
{
    public class PaymentUpdateValidation : AbstractValidator<Payment>
    {
        private IPaymentRepository _paymentRepository;

        public PaymentUpdateValidation(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;

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

            RuleFor(x => x)
                .MustAsync(ValidationId)
                .WithMessage("Invalid Id");
        }

        private async Task<bool> ValidationId(Payment payment, CancellationToken cancellationToken)
        {
            var paymentRepository = await _paymentRepository.GetByIdAsync(payment.Id);

            return payment.Id != paymentRepository.Id ? false : true;
        }
    }
}
