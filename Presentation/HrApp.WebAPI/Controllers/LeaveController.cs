using HrApp.Application.CQRS.Leave.Commands;
using HrApp.Application.CQRS.Leave.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HrApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController :ControllerBase
    {
        private readonly IMediator _mediator;
        public LeaveController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result= await _mediator.Send(new ReadAllLeaveQuery());
            if (result.Success) 
            { return Ok(result.Value); }
            return BadRequest(result.Message);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result= await _mediator.Send(new ReadLeaveQuery(id));
            if(result.Success) 
            { return Ok(result.Value); }
            return BadRequest(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateLeaveCommand createLeaveCommand)
        {
            var result= await _mediator.Send(createLeaveCommand);
            if (result.Success) 
            { return Ok(result.Value); }
            return BadRequest(result.Message);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateLeaveCommand updateLeaveCommand)
        {
            var result= await _mediator.Send(updateLeaveCommand);
            if (result.Success) 
            { return Ok(result.Value); }
            return BadRequest(result.Message);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteLeaveCommand deleteLeaveCommand)
        {
            var result = await _mediator.Send(deleteLeaveCommand);
            if (result.Success)
            { return Ok(result.Value); }
            return BadRequest(result.Message);
        }
    }
}
