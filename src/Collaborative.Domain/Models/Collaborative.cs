using System;
using System.Collections.Generic;

namespace Collaborative.Domain.Models
{
    public class Collaborative : Person
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ClosingDate { get; set; }


        public int StockId { get; set; }
        public Stock Stock { get; set; }

        public List<Collaborator> Collaborators { get; set; }
        public List<FinancialAccount> FinancialAccounts { get; set; }
        public List<Order> Orders { get; set; }
    }
}
