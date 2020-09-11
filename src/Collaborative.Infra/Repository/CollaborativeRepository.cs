using Collaborative.Domain.Interfaces.Repository;
using Collaborative.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collab = Collaborative.Domain.Models.Collaborative;

namespace Collaborative.Infra.Repository
{
    public class CollaborativeRepository : ICollaborativeRepository
    {
        private EntityContext _entityContext;

        public CollaborativeRepository(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        public async Task<IEnumerable<Collab>> GetAllAsync()
        {
            var collabs = _entityContext.Collaboratives
                .Where(x => x.ClosingDate.Equals(null))
                .ToListAsync();

            return await collabs;
               
        }

        public async Task<IEnumerable<Collab>> GetAllClosed()
        {
            var collabs = _entityContext.Collaboratives
                .Where(x => x.ClosingDate != null)
                .ToListAsync();

            return await collabs;
        }

        public async Task<Collab> GetByIdAsync(int id)
        {
            var collab = _entityContext.Collaboratives
                .Where(x => x.Id.Equals(id) && x.ClosingDate.Equals(null))
                .FirstOrDefaultAsync();

            return await collab;
        }
    }
}
