using HrApp.Domain.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Domain.Entities
{
    public class AppUser : IdentityUser, IEntity
    {
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? SecondSurname { get; set; }
        public DateTime BirthYear { get; set; }
        public string BirthPlace { get; set; }
        public string TurkishIdentificationNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get { return EndDate == null ? true : false; } }
        public string Department { get; set; }
        public string Occupation { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public decimal Salary { get; set; }
        public byte[]? ImageData { get; set; }
        public int YearlyLeaveDaysLeft { get; set; } = 20;
        public decimal YearlyAdvanceAmountLeft { get; set; }
        public Gender Gender { get; set; }
        public int GenderId { get; set; }

        public int? CompanyId { get; set; }
        public Company? Company { get; set; }

        public List<Advance> Advances { get; set; }
        public List<Leave> Leaves { get; set; }
        public List<Expense> Expenses { get; set; }
    }

}
