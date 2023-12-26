using HrApp.Application.Dtos;
using HrApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.Leave.Queries
{
    public class ReadAllLeaveQuery : IRequest<ServiceResponse<List<LeaveDto>>>
    {

    }
}
