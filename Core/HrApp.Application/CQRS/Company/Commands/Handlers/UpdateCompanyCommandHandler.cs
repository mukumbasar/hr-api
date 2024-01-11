using AutoMapper;
using HrApp.Application.Interfaces;
using HrApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.Company.Commands.Handlers
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, ServiceResponse<string>>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public UpdateCompanyCommandHandler(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<string>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Company>(request);

            await _uow.GetCompanyRepository().UpdateAsync(entity);

            await _uow.CommitAsync();

            return new ServiceResponse<string>(request.Name) { Message = $"{request.Name} has been updated successfully", IsSuccess = true };
        }
    }
}
