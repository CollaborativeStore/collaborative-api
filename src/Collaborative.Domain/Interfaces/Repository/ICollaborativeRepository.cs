using System.Collections.Generic;
using System.Threading.Tasks;
using Collab = Collaborative.Domain.Models.Collaborative;

namespace Collaborative.Domain.Interfaces.Repository
{
    public interface ICollaborativeRepository
    {
        Task<IEnumerable<Collab>> GetAllAsync();
        Task<Collab> GetByIdAsync(int id);
    }
}
