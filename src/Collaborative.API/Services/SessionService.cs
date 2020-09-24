using Collaborative.API.Services.Interfaces;
using Collaborative.API.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace Collaborative.API.Services
{
    public class SessionService : ISessionService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;

        public SessionService(UserManager<IdentityUser> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }

        public async Task<SessionResponseViewModel> Authenticate(SessionRequestViewModel user)
        {
            var data = await _userManager.FindByEmailAsync(user.Email);

            if (data == null)
            {
                throw new Exception("Invalid e-mail/password combination");
            }

            var valid = _userManager.PasswordHasher.VerifyHashedPassword(data, data.PasswordHash, user.Password);

            if (valid != PasswordVerificationResult.Success)
            {
                throw new Exception("Invalid e-mail/password combination");
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_config["JWTSecret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
              )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new SessionResponseViewModel(user.Email, tokenHandler.WriteToken(token));
        }

    }
}
