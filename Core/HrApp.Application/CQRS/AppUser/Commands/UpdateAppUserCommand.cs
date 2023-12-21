using HrApp.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HrApp.Application;

public class UpdateAppUserCommand : IRequest<ServiceResponse<string>>
{
    public string Id { get; set; }
    public byte[] UpdatedImage { get; set; }
    public string Address { get; set; }
    public string MobileNumber { get; set; }
}
