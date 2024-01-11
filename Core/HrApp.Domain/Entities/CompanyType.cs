using HrApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Domain.Entities
{
    public class CompanyType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Company> Companies { get; set; }
    }
}
