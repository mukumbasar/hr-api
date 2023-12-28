using HrApp.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.Expense.Commands
{
    public class UpdateExpenseCommand : IRequest<ServiceResponse<int>>
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public int ExpenseTypeId { get; set; }
        public int CurrencyId { get; set; }
        public decimal Amount { get; set; }
        public byte[] Document { get; set; }
    }
}
