using AutoMapper;
using HrApp.Application.Interfaces;
using HrApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.Advance.Commands.Handlers
{
    public class DeleteAdvanceCommandHandler : IRequestHandler<DeleteAdvanceCommand, ServiceResponse<int>>
    {
        private readonly IAdvanceRepository _advanceRepository;

        public DeleteAdvanceCommandHandler(IAdvanceRepository advanceRepository)
        {
            _advanceRepository = advanceRepository;
        }
        public async Task<ServiceResponse<int>> Handle(DeleteAdvanceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _advanceRepository.GetAsync(true, x => x.Id == request.Id);

            await _advanceRepository.DeleteAsync(entity);

            return new ServiceResponse<int>(entity.Id) { Message = "Deletion has been completed successfully", Success = true };
        }
    }
}
