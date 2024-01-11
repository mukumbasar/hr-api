using HrApp.Application.Dtos;
using HrApp.Application.Wrappers;
using MediatR;

namespace HrApp.Application;

public class GetAllAdminAppUserQuery : IRequest<ServiceResponse<List<AppUserDto>>>
{

}
