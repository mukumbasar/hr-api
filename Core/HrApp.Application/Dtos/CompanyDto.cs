using HrApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.Dtos
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[]? ImageData { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }
        public string CompanyTypeName { get; set; }
    }
}
