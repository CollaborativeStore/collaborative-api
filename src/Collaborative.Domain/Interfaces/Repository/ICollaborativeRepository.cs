using System.Collections.Generic;
using System.Threading.Tasks;
using Collab = Collaborative.Domain.Models.Collaborative;

namespace Collaborative.Domain.Interfaces.Repository
{
    public interface ICollaborativeRepository : IBaseRepository<Collab>
    {
        Task<IEnumerable<Collab>> GetAllAsync();
        Task<Collab> GetByIdAsync(int id);
        Task<IEnumerable<Collab>> GetAllClosed();
        Task<Collab> GetByCpf(string cpf);
        Task<Collab> GetByCnpj(string cnpj);
        Task<Collab> GetByName(string name);
        Task<Collab> GetByMail(string mail);
    }
}
