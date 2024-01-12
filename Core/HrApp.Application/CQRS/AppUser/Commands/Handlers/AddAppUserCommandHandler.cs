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
    private readonly IEmailService _emailService;
    private readonly ICompanyRepository _companyRepository;
    public AddAppUserCommandHandler(UserManager<AppUser> userManager, AddAppUserCommandValidator validator, IMapper mapper, IUow uow, IEmailService emailService, ICompanyRepository companyRepository)
    {
        _userManager = userManager;
        _validator = validator;
        _mapper = mapper;
        _uow = uow;
        _emailService = emailService;
        _companyRepository = companyRepository;
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
        var validationResult = await _validator.ValidateAsync(request);
        if (validationResult.IsValid)
        {
            var user = _mapper.Map<AppUser>(request);
            user.SecondName ??= "";
            user.SecondSurname ??= "";
            user.UserName = Guid.NewGuid().ToString();
            var company = await _companyRepository.GetAsync(true, x => x.Id == request.CompanyId);
            user.Email = user.Name.ToLower() + user.SecondName.ToLower() + "." + user.Surname.ToLower() + user.SecondSurname.ToLower() + "@" + company.Name.ToLower() + ".com";
            foreach (var items in turkishChar.Keys)
            {
                if (user.Email.Contains(turkishChar[items]))
                    user.Email = user.Email.Replace(items, turkishChar[items]);
            }
            user.YearlyAdvanceAmountLeft = user.Salary * 3;
            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                if (request.IsAdmin)
                {
                    if (!_userManager.GetUsersInRoleAsync("Admin").Result.Any(x => x.CompanyId == user.CompanyId))
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                    else
                        return new ServiceResponse<string>() { Message = "Personnel add process failed company already have admin", IsSuccess = false };
                }

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                var mailBody = await _emailService.GenerateNewPasswordMailBody(user.Id, token);

                _emailService.SendMail(user.Email, "Yeni Şifre Temini", mailBody);

                return new ServiceResponse<string>() { Message = "User added successfully", IsSuccess = true };
            }
            var errorList = result.Errors.ToList();
            var errors = string.Join(", ", errorList.Select(e => e.Code));
            return new ServiceResponse<string>() { Message = errors, IsSuccess = false };

        }
        return new ServiceResponse<string>() { Message = string.Join(" ", validationResult.Errors), IsSuccess = false };
    }
}
