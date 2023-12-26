using HrApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.Advance.Commands
{
    public class UpdateAdvanceCommand : IRequest<ServiceResponse<int>>
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public int AdvanceTypeId { get; set; }
        public int CurrencyId { get; set; }
        public decimal Amount { get; set; }
        public DateTime RequestDate { get; set; }
        public string Description { get; set; }
    }
}
