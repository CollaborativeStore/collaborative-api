using Collaborative.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collaborative.Domain.Interfaces.Repository
{
    public interface IFinancialAccountRepository
    {
        Task<IEnumerable<FinancialAccount>> GetAllAsync();
        Task<IEnumerable<FinancialAccount>> GetAllClosedAsync();
        Task<FinancialAccount> GetByIdAsync(int id);
        Task<IEnumerable<FinancialAccount>> GetAllByCollaborativeIdAsync(int id);
    }
}
