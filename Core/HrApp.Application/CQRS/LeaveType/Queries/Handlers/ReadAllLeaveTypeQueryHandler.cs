using AutoMapper;
using HrApp.Application.CQRS.ExpenseType.Queries;
using HrApp.Application.Dtos;
using HrApp.Application.Interfaces;
using HrApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.LeaveType.Queries.Handlers
{
    public class ReadAllLeaveTypeQueryHandler : IRequestHandler<ReadAllLeaveTypeQuery, ServiceResponse<List<LeaveTypeDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public ReadAllLeaveTypeQueryHandler(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ServiceResponse<List<LeaveTypeDto>>> Handle(ReadAllLeaveTypeQuery request, CancellationToken cancellationToken)
        {
            var entities = await _uow.GetCurrencyRepository().GetAllAsync(true);

            if (entities.Count() > 0)
            {
                var dtos = new List<LeaveTypeDto>();

                foreach (var entity in entities)
                {
                    var mappedEntity = _mapper.Map<LeaveTypeDto>(entity);

                    dtos.Add(mappedEntity);
                }

                return new ServiceResponse<List<LeaveTypeDto>>(dtos) { IsSuccess = true, Message = "Leave types acquirement successful!" };
            }

            return new ServiceResponse<List<LeaveTypeDto>>() { IsSuccess = false, Message = "Leave types acquirement error!" };
        }
    }
}
