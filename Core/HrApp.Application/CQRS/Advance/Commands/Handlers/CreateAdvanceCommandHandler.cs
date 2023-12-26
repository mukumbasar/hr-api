using AutoMapper;
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

namespace HrApp.Application.CQRS.Advance.Commands.Handlers
{
    public class CreateAdvanceCommandHandler : IRequestHandler<CreateAdvanceCommand, ServiceResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IAdvanceRepository _advanceRepository;

        public CreateAdvanceCommandHandler(IMapper mapper, IAdvanceRepository advanceRepository)
        {
            _mapper = mapper;
            _advanceRepository = advanceRepository;
        }

        public async Task<ServiceResponse<int>> Handle(CreateAdvanceCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<HrApp.Domain.Entities.Advance>(request);

            await _advanceRepository.AddAsync(entity);

            return new ServiceResponse<int>(entity.Id) { Message = "Advance has been added successfully", Success = true };
        }
    }
}
