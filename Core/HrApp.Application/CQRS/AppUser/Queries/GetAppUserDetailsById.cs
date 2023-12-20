using HrApp.Application.Wrappers;
using MediatR;

namespace HrApp.Application;

public class GetAppUserDetailsById : IRequest<ServiceResponse<AppUserDetailsDto>>
{
   public string Id { get; set; }
}
