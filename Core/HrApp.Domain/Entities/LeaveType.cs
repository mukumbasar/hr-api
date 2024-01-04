using HrApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Domain.Entities
{
    public class LeaveType : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int NumDays { get; set; }
        public List<Leave> Leaves { get; set; }

        public LeaveTypeFocus LeaveTypeFocus { get; set; }
        public int LeaveTypeFocusId { get; set; }
    }
}
