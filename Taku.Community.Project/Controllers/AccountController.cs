using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taku.Community.Project.Domain.CommandHandlers.AccountDetails;
using Taku.Community.Project.Domain.QueryHandlers.AccountDetails;

namespace Taku.Community.Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost("AddAccount")]
        public IActionResult Create([FromBody] AddAccountCommand command)
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

        [HttpPost("UpdateAccount")]
        public IActionResult Update(UpDateAccountCommand command)
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

        [HttpPost("DeleteAccount")]
        public IActionResult Delete(DeleteAccountCommand command)
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

        [HttpGet("GetAccounts")]
        public async Task<IActionResult> Accounts(Guid userId)
        {
            var result = await _mediator.Send(new GetAccountsByUserIdQuery { UserId = userId });
            return Ok(result);
        }

        [HttpGet("GetAccount")]
        public async Task<IActionResult> Account(Guid AccountId)
        {
            var result = await _mediator.Send(new GetAccountByIdQuery { AccountId = AccountId });
            return Ok(result);
        }

    }
}
