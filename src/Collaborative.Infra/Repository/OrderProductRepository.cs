using Collaborative.Domain.Models;
using Collaborative.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Collaborative.Infra.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Collaborative.Infra.Repository
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private EntityContext _entityContext;

        public OrderProductRepository(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        public async Task<IEnumerable<OrderProduct>> GetAllAsync()
        {
            var orderProducts = await _entityContext
                .orderProducts
                .ToListAsync();

            return orderProducts;
        }

        public async Task<OrderProduct> GetByIdAsync(int id)
        {
            var orderProduct = await _entityContext
                .orderProducts
                .Where(x => x.Id.Equals(id))
                .FirstOrDefaultAsync();

            return orderProduct;
        }
    }
}
