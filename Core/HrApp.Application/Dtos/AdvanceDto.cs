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
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime RequestDate { get; set; }
        public string ApprovalStatus { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string Description { get; set; }
    }
}
