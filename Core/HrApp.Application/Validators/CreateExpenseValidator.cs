using FluentValidation;
using HrApp.Application.CQRS.Expense.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.Validators
{
    internal class CreateExpenseValidator : AbstractValidator<CreateExpenseCommand> 
    {
        public CreateExpenseValidator()
        {
            RuleFor(x => x.Amount).NotEmpty().LessThan(1);
            RuleFor(x => x.CurrencyId).NotEmpty();
            RuleFor(x => x.ExpenseTypeId).NotEmpty();
            RuleFor(x => x.Document).NotEmpty();
        }
    }
}
