using Collaborative.Domain.Models;
using FluentValidation;

namespace Collaborative.Domain.Validation.CollaboratorValidation
{
    public class CollaboratorDeleteValidation : AbstractValidator<Collaborator>
    {
        public CollaboratorDeleteValidation()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Id cannot be null");
        }
    }
}
