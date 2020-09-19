using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Collaborative.API.ViewModels.Collaborator
{
    public class CollaboratorIdViewModel
    {
        public CollaboratorIdViewModel() { }

        public CollaboratorIdViewModel(int id)
        {
            Id = id;
        }

        [FromRoute(Name = "id")]
        [Required(ErrorMessage = "Id is required!")]
        public int Id { get; set; }
    }
}
