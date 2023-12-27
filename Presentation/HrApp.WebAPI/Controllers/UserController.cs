using HrApp.Application;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetHomeUser(string Id)
        {
            var result = await mediator.Send(new GetAppUserHomeById { Id = Id });

            if (result.IsSuccess) return Ok(result.Data);

            return BadRequest(result.Message);
        }
        [HttpGet("details/{Id}")]
        public async Task<IActionResult> GetDetailUser(string Id)
        {
            var result = await mediator.Send(new GetAppUserDetailsById { Id = Id });

            if (result.IsSuccess) return Ok(result.Data);

            return BadRequest(result.Message);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAppUser(UpdateAppUserCommand updateAppUserCommand)
        {
            var result = await mediator.Send(updateAppUserCommand);

            if (result.IsSuccess) return Ok(result.Data);

            return BadRequest(result.Message);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand loginCommand)
        {
            var result = await mediator.Send(loginCommand);

            if (result.IsSuccess) return Ok(result.Token);

            return BadRequest(result.Message);
        }
    }
}
