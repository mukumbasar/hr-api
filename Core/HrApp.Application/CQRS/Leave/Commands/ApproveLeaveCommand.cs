using HrApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.Leave.Commands
{
    public class ApproveLeaveCommand : IRequest<ServiceResponse<int>>
    {
        public int Id { get; set; }
        public bool IsApproved { get; set; }
    }
}
