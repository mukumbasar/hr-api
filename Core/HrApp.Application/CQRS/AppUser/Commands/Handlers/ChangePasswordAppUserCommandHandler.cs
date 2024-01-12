using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using HrApp.Application.Wrappers;
using HrApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;

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
        byte[] tokenDecodedBytes = WebEncoders.Base64UrlDecode(request.Token);
        string tokenDecoded = Encoding.UTF8.GetString(tokenDecodedBytes);
        var identityResult = await userManager.ResetPasswordAsync(user, tokenDecoded, request.Password);

        if (identityResult.Succeeded)
        {
            return new ServiceResponse<string> { IsSuccess = true, Data = request.Id, Message = "Password has been updated." };
        }
        else
        {
            var errors = string.Join(", ", identityResult.Errors.Select(e => e.Description));
            return new ServiceResponse<string> { IsSuccess = false, Data = request.Id, Message = $"Password update failed. Errors: {errors}" };
        }
    }
}
