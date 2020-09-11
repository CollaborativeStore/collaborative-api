using Collaborative.Domain.Models;
using Collaborative.Domain.Interfaces.Repository;
using Collaborative.Infra.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Collaborative.Infra.Repository
{
    public class StockRepository : IStockRepository
    {
        private EntityContext _entityContext;

        public StockRepository(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            var stocks = _entityContext.Stocks
                .Include(x => x.Collaborative)
                .ToListAsync();

            return await stocks;
        }

        public async Task<Stock> GetByCollaborativeIdAsync(int id)
        {
            var stock = _entityContext.Stocks
                .Where(x => x.Collaborative.Id.Equals(id))
                .Include(x => x.Collaborative)
                .FirstOrDefaultAsync();

            return await stock;
        }

        public async Task<Stock> GetByIdAsync(int id)
        {
            var stock = _entityContext.Stocks
                .Where(x => x.Id.Equals(id))
                .Include(x => x.Collaborative)
                .FirstOrDefaultAsync();

            return await stock;
        }
    }
}
