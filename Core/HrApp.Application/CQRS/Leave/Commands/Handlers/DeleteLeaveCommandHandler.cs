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
    internal class DeleteLeaveCommandHandler : IRequestHandler<DeleteLeaveCommand, ServiceResponse<int>>
    {
        private readonly ILeaveRepository _leaveRepository;

        public DeleteLeaveCommandHandler(ILeaveRepository leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }

        public async Task<ServiceResponse<int>> Handle(DeleteLeaveCommand request, CancellationToken cancellationToken)
        {
            var entity = await _leaveRepository.GetAsync(true, x => x.Id == request.Id);

            await _leaveRepository.DeleteAsync(entity);

            return new ServiceResponse<int>(entity.Id) { Message = "Deletion has been completed successfully", Success = true };
        }
    }
}
