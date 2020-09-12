using Collaborative.Domain.Models;
using FluentValidation;

namespace Collaborative.Domain.Validation.StockValidation
{
    public class StockDeleteValidation : AbstractValidator<Stock>
    {
        public StockDeleteValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("Id cannot be null or empty");
        }
    }
}
