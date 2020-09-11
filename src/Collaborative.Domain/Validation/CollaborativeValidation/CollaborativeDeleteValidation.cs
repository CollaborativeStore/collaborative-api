using FluentValidation;
using Collab = Collaborative.Domain.Models.Collaborative;

namespace Collaborative.Domain.Validation.CollaborativeValidation
{
    public class CollaborativeDeleteValidation : AbstractValidator<Collab>
    {
        public CollaborativeDeleteValidation()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Id cannot be null");
        }
    }
}
