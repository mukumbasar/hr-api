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
      [HttpGet("AppUserHome/{Id}")]
      public async Task<IActionResult> GetHomeUser(string Id)
      {
         var result = await mediator.Send(new GetAppUserHomeById { Id = Id });
         return Ok(result);
      }
      [HttpGet("AppUserDetail/{Id}")]
      public async Task<IActionResult> GetDetailUser(string Id)
      {
         var result = await mediator.Send(new GetAppUserDetailsById { Id = Id });
         return Ok(result);
      }
      [HttpPut("UpdateAppUser")]
      public async Task<IActionResult> UpdateAppUser(UpdateAppUserCommand updateAppUserCommand)
      {
         var result = await mediator.Send(updateAppUserCommand);
         return Ok(result);
      }
   }
}
