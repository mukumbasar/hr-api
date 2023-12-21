using AutoMapper;
using HrApp.Application.Helpers;
using HrApp.Application.Validators;
using HrApp.Application.Wrappers;
using HrApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HrApp.Application;

public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommand, ServiceResponse<string>>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly UpdateAppUserCommandValidator _validator;
    private readonly IMapper _mapper;

    public UpdateAppUserCommandHandler(UserManager<AppUser> userManager, IMapper mapper, UpdateAppUserCommandValidator validator)
    {
        _userManager = userManager;
        _mapper = mapper;
        _validator = validator;
    }
    public async Task<ServiceResponse<string>> Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (validationResult.IsValid)
        {
            var tempUser = await _userManager.FindByIdAsync(request.Id);

            if (tempUser == null)
            {
                return new ServiceResponse<string>(request.Id) { Message = "User not found", Success = false };
            }

            tempUser.Address = request.Address;
            tempUser.MobileNumber = request.MobileNumber;
            tempUser.ImageData = request.UpdatedImage;

            var result = await _userManager.UpdateAsync(tempUser);

            if (result.Succeeded)
            {
                return new ServiceResponse<string>(tempUser.Id) { Message = "User updated successfully", Success = true };
            }
            else
            {
                return new ServiceResponse<string>(tempUser.Id) { Message = "User updated failed", Success = false };
            }
        }

        return new ServiceResponse<string>(request.Id) { Message = "User updated failed validation error", Success = false };
    }
}
