using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Collaborative.API.ViewModels.Collaborative
{
    public class CollaborativeCnpjViewModel
    {
        public CollaborativeCnpjViewModel() { }

        public CollaborativeCnpjViewModel(string cnpj)
        {
            CNPJ = cnpj;
        }

        [FromRoute(Name = "cnpj")]
        [Required(ErrorMessage = "CNPJ is required!")]
        [RegularExpression("([0-9]{14})")]
        public string CNPJ { get; set; }
    }
}
