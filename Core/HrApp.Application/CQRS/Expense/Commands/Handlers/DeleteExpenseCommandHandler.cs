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
        private readonly IUow _uow;

        public DeleteExpenseCommandHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<ServiceResponse<int>> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetExpenseRepository().GetAsync(true, x => x.Id == request.Id);

            await _uow.GetExpenseRepository().DeleteAsync(entity);

            await _uow.CommitAsync();

            var deletedEntity = await _uow.GetExpenseRepository().GetAsync(true, x => x.Id == request.Id);

            if(deletedEntity == null) 
            {
                return new ServiceResponse<int>(entity.Id) { Message = $"Deletion of expense {entity.Id} has been completed.", IsSuccess = true };
            }

            return new ServiceResponse<int>(request.Id) { Message = $"Deletion of expense {entity.Id} has not been completed.", IsSuccess = false };
        }
    }
}
