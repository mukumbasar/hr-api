using HrApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Domain.Entities
{
    public class Company : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MersisNo { get; set; }
        public string TaxNo { get; set; }
        public string TaxOffice { get; set; }
        public byte[]? ImageData { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public int EmployeeCount { get; set; } = 0;
        public DateTime FoundationYear { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public bool IsActive { get { return ContractEndDate > DateTime.Now ? true : false; } }

        public List<AppUser> AppUsers { get; set; }

        public int CompanyTypeId { get; set; }
        public CompanyType CompanyType { get; set; }
    }
}
