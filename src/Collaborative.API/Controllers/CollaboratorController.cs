using System.Collections.Generic;
using System.Threading.Tasks;
using Collaborative.API.Services.Interfaces;
using Collaborative.API.ViewModels.Collaborative;
using Collaborative.API.ViewModels.Collaborator;
using Microsoft.AspNetCore.Mvc;

namespace Collaborative.API.Controllers
{
    [Route("v1/collaborator")]
    [ApiController]
    public class CollaboratorController : ControllerBase
    {
        private readonly ICollaboratorService _collaboratorService;

        public CollaboratorController(ICollaboratorService collaboratorService)
        {
            _collaboratorService = collaboratorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollaboratorViewModel>>> GetAll()
        {
            return Ok(await _collaboratorService.GetAllAsync());
        }

        [HttpGet("collaboratives/{id}")]
        public async Task<ActionResult<IEnumerable<CollaboratorViewModel>>> GetAllByCollaborativeId([FromQuery] CollaborativeIdViewModel collaborativeIdViewModel)
        {
            var vm = await _collaboratorService.GetAllByCollaborativeIdAsync(collaborativeIdViewModel);

            if (vm == null)
            {
                return NotFound();
            }

            return Ok(vm);
        }

        [HttpGet("closed")]
        public async Task<ActionResult<IEnumerable<CollaboratorViewModel>>> GetAllClosed()
        {
            return Ok(await _collaboratorService.GetAllClosedAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CollaboratorViewModel>> GetById([FromQuery] CollaboratorIdViewModel collaborator)
        {
            var vm = await _collaboratorService.GetByIdAsync(collaborator);

            if (vm == null)
            {
                return NotFound();
            }

            return Ok(vm);
        }

        [HttpGet("cnpj/{cnpj}")]
        public async Task<ActionResult<CollaboratorViewModel>> GetByCnpj([FromQuery] CollaboratorCnpjViewModel collaborator)
        {
            var vm = await _collaboratorService.GetByCnpjAsync(collaborator);

            if (vm == null)
            {
                return NotFound();
            }

            return Ok(vm);
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<ActionResult<CollaboratorViewModel>> GetByCpf([FromQuery] CollaboratorCpfViewModel collaborator)
        {
            var vm = await _collaboratorService.GetByCpfAsync(collaborator);

            if (vm == null)
            {
                return NotFound();
            }

            return Ok(vm);
        }

        [HttpGet("mail/{mail}")]
        public async Task<ActionResult<CollaboratorViewModel>> GetByMail([FromQuery] CollaboratorMailViewModel collaborator)
        {
            var vm = await _collaboratorService.GetByMailAsync(collaborator);

            if (vm == null)
            {
                return NotFound();
            }

            return Ok(vm);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<CollaboratorViewModel>> GetByName([FromQuery] CollaboratorNameViewModel collaborator)
        {
            var vm = await _collaboratorService.GetByNameAsync(collaborator);

            if (vm == null)
            {
                return NotFound();
            }

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<CollaboratorViewModel>> PostCollaborator([FromBody] CollaboratorInsertViewModel collaborator)
        {
            if (collaborator == null)
            {
                return NotFound();
            }

            return Created(nameof(GetById), await _collaboratorService.Add(collaborator));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCollaborator(int id,[FromBody] CollaboratorInsertViewModel collaborator)
        {
            var collab = await _collaboratorService.GetByIdAsync(new CollaboratorIdViewModel(id));

            if (collab == null)
            {
                return NotFound();
            }

            _collaboratorService.Update(id, collaborator);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCollaborator([FromQuery] CollaboratorIdViewModel collaborator)
        {
            var model = await _collaboratorService.Remove(collaborator);

            if (model == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
