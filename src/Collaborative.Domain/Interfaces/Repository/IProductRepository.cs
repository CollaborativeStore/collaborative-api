using Collaborative.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collaborative.Domain.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetAllDeletedAsync();
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllByCollaboratorIdAsync(int id);
    }
}
