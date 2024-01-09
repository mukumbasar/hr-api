using AutoMapper;
using HrApp.Application.CQRS.Advance.Queries;
using HrApp.Application.Dtos;
using HrApp.Application.Interfaces;
using HrApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.CompanyType.Queries.Handlers
{
    public class ReadAllCompanyTypeQueryHandler : IRequestHandler<ReadAllCompanyTypeQuery, ServiceResponse<List<CompanyTypeDto>>>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public ReadAllCompanyTypeQueryHandler(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
    
        public async Task<ServiceResponse<List<CompanyTypeDto>>> Handle(ReadAllCompanyTypeQuery request, CancellationToken cancellationToken)
        {
            var entities = await _uow.GetCompanyTypeRepository().GetAllAsync(true);

            var dtos = _mapper.Map<List<CompanyTypeDto>>(entities);

            return new ServiceResponse<List<CompanyTypeDto>>(dtos) { IsSuccess = true, Message = "" };
        }
    }
}
