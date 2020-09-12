using Collaborative.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collaborative.Domain.Interfaces.Repository
{
    public interface IOrderProductRepository
    {
        Task<IEnumerable<OrderProduct>> GetAllAsync();
        Task<OrderProduct> GetByIdAsync(int id);
    }
}
