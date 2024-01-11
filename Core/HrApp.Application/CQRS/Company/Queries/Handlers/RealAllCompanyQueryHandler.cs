using AutoMapper;
using HrApp.Application.CQRS.Advance.Queries;
using HrApp.Application.Dtos;
using HrApp.Application.Interfaces;
using HrApp.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.Company.Queries.Handlers
{
    public class RealAllCompanyQueryHandler : IRequestHandler<ReadAllCompanyQuery, ServiceResponse<List<CompanyDto>>>
    {

        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly UserManager<Domain.Entities.AppUser> userManager;

        public RealAllCompanyQueryHandler(IUow uow, IMapper mapper, UserManager<HrApp.Domain.Entities.AppUser> userManager)
        {
            _uow = uow;
            _mapper = mapper;
            this.userManager = userManager;
        }
        public async Task<ServiceResponse<List<CompanyDto>>> Handle(ReadAllCompanyQuery request, CancellationToken cancellationToken)
        {
            var entities = await _uow.GetCompanyRepository().GetAllAsync(true, null, x => x.CompanyType, x => x.AppUsers);
            var employeeList = userManager.Users.ToList();
            List<CompanyDto> dtos = new List<CompanyDto>();
            if (request.isFree)
            {
                entities = entities.Where(x => x.AppUsers.Count == 0).ToList();
            }
            foreach (var entity in entities)
            {
                var dto = _mapper.Map<CompanyDto>(entity);
                dto.CompanyTypeName = entity.CompanyType.Name;
                dto.EmployeeCount = employeeList.Where(x => x.CompanyId == entity.Id).Count();
                dtos.Add(dto);
            }

            return new ServiceResponse<List<CompanyDto>>(dtos) { IsSuccess = true, Message = "" };
        }
    }
}
