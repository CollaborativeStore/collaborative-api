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
        Task<Collaborator> GetByName(string name);
        Task<Collaborator> GetByCpf(string cpf);
        Task<Collaborator> GetByCnpj(string cnpj);
        Task<Collaborator> GetByMail(string mail);
    }
}
