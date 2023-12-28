 using HrApp.Application.CQRS.Advance.Commands;
using HrApp.Application.CQRS.Advance.Queries;
using HrApp.Application.CQRS.AdvanceType.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HrApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvanceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdvanceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new ReadAllAdvanceQuery());
            if(result.IsSuccess) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpGet("Id")]
        public async Task<IActionResult> Get(int id)
        {
            var result= await _mediator.Send(new ReadAdvanceQuery(id));
            if(result.IsSuccess) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpGet("Types")]
        public async Task<IActionResult> GetType()
        {
            var result= await _mediator.Send(new ReadAllAdvanceTypeQuery());
            if (result.IsSuccess) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateAdvanceCommand createAdvanceCommand) 
        {
            var result = await _mediator.Send(createAdvanceCommand);
            if(result.IsSuccess) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAdvanceCommand updateAdvanceCommand)
        {
            var result= await _mediator.Send(updateAdvanceCommand);
            if(result.IsSuccess) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteAdvanceCommand deleteAdvanceCommand)
        {
            var result = await _mediator.Send(deleteAdvanceCommand);
            if(result.IsSuccess) { return Ok(result); }
            return BadRequest(result);
        }

    }
}
