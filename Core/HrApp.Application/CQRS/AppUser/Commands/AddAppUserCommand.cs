using HrApp.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.AppUser.Commands
{
    public class AddAppUserCommand : IRequest<ServiceResponse<string>>
    {
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? SecondSurname { get; set; }
        public DateTime BirthYear { get; set; }
        public string BirthPlace { get; set; }
        public string TurkishIdentificationNumber { get; set; }
        public DateTime StartDate { get; set; }
        public string Department { get; set; }
        public string CompanyName { get; set; }
        public string Occupation { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public decimal Salary { get; set; }
        public byte[] ImageData { get; set; }
        public int GenderId { get; set; }
        public bool IsAdmin { get; set; }

    }
}
