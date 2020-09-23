using Collaborative.Domain.Interfaces.Repository;
using Collaborative.Domain.Models;
using FluentValidation;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Collaborative.Domain.Validation.CollaboratorValidation
{
    public class CollaboratorUpdateValidator : AbstractValidator<Collaborator>
    {
        private ICollaboratorRepository _collaboratorRepository;

        public CollaboratorUpdateValidator(ICollaboratorRepository collaboratorRepository)
        {
            _collaboratorRepository = collaboratorRepository;

            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Id cannot be null or empty");

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name cannot be null or empty");

            RuleFor(x => x)
                .MustAsync(ValidationName)
                .WithMessage("Name is being used");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .NotNull()
                .WithMessage("Phone cannot be null or empty");

            RuleFor(x => x)
                .MustAsync(ValidationCpf)
                .WithMessage("CPF is being used or invalid format");

            RuleFor(x => x)
                .MustAsync(ValidationCnpj)
                .WithMessage("CNPJ is being used or invalid format");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Mail cannot be null or empty");

            RuleFor(x => x)
                .MustAsync(ValidationMail)
                .WithMessage("Mail is being used or invalid format");
        }

        private async Task<bool> ValidationName(Collaborator collab, CancellationToken cancellationToken)
        {
            var collaboratorRepository = await _collaboratorRepository.GetByName(collab.Name);

            return collaboratorRepository != null ? false : true;
        }

        private async Task<bool> ValidationCpf(Collaborator collab, CancellationToken cancellationToken)
        {
            if (collab.CPF == null)
            {
                return true;
            }

            var collabCpf = collab.CPF;
            var regex = "([0-9]{11})";

            if (!Regex.IsMatch(collabCpf, regex))
                return false;

            var collaboratorRepository = await _collaboratorRepository.GetByCpf(collab.CPF);

            return collaboratorRepository?.Id != collab.Id ? false : true;
        }

        private async Task<bool> ValidationCnpj(Collaborator collab, CancellationToken cancellationToken)
        {
            if (collab.CNPJ == null)
            {
                return true;
            }

            var collabCnpj = collab.CNPJ;
            var regex = "([0-9]{14})";

            if (!Regex.IsMatch(collabCnpj, regex))
                return false;

            var collaboratorRepository = await _collaboratorRepository.GetByCnpj(collab.CNPJ);

            return collaboratorRepository?.Id != collab.Id ? false : true;
        }

        private async Task<bool> ValidationMail(Collaborator collab, CancellationToken cancellationToken)
        {
            var collabMail = collab.Email;

            if (!IsValidEmail(collabMail))
                return false;

            var collaboratorRepository = await _collaboratorRepository.GetByMail(collab.Email);

            return collaboratorRepository?.Id != collab.Id ? false : true;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();

                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

        }
    }
}
