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
    public class ApproveExpenseCommandHandler : IRequestHandler<ApproveExpenseCommand, ServiceResponse<int>>
    {
        private readonly IUow _uow;

        public ApproveExpenseCommandHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<ServiceResponse<int>> Handle(ApproveExpenseCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetExpenseRepository().GetAsync(true, x => x.Id == request.Id);

            entity.ApprovalStatusId = 3;

            entity.ApprovalDate = DateTime.Now;

            if (request.IsApproved)
            {
                entity.ApprovalStatusId = 2;
            }


            await _uow.GetExpenseRepository().UpdateAsync(entity);

            await _uow.CommitAsync();

            if (request.IsApproved)
            {
                return new ServiceResponse<int>(request.Id) { Message = $"The expense has been approved.", IsSuccess = true };
            }

            return new ServiceResponse<int>(request.Id) { Message = $"The expense has been denied.", IsSuccess = true };
        }
    }
}
