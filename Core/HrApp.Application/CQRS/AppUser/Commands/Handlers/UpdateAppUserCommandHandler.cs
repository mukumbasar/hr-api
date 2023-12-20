using AutoMapper;
using HrApp.Application.Wrappers;
using HrApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HrApp.Application;

public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommand, ServiceResponse<string>>
{
   private readonly UserManager<AppUser> userManager;
   private readonly IMapper mapper;

   public UpdateAppUserCommandHandler(UserManager<AppUser> userManager, IMapper mapper)
   {
      this.userManager = userManager;
      this.mapper = mapper;
   }
   public async Task<ServiceResponse<string>> Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
   {
      if (true)
      {
         var tempUser = await userManager.FindByIdAsync(request.Id);
         if (tempUser == null)
         {
            return new ServiceResponse<string>(request.Id) { Message = "User not found", Success = false };
         }
         mapper.Map(request, tempUser);
         var result = await userManager.UpdateAsync(tempUser);
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
