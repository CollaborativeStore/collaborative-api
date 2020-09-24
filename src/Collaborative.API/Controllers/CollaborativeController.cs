using System.Collections.Generic;
using System.Threading.Tasks;
using Collaborative.API.Services.Interfaces;
using Collaborative.API.ViewModels.Collaborative;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Collaborative.API.Controllers
{
    [Route("api/v1/collaborative")]
    [ApiController]
    [Authorize]
    public class CollaborativeController : ControllerBase
    {
        private readonly ICollaborativeService _collaborativeService;
        private readonly IUserService<CollaborativeInsertViewModel> _userService;

        public CollaborativeController(ICollaborativeService collaborativeService, IUserService<CollaborativeInsertViewModel> userService)
        {
            _collaborativeService = collaborativeService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollaborativeViewModel>>> GetAll()
        {
            return Ok(await _collaborativeService.GetAllAsync());
        }

        [HttpGet("closed")]
        public async Task<ActionResult<IEnumerable<CollaborativeViewModel>>> GetAllClosed()
        {
            return Ok(await _collaborativeService.GetAllClosedAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CollaborativeViewModel>> GetById([FromQuery] CollaborativeIdViewModel collaborativeIdViewModel)
        {
            var collabVM = await _collaborativeService.GetByIdAsync(collaborativeIdViewModel);

            if (collabVM == null)
            {
                return NotFound();
            }

            return Ok(collabVM);
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<ActionResult<CollaborativeViewModel>> GetByCpf([FromQuery] CollaborativeCpfViewModel collaborativeCpfViewModel)
        {
            var collabVM = await _collaborativeService.GetByCpfAsync(collaborativeCpfViewModel);

            if (collabVM == null)
            {
                return NotFound();
            }

            return Ok(collabVM);
        }

        [HttpGet("cnpj/{cnpj}")]
        public async Task<ActionResult<CollaborativeViewModel>> GetByCNPJ([FromQuery] CollaborativeCnpjViewModel collaborativeCnpjViewModel)
        {
            var collabVM = await _collaborativeService.GetByCnpjAsync(collaborativeCnpjViewModel);

            if (collabVM == null)
            {
                return NotFound();
            }

            return Ok(collabVM);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<CollaborativeViewModel>> GetByName([FromQuery] CollaborativeNameViewModel collaborativeNameViewModel)
        {
            var collabVM = await _collaborativeService.GetByNameAsync(collaborativeNameViewModel);

            if (collabVM == null)
            {
                return NotFound();
            }

            return Ok(collabVM);
        }

        [HttpGet("mail/{mail}")]
        public async Task<ActionResult<CollaborativeViewModel>> GetByMail([FromQuery] CollaborativeMailViewModel collaborativeMailViewModel)
        {
            var collabVM = await _collaborativeService.GetByMailAsync(collaborativeMailViewModel);

            if (collabVM == null)
            {
                return NotFound();
            }

            return Ok(collabVM);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<CollaborativeViewModel>> PostCollaborative([FromBody] CollaborativeInsertViewModel collaborative)
        {
            if (collaborative == null)
            {
                return NotFound();
            }

            var result = await _userService.CreateUserAsync(collaborative);

            if (!result == true)
            {
                return BadRequest();
            }

            var created = Created(nameof(GetById), _collaborativeService.Add(collaborative));

            if (created.Value == null)
            {
                await _userService.DeleteUserAsync(collaborative.Email);

                return BadRequest();
            }

            return created;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutCollaborative(int id, [FromBody] CollaborativeInsertViewModel collaborative)
        {
            var collab = await _collaborativeService.GetByIdAsync(new CollaborativeIdViewModel(id));

            if (collab == null)
            {
                return NotFound();
            }

            var updateModel = _collaborativeService.Update(id, collaborative);

            if (!updateModel == true)
            {
                return BadRequest();
            }

            var deleteUser = await _userService.DeleteUserAsync(collab.Email);

            if (!deleteUser == true)
            {
                return BadRequest();
            }

            var updateUser = await _userService.CreateUserAsync(collaborative);

            if (!updateUser == true)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCollaborative([FromQuery] CollaborativeIdViewModel collaborative)
        {
            var model = await _collaborativeService.GetByIdAsync(collaborative);

            if (model == null)
            {
                return NotFound();
            }

            var result = await _collaborativeService.Remove(collaborative);

            if (result == null)
            {
                return NotFound();
            }

            var deleteUser = await _userService.DeleteUserAsync(model.Email);

            if (!deleteUser == true)
            {
                return BadRequest();
            }

            return NoContent();

        }
    }
}
 