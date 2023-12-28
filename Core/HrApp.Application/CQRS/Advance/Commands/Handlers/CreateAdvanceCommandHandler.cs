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
    public class CreateAdvanceCommandHandler : IRequestHandler<CreateAdvanceCommand, ServiceResponse<decimal>>
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public CreateAdvanceCommandHandler(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ServiceResponse<decimal>> Handle(CreateAdvanceCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<HrApp.Domain.Entities.Advance>(request);

            await _uow.GetAdvanceRepository().AddAsync(entity);

            await _uow.CommitAsync();

            return new ServiceResponse<decimal>() { Message = "An advance has been added.", IsSuccess = true };
            
        }
    }
}
