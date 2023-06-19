using MediatR;
using Microsoft.AspNetCore.Mvc;
using Taku.Community.Project.Domain.CommandHandlers.CardDetails;
using Taku.Community.Project.Domain.QueryHandlers.CardDetails;

namespace Taku.Community.Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CardController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost("AddCard")]
        public IActionResult Create([FromBody] AddCardCommand command)
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

        [HttpPost("UpdateCard")]
        public IActionResult Update(UpDateCardCommand command)
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

        [HttpPost("DeleteCard")]
        public IActionResult Delete(DeleteCardCommand command)
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

        [HttpGet("GetCards")]
        public async Task<IActionResult> Cards(Guid userId)
        {
            var result = await _mediator.Send(new GetCardsByUserIdQuery { UserId = userId });
            return Ok(result);
        }

        [HttpGet("GetCard")]
        public async Task<IActionResult> Card(Guid cardId)
        {
            var result = await _mediator.Send(new GetCardByIdQuery { CardId = cardId });
            return Ok(result);
        }

    }
}
