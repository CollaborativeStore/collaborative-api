using Collaborative.Domain.Models;
using Collaborative.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collaborative.Infra.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Collaborative.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private EntityContext _entityContext;

        public ProductRepository(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = _entityContext.Products
                .Where(x => x.DeletionDate.Equals(null))
                .Include(x => x.Collaborator)
                .ToListAsync();

            return await products;
        }

        public async Task<IEnumerable<Product>> GetAllByCollaboratorIdAsync(int id)
        {
            var products = _entityContext.Products
                .Where(x => x.DeletionDate.Equals(null) && x.CollaboratorId.Equals(id))
                .Include(x => x.Collaborator)
                .ToListAsync();

            return await products;
        }

        public async Task<IEnumerable<Product>> GetAllDeletedAsync()
        {
            var products = _entityContext.Products
                .Where(x => x.DeletionDate != null)
                .Include(x => x.Collaborator)
                .ToListAsync();

            return await products;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = _entityContext.Products
                .Where(x => x.DeletionDate.Equals(null) && x.Id.Equals(id))
                .Include(x => x.Collaborator)
                .FirstOrDefaultAsync();

            return await product;
        }

        public async Task<Product> GetByNameAsync(string name)
        {
            var product = _entityContext.Products
                .Where(x => x.DeletionDate.Equals(null) && x.Name.Equals(name))
                .Include(x => x.Collaborator)
                .FirstOrDefaultAsync();

            return await product;
        }
    }
}
