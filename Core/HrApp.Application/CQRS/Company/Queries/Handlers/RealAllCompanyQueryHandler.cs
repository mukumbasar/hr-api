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

namespace HrApp.Application.CQRS.Company.Queries.Handlers
{
    public class RealAllCompanyQueryHandler : IRequestHandler<ReadAllCompanyQuery, ServiceResponse<List<CompanyDto>>>
    {

        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public RealAllCompanyQueryHandler(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<CompanyDto>>> Handle(ReadAllCompanyQuery request, CancellationToken cancellationToken)
        {
            var entities = await _uow.GetCompanyRepository().GetAllAsync(true, null, x => x.CompanyType);

            List<CompanyDto> dtos = new List<CompanyDto>();

            foreach (var entity in entities)
            {
                var dto = _mapper.Map<CompanyDto>(entity);
                dto.CompanyTypeName = entity.CompanyType.Name;
                dtos.Add(dto);
            }

            return new ServiceResponse<List<CompanyDto>>(dtos) { IsSuccess = true, Message = "" };
        }
    }
}
