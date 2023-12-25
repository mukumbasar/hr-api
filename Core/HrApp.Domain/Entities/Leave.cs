using HrApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Domain.Entities
{
    public class Leave : BaseEntity
    {
        public int Id { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RequestDate { get; set; }
        public int DayCount { get; set; }
        public DateTime ReplyDate { get; set; }
        public int LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }
        public int ApprovalStatueId { get; set; }
        public ApprovalStatue ApprovalStatue { get; set;}
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
