using AutoMapper;
using HrApp.Application.Interfaces;
using HrApp.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Components.Web.Virtualization;
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
        private readonly IUow _uow;

        public UpdateAdvanceCommandHandler(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ServiceResponse<int>> Handle(UpdateAdvanceCommand request, CancellationToken cancellationToken)
        {
            var entity = _uow.GetAdvanceRepository().GetAsync(true, x => x.Id == request.Id).Result;

            entity = _mapper.Map<HrApp.Domain.Entities.Advance>(request);

            await _uow.GetAdvanceRepository().UpdateAsync(entity);

            await _uow.CommitAsync();

            return new ServiceResponse<int>(entity.Id) { Message = "The advance has been updated.", IsSuccess = true };
        }
    }
}
