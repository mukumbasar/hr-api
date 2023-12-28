using AutoMapper;
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
    public class DeleteAdvanceCommandHandler : IRequestHandler<DeleteAdvanceCommand, ServiceResponse<decimal>>
    {
        private readonly IUow _uow;
        private readonly UserManager<Domain.Entities.AppUser> _userManager;

        public DeleteAdvanceCommandHandler(IUow uow, UserManager<Domain.Entities.AppUser> userManager)
        {
            _uow = uow;
            _userManager = userManager;
        }
        public async Task<ServiceResponse<decimal>> Handle(DeleteAdvanceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetAdvanceRepository().GetAsync(true, x => x.Id == request.Id);

            var advanceAmount = entity.Amount;
            var user = await _userManager.FindByIdAsync(entity.AppUserId);

            await _uow.GetAdvanceRepository().DeleteAsync(entity);

            user.YearlyAdvanceAmountLeft += advanceAmount;
            await _userManager.UpdateAsync(user);

            await _uow.CommitAsync();

            var deletedEntity = await _uow.GetAdvanceRepository().GetAsync(true, x => x.Id == request.Id);

            if(deletedEntity == null) 
            {
                return new ServiceResponse<decimal>(user.YearlyAdvanceAmountLeft) { Message = $"Deletion of advance {request.Id} has been completed. Current amount: {user.YearlyAdvanceAmountLeft}", IsSuccess = true };
            }

            return new ServiceResponse<decimal>(user.YearlyAdvanceAmountLeft) { Message = $"Deletion of advance {request.Id} has not been completed. Current amount: {user.YearlyAdvanceAmountLeft}", IsSuccess = false };
        }
    }
}
