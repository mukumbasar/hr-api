using HrApp.Application.CQRS.Expense.Commands;
using HrApp.Application.CQRS.Leave.Commands;
using HrApp.Application.CQRS.Leave.Queries;
using HrApp.Application.CQRS.LeaveType.Queries;
using HrApp.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HrApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeaveController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new ReadAllLeaveQuery());
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("Types")]
        public async Task<IActionResult> GetTypes()
        {
            var result = await _mediator.Send(new ReadAllLeaveTypeQuery());
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new ReadLeaveQuery(id));
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateLeaveCommand createLeaveCommand)
        {
            var result = await _mediator.Send(createLeaveCommand);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateLeaveCommand updateLeaveCommand)
        {
            var result = await _mediator.Send(updateLeaveCommand);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteLeaveCommand(id));
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("Approve")]
        public async Task<IActionResult> Approve(int id, bool isApproved)
        {
            var result = await _mediator.Send(new ApproveLeaveCommand() { Id = id, IsApproved = isApproved });
            if (result.IsSuccess) { return Ok(result); }
            return BadRequest(result);
        }
    }
}
