using Collaborative.Domain.Models;
using FluentValidation;

namespace Collaborative.Domain.Validation.ProductValidation
{
    public class ProductDeleteValidation : AbstractValidator<Product>
    {
        public ProductDeleteValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("Id cannot be null or empty");
        }
    }
}
