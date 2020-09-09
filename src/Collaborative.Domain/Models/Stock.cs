using System.Collections.Generic;

namespace Collaborative.Domain.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnityPrice { get; set; }

        public int CollaborativeId { get; set; }
        public Collaborative Collaborative { get; set; }
         
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
    }
}
