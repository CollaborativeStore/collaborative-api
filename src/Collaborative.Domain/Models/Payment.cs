using System;

namespace Collaborative.Domain.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime? Paid { get; set; }
        public decimal Total { get; set; }
        public string Details { get; set; }

        public int FinancialAccountId { get; set; }
        public FinancialAccount FinancialAccount { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
