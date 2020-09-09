using System;
using System.Collections.Generic;

namespace Collaborative.Domain.Models
{
    public class Collaborator : Person
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ClosingDate { get; set; }

        public int CollaborativeId { get; set; }
        public Collaborative Collaborative { get; set; }

        public List<Product> Products { get; set; }
    }
}
