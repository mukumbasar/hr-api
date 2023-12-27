using HrApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.Advance.Commands
{
    public class DeleteAdvanceCommand : IRequest<ServiceResponse<decimal>>
    {
        public int Id { get; set; }

        public DeleteAdvanceCommand(int id)
        {
            Id = id;
        }
    }
}
