﻿using System;
using System.Collections.Generic;

namespace Collaborative.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Ordered { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Total { get; set; }

        public int CollaborativeId { get; set; }
        public Collaborative Collaborative { get; set; }

        public List<Payment> Payments { get; set; }

        public List<OrderProduct> Products { get; set; }

    }
}
