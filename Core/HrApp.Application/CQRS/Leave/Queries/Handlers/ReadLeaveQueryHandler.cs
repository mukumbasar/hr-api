using AutoMapper;
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
    public class ReadLeaveQueryHandler : IRequestHandler<ReadLeaveQuery, ServiceResponse<LeaveDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveRepository _leaveRepository;

        public ReadLeaveQueryHandler(IMapper mapper, ILeaveRepository leaveRepository)
        {
            _mapper = mapper;
            _leaveRepository = leaveRepository;
        }

        public async Task<ServiceResponse<LeaveDto>> Handle(ReadLeaveQuery request, CancellationToken cancellationToken)
        {
            var entity = await _leaveRepository.GetAsync(true, x => x.Id == request.Id, x => x.LeaveType, x => x.ApprovalStatus);

            if (entity != null)
            {
                var dto = _mapper.Map<LeaveDto>(entity);

                dto.ApprovalStatus = entity.ApprovalStatus.Name;
                dto.LeaveTypeName = entity.LeaveType.Name;

                return new ServiceResponse<LeaveDto>(dto) { Success = true };
            }

            return new ServiceResponse<LeaveDto>() { Message = "Leave acquirement error!", Success = false };
        }
    }
}
