using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collaborative.API.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnityPrice { get; set; }
        public int Quantity { get; set; }
    }
}
