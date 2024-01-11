using AutoMapper;
using HrApp.Application.Dtos;
using HrApp.Application.Interfaces;
using HrApp.Application.Wrappers;
using HrApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HrApp.Application;

public class GetAllAdminAppUserQueryHandler : IRequestHandler<GetAllAdminAppUserQuery, ServiceResponse<List<AppUserDto>>>
{
    private readonly UserManager<AppUser> userManager;
    private readonly IMapper mapper;
    private readonly ICompanyRepository companyRepository;

    public GetAllAdminAppUserQueryHandler(UserManager<AppUser> userManager, IMapper mapper, ICompanyRepository companyRepository)
    {
        this.userManager = userManager;
        this.mapper = mapper;
        this.companyRepository = companyRepository;
    }

    public async Task<ServiceResponse<List<AppUserDto>>> Handle(GetAllAdminAppUserQuery request, CancellationToken cancellationToken)
    {
        //include company
        var users = await userManager.GetUsersInRoleAsync("Admin");
        var companyNames = await companyRepository.GetAllAsync();
        var temp = mapper.Map<List<AppUserDto>>(users);
        foreach (var item in temp)
        {
            item.CompanyName = companyNames.FirstOrDefault(x => x.Id == item.CompanyId).Name ?? "Company not found";
        }

        return new ServiceResponse<List<AppUserDto>>(temp) { IsSuccess = true, Message = "" };
    }
}
