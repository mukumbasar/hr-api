using AutoMapper;
using HrApp.Application.Interfaces;
using HrApp.Application.Wrappers;
using MediatR;
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
        private readonly ILeaveRepository _leaveRepository;

        public UpdateLeaveCommandHandler(IMapper mapper, ILeaveRepository leaveRepository)
        {
            _mapper = mapper;
            _leaveRepository = leaveRepository;
        }

        public async Task<ServiceResponse<int>> Handle(UpdateLeaveCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<HrApp.Domain.Entities.Leave>(request);

            await _leaveRepository.UpdateAsync(entity);

            return new ServiceResponse<int>(entity.Id) { Message = "Leave has been updated successfully", Success = true };
        }
    }
}
