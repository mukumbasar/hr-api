using HrApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Domain.Entities
{
    public class Expense : BaseEntity
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime ReplyDate { get; set; }
        public byte[] Document { get; set; }
        public int ExpenseTypeId { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public int ApprovalStatueId { get; set; }
        public ApprovalStatue ApprovalStatue { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
