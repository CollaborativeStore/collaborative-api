using Collaborative.API.ViewModels.Collaborative;
using Collaborative.API.ViewModels.Collaborator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collaborative.API.Services.Interfaces
{
    public interface ICollaboratorService
    {
        Task<IEnumerable<CollaboratorViewModel>> GetAllAsync();
        Task<IEnumerable<CollaboratorViewModel>> GetAllByCollaborativeIdAsync(CollaborativeIdViewModel collaborativeIdViewModel);
        Task<IEnumerable<CollaboratorViewModel>> GetAllClosedAsync();
        Task<CollaboratorViewModel> GetByIdAsync(CollaboratorIdViewModel collaboratorIdViewModel);
        Task<CollaboratorViewModel> GetByCnpjAsync(CollaboratorCnpjViewModel collaboratorCnpjViewModel);
        Task<CollaboratorViewModel> GetByCpfAsync(CollaboratorCpfViewModel collaboratorCpfViewModel);
        Task<CollaboratorViewModel> GetByMailAsync(CollaboratorMailViewModel collaboratorMailViewModel);
        Task<CollaboratorViewModel> GetByNameAsync(CollaboratorNameViewModel collaboratorNameViewModel);

        CollaboratorViewModel Add(CollaboratorInsertViewModel collaboratorInsertViewModel);
        Task<CollaboratorViewModel> Remove(CollaboratorIdViewModel collaboratorIdViewModel);
        void Update(int id, CollaboratorInsertViewModel collaboratorInsertViewModel);
    }
}
