using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collaborative.API.Services.Interfaces;
using Collaborative.API.ViewModels.Collaborative;
using Collaborative.API.ViewModels.Collaborator;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public ActionResult<CollaboratorViewModel> PostCollaborative([FromBody] CollaboratorInsertViewModel collaborator)
        {
            if (collaborator == null)
            {
                return NotFound();
            }

            return Created(nameof(GetById), _collaboratorService.Add(collaborator));
        }
    }
}
