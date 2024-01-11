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

            entity.ApprovalStatusId = 3;

            entity.ApprovalDate = DateTime.Now;

            if (request.IsApproved)
            {
                entity.ApprovalStatusId = 2;
            }


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
