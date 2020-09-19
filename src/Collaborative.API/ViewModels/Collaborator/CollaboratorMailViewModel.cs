using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Collaborative.API.ViewModels.Collaborator
{
    public class CollaboratorMailViewModel
    {
        public CollaboratorMailViewModel() { }

        public CollaboratorMailViewModel(string mail)
        {
            Mail = mail;
        }

        [FromRoute(Name = "mail")]
        [Required(ErrorMessage = "Mail is required!")]
        public string Mail { get; set; }
    }
}
