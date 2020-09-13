using Collaborative.Domain.Models;

namespace Collaborative.API.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Total { get; set; }
    }
}
