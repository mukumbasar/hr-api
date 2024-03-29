﻿using AutoMapper;
using FluentValidation;
using HrApp.Application.CQRS.Advance.Commands;
using HrApp.Application.Interfaces;
using HrApp.Application.Validators;
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
        private readonly IValidator<CreateLeaveCommand> validator;
        private readonly UserManager<HrApp.Domain.Entities.AppUser> _userManager;

        public CreateLeaveCommandHandler(UserManager<HrApp.Domain.Entities.AppUser> userManager, IMapper mapper, IUow uow, CreateLeaveValidator validator)
        {
            _mapper = mapper;
            _uow = uow;
            this.validator = validator;
            _userManager = userManager;
        }

        public async Task<ServiceResponse<int>> Handle(CreateLeaveCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return new ServiceResponse<int>(0) { Message = string.Join(" ", validationResult.Errors), IsSuccess = false };
            }
            var user = await _userManager.FindByIdAsync(request.AppUserId);
            if (request.LeaveTypeId != 1)
            {

                var leave = await _uow.GetLeaveTypeRepository().GetAsync(true, x => x.Id == request.LeaveTypeId);

                int numofdays = leave.NumDays;

                request.EndDate = request.StartDate.AddDays(numofdays);
                request.NumDays = numofdays;
            }

            var leaveAmount = request.EndDate - request.StartDate;
            request.NumDays = leaveAmount.Days;

            if (request.LeaveTypeId == 1)
            {
                if (user.YearlyLeaveDaysLeft < leaveAmount.Days)
                {
                    return new ServiceResponse<int>(user.YearlyLeaveDaysLeft) { Message = $"Leave has not been added: You only have {user.YearlyLeaveDaysLeft} days left.", IsSuccess = false };
                }
                user.YearlyLeaveDaysLeft -= request.NumDays;
            }
            //aynı tarihte alınmış başka bir izin varsa izin aldırtma
            var leaveList = await _uow.GetLeaveRepository().GetAllAsync(true, x => x.AppUserId == request.AppUserId);
            foreach (var item in leaveList)
            {
                if (item.ApprovalStatusId == 3)
                    continue;
                if (item.StartDate <= request.StartDate && item.EndDate >= request.StartDate)
                {
                    return new ServiceResponse<int>(0) { Message = $"Leave has not been added: You already have a leave in this date range.Leave id = {item.Id}.", IsSuccess = false };
                }
                if (item.StartDate <= request.EndDate && item.EndDate >= request.EndDate)
                {
                    return new ServiceResponse<int>(0) { Message = $"Leave has not been added: You already have a leave in this date range.Leave id = {item.Id}.", IsSuccess = false };
                }
            }

            var entity = _mapper.Map<HrApp.Domain.Entities.Leave>(request);

            await _uow.GetLeaveRepository().AddAsync(entity);

            await _uow.CommitAsync();

            return new ServiceResponse<int>(entity.Id) { Message = $"Leave has been added successfully: You have {user.YearlyLeaveDaysLeft} days left.", IsSuccess = true };
        }
    }
}
