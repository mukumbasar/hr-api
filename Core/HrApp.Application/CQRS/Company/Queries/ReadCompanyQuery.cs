using HrApp.Application.Dtos;
using HrApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.Company.Queries
{
    public class ReadCompanyQuery : IRequest<ServiceResponse<CompanyDto>>
    {
        public int id { get; set; }
        public ReadCompanyQuery(int _Id)
        {
            id = _Id;
        }
    }
}
