using HrApp.Application.Dtos;
using HrApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.AppUser.Queries
{
    public class GetAppUserQuery : IRequest<ServiceResponse<AppUserDto>>
    {
        public string userId { get; set; }
        public GetAppUserQuery(string _userId)
        {
            userId = _userId;
        }
    }
}
