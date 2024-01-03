using AutoMapper;
using HrApp.Application.CQRS.AppUser.Commands;
using HrApp.Application.Helpers;
using HrApp.Application.Interfaces;
using HrApp.Application.Validators;
using HrApp.Application.Wrappers;
using HrApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HrApp.Application;

public class AddAppUserCommandHandler : IRequestHandler<AddAppUserCommand, ServiceResponse<string>>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly AddAppUserCommandValidator _validator;
    private readonly IMapper _mapper;
    private readonly IUow _uow;
    public AddAppUserCommandHandler(UserManager<AppUser> userManager, AddAppUserCommandValidator validator, IMapper mapper, IUow uow)
    {
        _userManager = userManager;
        _validator = validator;
        _mapper = mapper;
        _uow = uow;
    }

    public async Task<ServiceResponse<string>> Handle(AddAppUserCommand request, CancellationToken cancellationToken)
    {
        Dictionary<string, string> turkishChar = new Dictionary<string, string>
        {
            { "ü", "u" },
            { "ö", "o" },
            { "ç", "c" },
            { "ş", "s" },
            { "ğ", "g" },
            { "ı", "i" }
        };
        var validationResult= await _validator.ValidateAsync(request);
        if (validationResult.IsValid)
        {
            var user = _mapper.Map<AppUser>(request);
            user.SecondName??= "";
            user.SecondSurname ??= "";
            user.UserName = Guid.NewGuid().ToString();
            user.Email = user.Name.ToLower() + user.SecondName.ToLower()+ "." + user.Surname.ToLower() + user.SecondSurname.ToLower() + "@" + user.CompanyName.ToLower() + ".com";
            foreach(var items in turkishChar.Keys)
            {
                if (user.Email.Contains(turkishChar[items]))
                    user.Email = user.Email.Replace(items, turkishChar[items]);
            }
            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                return new ServiceResponse<string>() { Message = "User added successfully", IsSuccess = true };
            }
            else
            {
                return new ServiceResponse<string>() { Message = "User added failed", IsSuccess = false };
            }
        }
        return new ServiceResponse<string>() { Message = string.Join(" ", validationResult.Errors), IsSuccess = false };
    }
}
