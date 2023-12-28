using HrApp.Application.CQRS.Expense.Commands;
using HrApp.Application.CQRS.Expense.Queries;
using HrApp.Application.CQRS.ExpenseType.Queries;
using HrApp.Application.Wrappers;
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
            //todo düzeltilecek
            if (command.Amount <= 0) return BadRequest(new ServiceResponse<int>() { Data = default, IsSuccess = false, Message = "Amount must be greater than 0" });
            var result = await mediator.Send(command);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateExpenseCommand command)
        {
            //todo düzeltilecek
            if (command.Amount <= 0) return BadRequest(new ServiceResponse<int>() { Data = default, IsSuccess = false, Message = "Amount must be greater than 0" });
            var result = await mediator.Send(command);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await mediator.Send(new DeleteExpenseCommand(id));
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
    }
}
