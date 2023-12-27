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
        private readonly IUow _uow;

        public DeleteAdvanceCommandHandler(IUow uow)
        {
            _uow = uow;
        }
        public async Task<ServiceResponse<int>> Handle(DeleteAdvanceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetAdvanceRepository().GetAsync(true, x => x.Id == request.Id);

            await _uow.GetAdvanceRepository().DeleteAsync(entity);

            await _uow.CommitAsync();

            var deletedEntity = await _uow.GetAdvanceRepository().GetAsync(true, x => x.Id == request.Id);

            if(deletedEntity == null) 
            {
                return new ServiceResponse<int>(request.Id) { Message = $"Deletion of advance {request.Id} has been completed.", IsSuccess = true };
            }

            return new ServiceResponse<int>(request.Id) { Message = $"Deletion of advance {request.Id} has not been completed.", IsSuccess = false };
        }
    }
}
