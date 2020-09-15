using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Collaborative.API.ViewModels.Collaborative
{
    public class CollaborativeIdViewModel
    {
        public CollaborativeIdViewModel() { }

        public CollaborativeIdViewModel(int id)
        {
            Id = id;
        }

        [FromRoute(Name = "id")]
        [Required(ErrorMessage = "Id is required!")]
        public int Id { get; set; }
    }
}
