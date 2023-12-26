using HrApp.Application.Dtos;
using HrApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.Advance.Queries
{
    public class ReadAdvanceQuery : IRequest<ServiceResponse<AdvanceDto>>
    {
        public int Id { get; set; }

        public ReadAdvanceQuery(int id)
        {
            Id = id;
        }
    }
}
