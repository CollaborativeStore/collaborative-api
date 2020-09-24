using Collaborative.API.ViewModels.User;
using System.Threading.Tasks;

namespace Collaborative.API.Services.Interfaces
{
    public interface ISessionService
    {
        Task<SessionResponseViewModel> Authenticate(SessionRequestViewModel user);
    }
}
