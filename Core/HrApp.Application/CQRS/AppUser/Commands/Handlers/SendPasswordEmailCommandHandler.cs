using HrApp.Application.Interfaces;
using HrApp.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrApp.Domain.Entities;

namespace HrApp.Application.CQRS.AppUser.Commands.Handlers
{
    public class SendPasswordEmailCommandHandler : IRequestHandler<SendPasswordEmailCommand, ServiceResponse<string>>
    {
        private readonly IEmailService _emailService;
        private readonly UserManager<HrApp.Domain.Entities.AppUser> _userManager;

        public SendPasswordEmailCommandHandler(IEmailService emailService, UserManager<HrApp.Domain.Entities.AppUser> userManager)
        {
            _emailService = emailService;
            _userManager = userManager;
        }

        public async Task<ServiceResponse<string>> Handle(SendPasswordEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null) 
            {
                return new ServiceResponse<string>(request.Email) { Message = "Please enter a registered email!", IsSuccess = false };
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var mailBody = await _emailService.GenerateNewPasswordMailBody(user.Id, token);

            _emailService.SendMail(request.Email, "Yeni Şifre Temini", mailBody);

            return new ServiceResponse<string>(request.Email) { Message = "A password email has been sent.", IsSuccess = true };
        }
    }
}
