using Collaborative.Domain.Models;
using Collaborative.Domain.Interfaces.Repository;
using Collaborative.Infra.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Collaborative.Infra.Repository
{
    public class FinancialAccountRepository : IFinancialAccountRepository
    {
        private EntityContext _entityContext;

        public FinancialAccountRepository(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        public async Task<IEnumerable<FinancialAccount>> GetAllAsync()
        {
            var accounts = _entityContext.FinancialAccounts
                .Where(x => x.Close.Equals(null))
                .ToListAsync();

            return await accounts;
        }

        public async Task<IEnumerable<FinancialAccount>> GetAllByCollaborativeIdAsync(int id)
        {
            var accounts = _entityContext.FinancialAccounts
                .Where(x => x.Close.Equals(null) && x.CollaborativeId.Equals(id))
                .ToListAsync();

            return await accounts;
        }

        public async Task<IEnumerable<FinancialAccount>> GetAllClosedAsync()
        {
            var accounts = _entityContext.FinancialAccounts
                .Where(x => x.Close != null)
                .ToListAsync();

            return await accounts;
        }

        public async Task<FinancialAccount> GetByIdAsync(int id)
        {
            var account = _entityContext.FinancialAccounts
                .Where(x => x.Close.Equals(null) && x.Id.Equals(id))
                .FirstOrDefaultAsync();

            return await account;
        }
    }
}
