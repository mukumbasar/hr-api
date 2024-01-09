using HrApp.Application.CQRS.Advance.Commands;
using HrApp.Application.CQRS.Advance.Queries;
using HrApp.Application.CQRS.AdvanceType.Queries;
using HrApp.Application.CQRS.Company.Commands;
using HrApp.Application.CQRS.Company.Queries;
using HrApp.Application.CQRS.CompanyType.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HrApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new ReadAllCompanyQuery());
            if (result.IsSuccess) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpGet("Types")]
        public async Task<IActionResult> GetTypes()
        {
            var result = await _mediator.Send(new ReadAllCompanyTypeQuery());
            if (result.IsSuccess) { return Ok(result); }
            return BadRequest(result);
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddCompanyCommand addCompanyCommand)
        {
            var result = await _mediator.Send(addCompanyCommand);
            if (result.IsSuccess) { return Ok(result); }
            return BadRequest(result);
        }
    }
}
