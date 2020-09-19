using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Collaborative.API.ViewModels.Collaborator
{
    public class CollaboratorNameViewModel
    {
        public CollaboratorNameViewModel() { }

        public CollaboratorNameViewModel(string name)
        {
            Name = name;
        }

        [FromRoute(Name = "name")]
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
    }
}
