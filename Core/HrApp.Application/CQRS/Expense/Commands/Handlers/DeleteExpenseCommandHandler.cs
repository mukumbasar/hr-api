using AutoMapper;
using HrApp.Application.CQRS.Advance.Commands;
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
    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand, ServiceResponse<int>>
    {
        private readonly IExpenseRepository _expenseRepository;

        public DeleteExpenseCommandHandler(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<ServiceResponse<int>> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            var entity = await _expenseRepository.GetAsync(true, x => x.Id == request.Id);

            await _expenseRepository.DeleteAsync(entity);

            return new ServiceResponse<int>(entity.Id) { Message = "Deletion has been completed successfully", Success = true };
        }
    }
}
