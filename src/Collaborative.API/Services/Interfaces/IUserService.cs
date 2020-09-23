using Collaborative.API.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Collaborative.API.Services.Interfaces
{
    public interface IUserService<T>
    {
        Task<bool> CreateUserAsync(T t);
        Task<bool> DeleteUserAsync(string name);
    }
}
