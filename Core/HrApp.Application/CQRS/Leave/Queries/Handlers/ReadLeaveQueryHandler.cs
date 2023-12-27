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
        private readonly IUow _uow;

        public ReadLeaveQueryHandler(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ServiceResponse<LeaveDto>> Handle(ReadLeaveQuery request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetLeaveRepository().GetAsync(true, x => x.Id == request.Id, x => x.LeaveType, x => x.ApprovalStatus);

            if (entity != null)
            {
                var dto = _mapper.Map<LeaveDto>(entity);

                dto.ApprovalStatus = entity.ApprovalStatus.Name;
                dto.LeaveTypeName = entity.LeaveType.Name;

                return new ServiceResponse<LeaveDto>(dto) { Message = "Leave acquirement success!", IsSuccess = true };
            }

            return new ServiceResponse<LeaveDto>() { Message = "Leave acquirement error!", IsSuccess = false };
        }
    }
}
