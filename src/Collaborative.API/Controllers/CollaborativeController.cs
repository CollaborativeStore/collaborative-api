using System.Collections.Generic;
using System.Threading.Tasks;
using Collaborative.API.Services.Interfaces;
using Collaborative.API.ViewModels.Collaborative;
using Microsoft.AspNetCore.Mvc;

namespace Collaborative.API.Controllers
{
    [Route("api/v1/collaborative")]
    [ApiController]
    public class CollaborativeController : ControllerBase
    {
        private readonly ICollaborativeService _collaborativeService;

        public CollaborativeController(ICollaborativeService collaborativeService)
        {
            _collaborativeService = collaborativeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollaborativeViewModel>>> GetAll()
        {
            return Ok(await _collaborativeService.GetAllAsync());
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

        [HttpPost]
        public ActionResult<CollaborativeViewModel> PostCollaborative([FromBody] CollaborativeViewModel collaborative)
        {
            if (collaborative == null)
            {
                return NotFound();
            }

            return Created(nameof(GetById), _collaborativeService.Add(collaborative));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutCollaborative(int id, [FromBody] CollaborativeViewModel collaborative)
        {
            if (collaborative == null || collaborative.Id != id)
            {
                return BadRequest();
            }

            var collab = await _collaborativeService.GetByIdAsync(new CollaborativeIdViewModel(id));

            if (collab == null)
            {
                return NotFound();
            }

            _collaborativeService.Update(collaborative);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromQuery] CollaborativeIdViewModel collaborative)
        {

            var result = await _collaborativeService.Remove(collaborative);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}
