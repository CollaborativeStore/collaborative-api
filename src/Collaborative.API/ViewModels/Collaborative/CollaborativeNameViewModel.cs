using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Collaborative.API.ViewModels.Collaborative
{
    public class CollaborativeNameViewModel
    {
        public CollaborativeNameViewModel() { }

        public CollaborativeNameViewModel(string name)
        {
            Name = name;
        }

        [FromRoute(Name = "name")]
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
    }
}
