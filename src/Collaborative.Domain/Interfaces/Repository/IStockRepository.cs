using Collaborative.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collaborative.Domain.Interfaces.Repository
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetAllAsync();
        Task<Stock> GetByIdAsync(int id);
        Task<Stock> GetByProductIdAsync(int id);
    }
}
