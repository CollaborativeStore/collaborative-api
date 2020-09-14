using Collaborative.API.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collaborative.API.Services.Interfaces
{
    public interface ICollaborativeService
    {
        Task<IEnumerable<CollaborativeViewModel>> GetAllAsync();
        Task<CollaborativeViewModel> GetByIdAsync(int id);
        CollaborativeViewModel Add(CollaborativeViewModel collaborativeViewModel);
        void Update(CollaborativeViewModel collaborativeViewModel);
        void remove(CollaborativeViewModel collaborativeViewModel);
    }
}
