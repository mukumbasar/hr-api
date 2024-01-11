using HrApp.Application.Interfaces;
using HrApp.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<Domain.Entities.AppUser> userManager;

        public ApproveAdvanceCommandHandler(IUow uow, UserManager<HrApp.Domain.Entities.AppUser> userManager)
        {
            _uow = uow;
            this.userManager = userManager;
        }

        public async Task<ServiceResponse<int>> Handle(ApproveAdvanceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetAdvanceRepository().GetAsync(true, x => x.Id == request.Id);

            entity.ApprovalStatusId = 3;

            entity.ApprovalDate = DateTime.Now;

            if (request.IsApproved)
            {
                entity.ApprovalStatusId = 2;
            }
            else
            {
                var temp = userManager.FindByIdAsync(entity.AppUserId.ToString()).Result;
                temp.YearlyAdvanceAmountLeft += entity.Amount;
                await userManager.UpdateAsync(temp);
            }


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
