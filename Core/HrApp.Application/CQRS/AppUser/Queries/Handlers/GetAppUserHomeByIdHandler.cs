﻿using AutoMapper;
using HrApp.Application.Helpers;
using HrApp.Application.Wrappers;
using HrApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HrApp.Application;

public class GetAppUserHomeByIdHandler : IRequestHandler<GetAppUserHomeById, ServiceResponse<AppUserHomeDto>>
{
    private readonly UserManager<AppUser> userManager;
    private readonly IMapper mapper;

    public GetAppUserHomeByIdHandler(UserManager<AppUser> userManager, IMapper mapper)
    {
        this.userManager = userManager;
        this.mapper = mapper;
    }

    public async Task<ServiceResponse<AppUserHomeDto>> Handle(GetAppUserHomeById request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id);

        if (user == null)
        {
            return new ServiceResponse<AppUserHomeDto>() { Message = "User not found", IsSuccess = false };
        }

        var userDto = mapper.Map<AppUserHomeDto>(user);

        if (user.ImageData == null)
        {
            userDto.Image = $"/images/user/default.png";
        }
        else
        {
            userDto.Image = await ImageConversions.ConvertToIFormFile(user.ImageData);
        }

        return new ServiceResponse<AppUserHomeDto>(userDto) { Message = "", IsSuccess = true };
    }
}
