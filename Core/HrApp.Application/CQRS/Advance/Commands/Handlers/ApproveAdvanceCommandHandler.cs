using HrApp.Application.Interfaces;
using HrApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.Advance.Commands.Handlers
{
    public class ApproveAdvanceCommandHandler : IRequestHandler<ApproveAdvanceCommand, ServiceResponse<int>>
    {
        private readonly IUow _uow;

        public ApproveAdvanceCommandHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<ServiceResponse<int>> Handle(ApproveAdvanceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetAdvanceRepository().GetAsync(true, x => x.Id == request.Id);

            if (request.IsApproved)
            {
                entity.ApprovalDate = DateTime.Now;
                entity.ApprovalStatusId = 2;
            }

            entity.ApprovalStatusId = 3;

            await _uow.GetAdvanceRepository().UpdateAsync(entity);

            await _uow.CommitAsync();

            if (request.IsApproved)
            {
                return new ServiceResponse<int>(request.Id) { Message = $"The advance has been approved.", IsSuccess = true };
            }
            
            return new ServiceResponse<int>(request.Id) { Message = $"The advance has been denied.", IsSuccess = true };
        }
    }
}
