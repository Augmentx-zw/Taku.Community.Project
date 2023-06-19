using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taku.Community.Project.Domain.CommandHandlers.CommunityProjectDetails;
using Taku.Community.Project.Domain.QueryHandlers.CommunityProjectDetails;

namespace Taku.Community.Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityProjectController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CommunityProjectController(IMediator mediator)
        {
            _mediator = mediator;

        }
        
        [HttpPost("AddCommunityProject")]
        public IActionResult Create([FromBody] AddCommunityProjectCommand command)
        {
            try
            {
                _mediator.Send(command);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = true, ex.Message });
            }
        }

        [HttpPost("UpdateCommunityProject")]
        public IActionResult Update(UpDateCommunityProjectCommand command)
        {
            try
            {
                _mediator.Send(command);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return Ok(new { Error = true, ex.Message });
            }
        }

        [HttpPost("DeleteCommunityProject")]
        public IActionResult Delete(DeleteCommunityProjectCommand command)
        {
            try
            {
                _mediator.Send(command);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return Ok(new { Error = true, ex.Message });
            }
        }

        [HttpGet("GetCommunityProjects")]
        public async Task<IActionResult> CommunityProjects()
        {
            var result = await _mediator.Send(new GetCommunityProjectsQuery { });
            return Ok(result);
        }

        [HttpGet("GetCommunityProject")]
        public async Task<IActionResult> CommunityProject(Guid projectId)
        {
            var result = await _mediator.Send(new GetCommunityProjectByIdQuery { ProjectId = projectId });
            return Ok(result);
        }

    }
}
