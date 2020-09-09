using System.Collections.Generic;

namespace Collaborative.Domain.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public Collaborative Collaborative { get; set; }
         
        public List<Product> Products { get; set; }
    }
}
