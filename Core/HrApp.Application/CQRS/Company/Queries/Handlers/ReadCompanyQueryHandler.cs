using AutoMapper;
using HrApp.Application.Dtos;
using HrApp.Application.Interfaces;
using HrApp.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.Company.Queries.Handlers
{
    internal class ReadCompanyQueryHandler : IRequestHandler<ReadCompanyQuery, ServiceResponse<CompanyDto>>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly UserManager<Domain.Entities.AppUser> userManager;

        public ReadCompanyQueryHandler(IUow uow, IMapper mapper, UserManager<HrApp.Domain.Entities.AppUser> userManager)
        {
            _uow = uow;
            _mapper = mapper;
            this.userManager = userManager;
        }
        public async Task<ServiceResponse<CompanyDto>> Handle(ReadCompanyQuery request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetCompanyRepository().GetAsync(true, x => x.Id == request.id, x => x.CompanyType);
            var employeeList = userManager.Users.ToList();
            CompanyDto dto = new CompanyDto();


            dto = _mapper.Map<CompanyDto>(entity);
            dto.CompanyTypeName = entity.CompanyType.Name;
            dto.EmployeeCount = employeeList.Where(x => x.CompanyId == entity.Id).Count();

            return new ServiceResponse<CompanyDto>(dto) { IsSuccess = true, Message = "" };
        }
    }
}
