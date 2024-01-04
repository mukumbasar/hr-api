using HrApp.Application.Wrappers;
using HrApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HrApp.Application;

public class ChangePasswordAppUserCommandHandler : IRequestHandler<ChangePasswordAppUserCommand, ServiceResponse<string>>
{
    private readonly UserManager<AppUser> userManager;

    public ChangePasswordAppUserCommandHandler(UserManager<AppUser> userManager)
    {
        this.userManager = userManager;
    }
    public async Task<ServiceResponse<string>> Handle(ChangePasswordAppUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id);
        var identityResult = await userManager.ResetPasswordAsync(user, request.Token, request.Password);
        if (identityResult.Succeeded)
            return new ServiceResponse<string> { IsSuccess = true, Data = request.Id, Message = "Giriş başarılı" };
        return new ServiceResponse<string> { IsSuccess = false, Data = request.Id, Message = string.Join(" . ", identityResult.Errors) };
    }
}
