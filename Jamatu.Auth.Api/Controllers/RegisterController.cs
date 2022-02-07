using Jamatu.Auth.Api.Middleware;
using Jamatu.Auth.Application.Register.Command;
using Jamatu.Auth.Application.Register.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Jamatu.Auth.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RegisterController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        [HttpPost]
        [Route("createUser")]
        public async Task<IActionResult> Create([FromBody] RegisterCommand command)
        {
            var response = await _mediator.Send(command);

            if (response != null)
                return NoContent();

            return NotFound();
        }
        [Authorize]
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> Get([FromQuery] RegisterQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
