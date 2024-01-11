using AutoMapper;
using HrApp.Application.CQRS.AppUser.Commands;
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
    public class AddCompanyCommandHandler : IRequestHandler<AddCompanyCommand, ServiceResponse<string>>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public AddCompanyCommandHandler(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<string>> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<HrApp.Domain.Entities.Company>(request);

            await _uow.GetCompanyRepository().AddAsync(entity);

            await _uow.CommitAsync();

            return new ServiceResponse<string>(request.Name) { Message = $"{request.Name} has been added successfully", IsSuccess = true };
        }
    }
}
