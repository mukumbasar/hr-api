using HrApp.Application.Wrappers;
using MediatR;

namespace HrApp.Application;

public class GetAppUserHomeById : IRequest<ServiceResponse<AppUserHomeDto>>
{
   public string Id { get; set; }
}
