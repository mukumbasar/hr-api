using AutoMapper;
using HrApp.Application.Helpers;
using HrApp.Application.Interfaces;
using HrApp.Application.Wrappers;
using HrApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HrApp.Application;

public class GetAppUserDetailsByIdHandler : IRequestHandler<GetAppUserDetailsById, ServiceResponse<AppUserDetailsDto>>
{
    private readonly UserManager<AppUser> userManager;
    private readonly IUow uow;
    private readonly IMapper mapper;

    public GetAppUserDetailsByIdHandler(UserManager<AppUser> userManager, IMapper mapper, IUow uow)
    {
        this.userManager = userManager;
        this.mapper = mapper;
        this.uow = uow;
    }
    public async Task<ServiceResponse<AppUserDetailsDto>> Handle(GetAppUserDetailsById request, CancellationToken cancellationToken)
    {
        var user = await uow.GetAppUserRepository().GetAsync(true, x => x.Id == (request.Id), x => x.Gender, x => x.Company);

        if (user == null)
        {
            return new ServiceResponse<AppUserDetailsDto>() { Message = "User not found", IsSuccess = false };
        }

        var userDto = mapper.Map<AppUserDetailsDto>(user);
        userDto.CompanyName = user.Company.Name;

        if (user.ImageData == null)
        {
            userDto.Image = $"/images/user/default.png";
        }
        else
        {
            userDto.Image = await ImageConversions.ConvertToIFormFile(user.ImageData);
        }

        return new ServiceResponse<AppUserDetailsDto>(userDto) { Message = "", IsSuccess = true };
    }
}
