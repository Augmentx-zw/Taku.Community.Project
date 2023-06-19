using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taku.Community.Project.Domain.CommandHandlers.SubcribedCommunityProjectDetails;
using Taku.Community.Project.Domain.QueryHandlers.SubcribedCommunityProjectDetails;

namespace Taku.Community.Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcribedCommunityProjectController : ControllerBase
    {

        private readonly IMediator _mediator;

        public SubcribedCommunityProjectController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost("AddSubcribedCommunityProject")]
        public IActionResult Create([FromBody] AddSubcribedCommunityProjectCommand command)
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

        [HttpPost("UpdateSubcribedCommunityProject")]
        public IActionResult Update(UpDateSubcribedCommunityProjectCommand command)
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

        [HttpPost("DeleteSubcribedCommunityProject")]
        public IActionResult Delete(DeleteSubcribedCommunityProjectCommand command)
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

        [HttpGet("GetSubcribedCommunityProjects")]
        public async Task<IActionResult> SubcribedCommunityProjects(Guid userId)
        {
            var result = await _mediator.Send(new GetSubcribedCommunityProjectsByUserIdQuery { UserId = userId });
            return Ok(result);
        }

        [HttpGet("GetSubcribedCommunityProject")]
        public async Task<IActionResult> SubcribedCommunityProject(Guid SubcribedCommunityProjectId)
        {
            var result = await _mediator.Send(new GetSubcribedCommunityProjectByIdQuery { SubcribedCommunityProjectId = SubcribedCommunityProjectId });
            return Ok(result);
        }
    }
}
