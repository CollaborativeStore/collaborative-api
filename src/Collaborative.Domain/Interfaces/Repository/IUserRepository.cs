using System.Collections.Generic;
using System.Security.Claims;

namespace Collaborative.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        string Email { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
