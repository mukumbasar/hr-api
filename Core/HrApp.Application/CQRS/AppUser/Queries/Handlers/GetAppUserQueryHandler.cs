using AutoMapper;
using HrApp.Application.CQRS.AppUser.Queries;
using HrApp.Application.Dtos;
using HrApp.Application.Interfaces;
using HrApp.Application.Wrappers;
using HrApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application;

public class GetAppUserQueryHandler : IRequestHandler<GetAppUserQuery, ServiceResponse<AppUserDto>>
{
    private readonly IMapper _mapper;
    private readonly IUow _uow;
    private readonly UserManager<AppUser> _userManager;

    public GetAppUserQueryHandler(IMapper mapper, IUow uow, UserManager<AppUser> userManager)
    {
        _mapper = mapper;
        _uow = uow;
        _userManager = userManager;
    }

    public async Task<ServiceResponse<AppUserDto>> Handle(GetAppUserQuery request, CancellationToken cancellationToken)
    {
        var entity = await _uow.GetAppUserRepository().GetAsync(true,x=>x.Id==(request.userId),x=>x.Gender, x => x.Company);
        if (entity != null)
        {
            var dto = _mapper.Map<AppUserDto>(entity);
            dto.Gender = entity.Gender.Name;
            dto.CompanyName = entity.Company.Name;
            return new ServiceResponse<AppUserDto>(dto) { Message = "", IsSuccess = true };
        }
        return new ServiceResponse<AppUserDto>() { Message = "Personnel acquirement error!", IsSuccess = false };
    }
}
