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
    public class UpdateLeaveCommandHandler : IRequestHandler<UpdateLeaveCommand, ServiceResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        private readonly UserManager<HrApp.Domain.Entities.AppUser> _userManager;

        public UpdateLeaveCommandHandler(UserManager<HrApp.Domain.Entities.AppUser> userManager, IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
            _userManager = userManager;
        }

        public async Task<ServiceResponse<int>> Handle(UpdateLeaveCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.AppUserId);

            var entity = _uow.GetLeaveRepository().GetAsync(true, x => x.Id == request.Id).Result;

            var oldLeaveAmount = entity.EndDate - entity.StartDate;

            entity = _mapper.Map<HrApp.Domain.Entities.Leave>(request);

            var newLeaveAmount = entity.EndDate - entity.StartDate;

            if (newLeaveAmount.Days > user.YearlyLeaveDaysLeft + oldLeaveAmount.Days)
            {
                return new ServiceResponse<int>(user.YearlyLeaveDaysLeft) { Message = $"The leave has not been updated: You only have {user.YearlyLeaveDaysLeft}", IsSuccess = false };
            }

            var leaveList = await _uow.GetLeaveRepository().GetAllAsync(true, x => x.AppUserId == request.AppUserId);

            foreach (var item in leaveList)
            {
                if (request.Id == item.Id)
                {
                    continue;
                }
                if (item.StartDate <= request.StartDate && item.EndDate >= request.StartDate)
                {
                    return new ServiceResponse<int>(0) { Message = $"Leave has not been updated: You already have a leave in this date range.Leave id = {item.Id}.", IsSuccess = false };
                }
                if (item.StartDate <= request.EndDate && item.EndDate >= request.EndDate)
                {
                    return new ServiceResponse<int>(0) { Message = $"Leave has not been updated: You already have a leave in this date range.Leave id = {item.Id}.", IsSuccess = false };
                }
            }

            await _uow.GetLeaveRepository().UpdateAsync(entity);

            await _uow.CommitAsync();

            user.YearlyLeaveDaysLeft += oldLeaveAmount.Days - newLeaveAmount.Days;

            await _userManager.UpdateAsync(user);

            return new ServiceResponse<int>(user.YearlyLeaveDaysLeft) { Message = $"The leave has been updated successfully: You have {user.YearlyLeaveDaysLeft} leave days left.", IsSuccess = true };
        }
    }
}
