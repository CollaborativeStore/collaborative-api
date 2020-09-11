using Collaborative.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collaborative.Domain.Interfaces.Repository
{
    public interface ICollaboratorRepository
    {
        Task<IEnumerable<Collaborator>> GetAllAsync();
        Task<IEnumerable<Collaborator>> GetAllClosed();
        Task<Collaborator> GetByIdAsync(int id);
        Task<IEnumerable<Collaborator>> GetAllByCollaborativeIdAsync(int id);
    }
}
