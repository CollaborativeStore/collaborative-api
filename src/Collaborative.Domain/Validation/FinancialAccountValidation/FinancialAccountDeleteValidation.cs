using Collaborative.Domain.Interfaces.Repository;
using Collaborative.Domain.Models;
using FluentValidation;

namespace Collaborative.Domain.Validation.FinancialAccountValidation
{
    public class FinancialAccountDeleteValidation : AbstractValidator<FinancialAccount>
    {
        private IFinancialAccountRepository _financialAccountRepository;
        
        public FinancialAccountDeleteValidation(IFinancialAccountRepository financialAccountRepository)
        {
            _financialAccountRepository = financialAccountRepository;

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("Id cannot be null or empty");
        }
    }
}
