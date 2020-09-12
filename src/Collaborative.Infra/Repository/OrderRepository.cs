using Collaborative.Domain.Models;
using Collaborative.Domain.Interfaces.Repository;
using Collaborative.Infra.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Collaborative.Infra.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private EntityContext _entityContext;

        public OrderRepository(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var orders = _entityContext.Orders
                .Where(x => x.Status.Equals(0))
                .Include(x => x.Collaborative.Name)
                .Include(x => x.Payments)
                .Include(x => x.Products)
                .ToListAsync();

            return await orders;
        }

        public async Task<IEnumerable<Order>> GetAllByClosedStatus()
        {
            var orders = _entityContext.Orders
                .Where(x => x.Status.Equals(1))
                .Include(x => x.Collaborative.Name)
                .Include(x => x.Payments)
                .Include(x => x.Products)
                .ToListAsync();

            return await orders;
        }

        public async Task<IEnumerable<Order>> GetAllByCollaborativeIdAsync(int id)
        {
            var orders = _entityContext.Orders
                .Where(x => x.Status.Equals(0) && x.CollaborativeId.Equals(id))
                .Include(x => x.Collaborative.Name)
                .Include(x => x.Payments)
                .Include(x => x.Products)
                .ToListAsync();

            return await orders;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var order = _entityContext.Orders
                .Where(x => x.Status.Equals(0) && x.Id.Equals(id))
                .Include(x => x.Collaborative.Name)
                .Include(x => x.Payments)
                .Include(x => x.Products)
                .FirstOrDefaultAsync();

            return await order;
        }
    }
}
