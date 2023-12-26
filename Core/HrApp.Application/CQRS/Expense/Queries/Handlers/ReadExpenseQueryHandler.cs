using AutoMapper;
using HrApp.Application.CQRS.Advance.Queries;
using HrApp.Application.Dtos;
using HrApp.Application.Interfaces;
using HrApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.Expense.Queries.Handlers
{
    public class ReadExpenseQueryHandler : IRequestHandler<ReadExpenseQuery, ServiceResponse<ExpenseDto>>
    {

        private readonly IMapper _mapper;
        private readonly IExpenseRepository _expenseRepository;

        public ReadExpenseQueryHandler(IMapper mapper, IExpenseRepository expenseRepository)
        {
            _mapper = mapper;
            _expenseRepository = expenseRepository;
        }

        public async Task<ServiceResponse<ExpenseDto>> Handle(ReadExpenseQuery request, CancellationToken cancellationToken)
        {
            var entity = await _expenseRepository.GetAsync(true, x => x.Id == request.Id, x => x.Currency, x => x.ExpenseType, x => x.ApprovalStatus);

            if (entity != null)
            {
                var dto = _mapper.Map<ExpenseDto>(entity);

                dto.ApprovalStatus = entity.ApprovalStatus.Name;
                dto.Currency = entity.Currency.Name;
                dto.ExpenseTypeName = entity.ExpenseType.Name;

                return new ServiceResponse<ExpenseDto>(dto) { Success = true };
            }

            return new ServiceResponse<ExpenseDto>() { Message = "Expense acquirement error!", Success = false };
        }
    }
}
