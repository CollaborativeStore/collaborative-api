using System;
using System.Collections.Generic;

namespace Collaborative.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DeletionDate { get; set; }
        public decimal UnityPrice { get; set; }

        public int CollaboratorId { get; set; }
        public Collaborator Collaborator { get; set; }
        public int StockId { get; set; }
        public Stock Stock { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
        public List<Order> Orders { get; set; }
    }
}
