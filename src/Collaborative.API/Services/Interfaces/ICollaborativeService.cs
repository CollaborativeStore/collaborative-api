using Collaborative.API.ViewModels;
using Collaborative.API.ViewModels.Collaborative;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collaborative.API.Services.Interfaces
{
    public interface ICollaborativeService
    {
        Task<IEnumerable<CollaborativeViewModel>> GetAllAsync();
        Task<CollaborativeViewModel> GetByIdAsync(CollaborativeIdViewModel collaborativeIdViewModel);
        CollaborativeViewModel Add(CollaborativeInsertViewModel collaborativeInsertViewModel);
        void Update(int id, CollaborativeInsertViewModel collaborativeInsertViewModel);
        Task<CollaborativeViewModel> Remove(CollaborativeIdViewModel collaborativeIdViewModel);
        Task<CollaborativeViewModel> GetByCpfAsync(CollaborativeCpfViewModel collaborativeCpfViewModel);
        Task<CollaborativeViewModel> GetByCnpjAsync(CollaborativeCnpjViewModel collaborativeCnpjViewModel);
        Task<CollaborativeViewModel> GetByNameAsync(CollaborativeNameViewModel collaborativeNameViewModel);
        Task<CollaborativeViewModel> GetByMailAsync(CollaborativeMailViewModel collaborativeMailViewModel);
        Task<IEnumerable<CollaborativeViewModel>> GetAllClosedAsync();

    }
}
