using HrApp.Application.Wrappers;
using MediatR;

namespace HrApp.Application;

public class ChangePasswordAppUserCommand : IRequest<ServiceResponse<string>>
{
    public string Id { get; set; }
    public string Token { get; set; }
    public string Password { get; set; }
}
