using AutoMapper;
using Collaborative.API.Services.Interfaces;
using Collaborative.API.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Collaborative.API.Services
{
    public class UserService<T> : IUserService<T>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<bool> CreateUserAsync(T collab)
        {
            var model = _mapper.Map<UserViewModel>(collab);

            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                throw new Exception(result.ToString());
            }

            return true;
        }

        public async Task<bool> DeleteUserAsync(string name)
        {
            var user = await _userManager.FindByNameAsync(name);

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                throw new Exception(result.ToString());
            }

            return true;
        }

        public async Task<bool> UpdateUserAsync(string lastName)
        {
            var user = await _userManager.FindByNameAsync(lastName);

            if (user == null)
            {
                throw new Exception("User do not exists!");
            }

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                throw new Exception(result.ToString());
            }

            return true;
        }
    }
}
