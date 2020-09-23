using System.Threading.Tasks;

namespace Collaborative.API.Services.Interfaces
{
    public interface IUserService<T>
    {
        Task<bool> CreateUserAsync(T t);
        Task<bool> DeleteUserAsync(string name);
        Task<bool> UpdateUserAsync(string name);
    }
}
