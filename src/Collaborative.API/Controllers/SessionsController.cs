using System.Threading.Tasks;
using Collaborative.API.Services.Interfaces;
using Collaborative.API.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Collaborative.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionService _user;

        public SessionsController(ISessionService user)
        {
            _user = user;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<SessionResponseViewModel>> logIn([FromBody] SessionRequestViewModel user)
        {
            var session = await _user.Authenticate(user);

            return Ok(session);
        }
    }
}
