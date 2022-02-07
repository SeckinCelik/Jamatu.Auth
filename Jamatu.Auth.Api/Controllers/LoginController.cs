using Jamatu.Auth.Api.Middleware;
using Jamatu.Auth.Application.Login.Command;
using Jamatu.Auth.Application.Logout.Command;
using Jamatu.Auth.Application.Validate.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Jamatu.Auth.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginCommand command)
        {

            return Ok(await _mediator.Send(command));
        }

        [HttpPost("validate-token")]
        public async Task<IActionResult> Validate([FromBody] ValidateCommand command)
        {

            return Ok(await _mediator.Send(command));
        }
        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromQuery] LogoutCommand loginCommand)
        {
            return Ok(await _mediator.Send(loginCommand));
        }
    }
}
