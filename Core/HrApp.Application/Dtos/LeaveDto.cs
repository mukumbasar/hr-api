using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.Dtos
{
    public class LeaveDto
    {
        public int Id { get; set; }
        public string LeaveTypeName { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public int NumDays { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RequestDate { get; set; }
        public string ApprovalStatus { get; set; }
        public int ApprovalStatusId { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string AppUserId { get; set; }
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? SecondSurname { get; set; }
    }
}
