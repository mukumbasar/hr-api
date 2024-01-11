using AutoMapper;
using HrApp.Application.Dtos;
using HrApp.Application.Wrappers;
using HrApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HrApp.Application;

public class GetAllAdminAppUserQueryHandler : IRequestHandler<GetAllAdminAppUserQuery, ServiceResponse<List<AppUserDto>>>
{
    private readonly UserManager<AppUser> userManager;
    private readonly IMapper mapper;

    public GetAllAdminAppUserQueryHandler(UserManager<AppUser> userManager, IMapper mapper)
    {
        this.userManager = userManager;
        this.mapper = mapper;
    }

    public async Task<ServiceResponse<List<AppUserDto>>> Handle(GetAllAdminAppUserQuery request, CancellationToken cancellationToken)
    {
        var users = await userManager.GetUsersInRoleAsync("Admin");

        var temp = mapper.Map<List<AppUserDto>>(users);

        return new ServiceResponse<List<AppUserDto>>(temp) { IsSuccess = true, Message = "" };
    }
}
