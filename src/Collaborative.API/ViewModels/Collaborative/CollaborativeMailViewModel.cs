using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Collaborative.API.ViewModels.Collaborative
{
    public class CollaborativeMailViewModel
    {
        public CollaborativeMailViewModel() { }

        public CollaborativeMailViewModel(string mail)
        {
            Email = mail;
        }

        [FromRoute(Name = "mail")]
        [Required(ErrorMessage = "Mail is required!")]
        public string Email { get; set; }
    }
}
