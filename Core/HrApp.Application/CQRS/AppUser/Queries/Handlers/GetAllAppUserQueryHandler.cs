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
public class GetAllAppUserQueryHandler : IRequestHandler<GetAllAppUserQuery, ServiceResponse<List<AppUserDto>>>
{
    private readonly IMapper _mapper;
    private readonly IUow _uow;
    private readonly UserManager<AppUser> _userManager;
    public GetAllAppUserQueryHandler(IMapper mapper, IUow uow, UserManager<AppUser> userManager)
    {
        _mapper = mapper;
        _uow = uow;
        _userManager = userManager;
    }

    public async Task<ServiceResponse<List<AppUserDto>>> Handle(GetAllAppUserQuery request, CancellationToken cancellationToken)
    {
        var entities = await _uow.GetAppUserRepository().GetAllAsync(true, null, x => x.Gender);
        if (entities.Count() > 0)
        {
            var dtos= new List<AppUserDto>();

            foreach(var entity in entities) 
            { 
                var mappedEntity= _mapper.Map<AppUserDto>(entity);
                mappedEntity.Gender = entity.Gender.Name;
                dtos.Add(mappedEntity);
            }
            return  new ServiceResponse<List<AppUserDto>>(dtos) { Message="",IsSuccess=true };
        }
        return new ServiceResponse<List<AppUserDto>>() { Message = "Personnels acquirement error!", IsSuccess = false };
    }
}
