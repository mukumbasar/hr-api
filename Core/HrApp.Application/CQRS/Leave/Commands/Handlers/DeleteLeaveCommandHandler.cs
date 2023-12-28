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

namespace HrApp.Application.CQRS.Leave.Commands.Handlers
{
    internal class DeleteLeaveCommandHandler : IRequestHandler<DeleteLeaveCommand, ServiceResponse<int>>
    {
        private readonly IUow _uow;
        private readonly UserManager<HrApp.Domain.Entities.AppUser> _userManager;

        public DeleteLeaveCommandHandler(UserManager<HrApp.Domain.Entities.AppUser> userManager, IUow uow)
        {
            _uow = uow;
            _userManager = userManager;
        }

        public async Task<ServiceResponse<int>> Handle(DeleteLeaveCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetLeaveRepository().GetAsync(true, x => x.Id == request.Id);

            var leaveAmount = entity.EndDate - entity.StartDate;

            var user = await _userManager.FindByIdAsync(entity.AppUserId);

            await _uow.GetLeaveRepository().DeleteAsync(entity);

            user.YearlyLeaveDaysLeft += leaveAmount.Days;

            await _userManager.UpdateAsync(user);

            await _uow.CommitAsync();

            
            return new ServiceResponse<int>(request.Id) { Message = $"Deletion of advance {request.Id} has been completed.", IsSuccess = true };
            
        }
    }
}
