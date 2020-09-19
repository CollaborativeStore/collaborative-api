using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Collaborative.API.ViewModels.Collaborator
{
    public class CollaboratorCpfViewModel
    {
        public CollaboratorCpfViewModel() { }

        public CollaboratorCpfViewModel(string cpf)
        {
            CPF = cpf;
        }

        [FromRoute(Name = "cpf")]
        [Required(ErrorMessage = "CPF is required!")]
        [RegularExpression("([0-9]{11})")]
        public string CPF { get; set; }
    }
}
