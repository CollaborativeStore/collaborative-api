﻿using Collaborative.Domain.Interfaces.Repository;
using Collaborative.Domain.Models;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Collaborative.Domain.Validation.FinancialAccountValidation
{
    public class FinancialAccountUpdateValidation : AbstractValidator<FinancialAccount>
    {
        private IFinancialAccountRepository _financialAccountRepository;

        public FinancialAccountUpdateValidation(IFinancialAccountRepository financialAccountRepository)
        {
            _financialAccountRepository = financialAccountRepository;

            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Id cannot be null or empty");

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name cannot be null or empty");

            RuleFor(x => x)
                .MustAsync(ValidationName)
                .WithMessage("Name is being used");
        }

        private async Task<bool> ValidationName(FinancialAccount financial, CancellationToken cancellationToken)
        {
            var financialAccountRepository = await _financialAccountRepository.GetByName(financial.Name);

            return financialAccountRepository?.Id != financial.Id ? false : true;
        }
    }
}
