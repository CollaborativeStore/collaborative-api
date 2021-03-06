﻿using System.Collections.Generic;

namespace Collaborative.Domain.Models
{
    public class Stock
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CollaborativeId { get; set; }
        public Collaborative Collaborative { get; set; }
         
        public List<Product> Products { get; set; }
    }
}
