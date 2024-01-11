using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.Dtos
{
    public class AdvanceDto
    {
        public int Id { get; set; }
        public string AdvanceTypeName { get; set; }
        public int AdvanceTypeId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public int CurrencyId { get; set; }
        public DateTime RequestDate { get; set; }
        public string ApprovalStatus { get; set; }
        public int ApprovalStatusId { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string Description { get; set; }
        public string AppUserId { get; set; }
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? SecondSurname { get; set; }
    }
}
