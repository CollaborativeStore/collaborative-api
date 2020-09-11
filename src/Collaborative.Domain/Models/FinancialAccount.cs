using System;
using System.Collections.Generic;

namespace Collaborative.Domain.Models
{
    public class FinancialAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Open { get; set; }
        public DateTime? Close { get; set; }

        public int CollaborativeId { get; set; }
        public Collaborative Collaborative { get; set; }

        public List<Payment> Payments { get; set; }
    }
}
