using AutoMapper;
using HrApp.Application.CQRS.Advance.Commands;
using HrApp.Application.Helpers;
using HrApp.Application.Interfaces;
using HrApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.Expense.Commands.Handlers
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, ServiceResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IExpenseRepository _expenseRepository;

        public CreateExpenseCommandHandler(IMapper mapper, IExpenseRepository expenseRepository)
        {
            _mapper = mapper;
            _expenseRepository = expenseRepository;
        }

        public async Task<ServiceResponse<int>> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<HrApp.Domain.Entities.Expense>(request);

            entity.Document = await ImageConversions.ConvertToByteArrayAsync(request.File);

            await _expenseRepository.AddAsync(entity);

            return new ServiceResponse<int>(entity.Id) { Message = "Expense has been added successfully", Success = true };

        }
    }
}
