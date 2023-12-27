using HrApp.Application.CQRS.Currency.Queries;
using HrApp.Application.CQRS.Expense.Commands;
using HrApp.Application.CQRS.Expense.Queries;
using HrApp.Application.CQRS.ExpenseType.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HrApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly IMediator mediator;

        public CommonController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet("Currency")]
        public async Task<IActionResult> GetCurrency()
        {
            var result = await mediator.Send(new ReadAllCurrencyQuery());
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
    }
}
