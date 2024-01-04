using HrApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.AppUser.Commands
{
    public class SendPasswordEmailCommand : IRequest<ServiceResponse<string>>
    {
        public string Email { get; set; }
    }
}
