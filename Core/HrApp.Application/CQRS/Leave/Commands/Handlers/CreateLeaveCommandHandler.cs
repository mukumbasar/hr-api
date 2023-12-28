using AutoMapper;
using HrApp.Application.CQRS.Advance.Commands;
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
    public class CreateLeaveCommandHandler : IRequestHandler<CreateLeaveCommand, ServiceResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        private readonly UserManager<HrApp.Domain.Entities.AppUser> _userManager;

        public CreateLeaveCommandHandler(UserManager<HrApp.Domain.Entities.AppUser> userManager, IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
            _userManager = userManager;
        }

        public async Task<ServiceResponse<int>> Handle(CreateLeaveCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.AppUserId);

            if(request.LeaveTypeId != 1)
            {

                var leave = await _uow.GetLeaveTypeRepository().GetAsync(true, x => x.Id == request.LeaveTypeId);
                int numofdays = leave.NumDays;

                request.EndDate = request.StartDate.AddDays(numofdays);
            }

            var leaveAmount = request.EndDate - request.StartDate; 

            if (user.YearlyLeaveDaysLeft < leaveAmount.Days)
            {
                return new ServiceResponse<int>(user.YearlyLeaveDaysLeft) { Message = $"Leave has not been added: You only have {user.YearlyLeaveDaysLeft} days left.", IsSuccess = false };
            }

            var entity = _mapper.Map<HrApp.Domain.Entities.Leave>(request);

            await _uow.GetLeaveRepository().AddAsync(entity);

            await _uow.CommitAsync();

            return new ServiceResponse<int>(entity.Id) { Message = "Leave has been added successfully", IsSuccess = true };
        }
    }
}
