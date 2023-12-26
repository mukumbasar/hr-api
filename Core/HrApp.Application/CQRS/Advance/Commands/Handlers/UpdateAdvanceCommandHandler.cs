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
    public class UpdateAdvanceCommandHandler : IRequestHandler<UpdateAdvanceCommand, ServiceResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IAdvanceRepository _advanceRepository;

        public UpdateAdvanceCommandHandler(IMapper mapper, IAdvanceRepository advanceRepository)
        {
            _mapper = mapper;
            _advanceRepository = advanceRepository;
        }

        public async Task<ServiceResponse<int>> Handle(UpdateAdvanceCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<HrApp.Domain.Entities.Advance>(request);

            await _advanceRepository.UpdateAsync(entity);

            return new ServiceResponse<int>(entity.Id) { Message = "Advance has been updated successfully", Success = true };
        }
    }
}
