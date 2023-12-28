using HrApp.Application.Wrappers;
using HrApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.Leave.Commands
{
    public class CreateLeaveCommand : IRequest<ServiceResponse<int>>
    {
        public string AppUserId { get; set; }
        public int LeaveTypeId { get; set; }
        public int NumDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
