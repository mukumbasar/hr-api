using HrApp.Application.CQRS.Advance.Commands;
using HrApp.Application.Interfaces;
using HrApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.Leave.Commands.Handlers
{
    public class ApproveLeaveCommandHandler : IRequestHandler<ApproveLeaveCommand, ServiceResponse<int>>
    {
        private readonly IUow _uow;

        public ApproveLeaveCommandHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<ServiceResponse<int>> Handle(ApproveLeaveCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetLeaveRepository().GetAsync(true, x => x.Id == request.Id);

            if (request.IsApproved)
            {
                entity.ApprovalDate = DateTime.Now;
                entity.ApprovalStatusId = 2;
            }

            entity.ApprovalStatusId = 3;

            await _uow.GetLeaveRepository().UpdateAsync(entity);

            await _uow.CommitAsync();

            if (request.IsApproved)
            {
                return new ServiceResponse<int>(request.Id) { Message = $"The leave has been approved.", IsSuccess = true };
            }

            return new ServiceResponse<int>(request.Id) { Message = $"The leave has been denied.", IsSuccess = true };
        }
    }
}
