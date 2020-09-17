using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Collaborative.API.ViewModels.Collaborative
{
    public class CollaborativeMailViewModel
    {
        public CollaborativeMailViewModel() { }

        public CollaborativeMailViewModel(string mail)
        {
            Mail = mail;
        }

        [FromRoute(Name = "mail")]
        [Required(ErrorMessage = "Mail is required!")]
        public string Mail { get; set; }
    }
}
