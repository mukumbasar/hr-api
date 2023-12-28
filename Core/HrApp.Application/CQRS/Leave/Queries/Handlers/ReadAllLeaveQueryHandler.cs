﻿using AutoMapper;
using HrApp.Application.CQRS.Expense.Queries;
using HrApp.Application.Dtos;
using HrApp.Application.Interfaces;
using HrApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.Leave.Queries.Handlers
{
    public class ReadAllLeaveQueryHandler : IRequestHandler<ReadAllLeaveQuery, ServiceResponse<List<LeaveDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public ReadAllLeaveQueryHandler(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ServiceResponse<List<LeaveDto>>> Handle(ReadAllLeaveQuery request, CancellationToken cancellationToken)
        {
            var entities = await _uow.GetLeaveRepository().GetAllAsync(true, null,x => x.LeaveType, x => x.ApprovalStatus);

            if (entities.Count() > 0)
            {
                var dtos = new List<LeaveDto>();

                foreach (var entity in entities)
                {
                    var mappedEntity = _mapper.Map<LeaveDto>(entity);

                    mappedEntity.ApprovalStatus = entity.ApprovalStatus.Name;
                    mappedEntity.LeaveTypeName = entity.LeaveType.Name;

                    dtos.Add(mappedEntity);
                }

                return new ServiceResponse<List<LeaveDto>>(dtos) { Message = "Expense acquirement success!", IsSuccess = true };
            }

            return new ServiceResponse<List<LeaveDto>>() { Message = "Expense acquirement error!", IsSuccess = false };
        }
    }
}