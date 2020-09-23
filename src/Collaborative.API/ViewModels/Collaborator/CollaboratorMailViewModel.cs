using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Collaborative.API.ViewModels.Collaborator
{
    public class CollaboratorMailViewModel
    {
        public CollaboratorMailViewModel() { }

        public CollaboratorMailViewModel(string mail)
        {
            Email = mail;
        }

        [FromRoute(Name = "mail")]
        [Required(ErrorMessage = "Mail is required!")]
        public string Email { get; set; }
    }
}
