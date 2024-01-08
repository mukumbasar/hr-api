using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public int CompanyTypeId { get; set; }
        public CompanyType CompanyType { get; set; }
    }
}
