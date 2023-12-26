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
        public DateTime StartDate { get; set; }
        public int Amount { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RequestDate { get; set; }
        public string ApprovalStatus { get; set; }
        public DateTime ApprovalDate { get; set; }
    }
}
