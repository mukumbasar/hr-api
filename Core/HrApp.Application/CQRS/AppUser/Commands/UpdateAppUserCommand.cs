using HrApp.Application.Wrappers;
using MediatR;

namespace HrApp.Application;

public class UpdateAppUserCommand : IRequest<ServiceResponse<string>>
{
   public string Id { get; set; }
   public byte[] ImageData { get; set; }
   public string Address { get; set; }
   public string MobileNumber { get; set; }
}
