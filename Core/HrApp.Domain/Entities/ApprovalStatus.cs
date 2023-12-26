using HrApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Domain.Entities
{
    public class ApprovalStatus : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Leave> Leaves { get; set; }
        public List<Advance> Advances { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}
