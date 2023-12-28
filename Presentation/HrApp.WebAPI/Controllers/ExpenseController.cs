using HrApp.Application.CQRS.Expense.Commands;
using HrApp.Application.CQRS.Expense.Queries;
using HrApp.Application.CQRS.ExpenseType.Queries;
using HrApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<Expense> _logger;

        public ExpenseController(IMediator mediator, ILogger<Expense> logger)
        {
            this.mediator = mediator;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await mediator.Send(new ReadAllExpenseQuery());
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("Types")]
        public async Task<IActionResult> GetTypes()
        {
            var result = await mediator.Send(new ReadAllExpenseTypeQuery());
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await mediator.Send(new ReadExpenseQuery(id));
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateExpenseCommand command)
        {
            var result = await mediator.Send(command);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateExpenseCommand command)
        {
            var result = await mediator.Send(command);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteExpenseCommand command)
        {
            var result = await mediator.Send(command);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
    }
}
