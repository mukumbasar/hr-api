using FluentValidation;
using HrApp.Application.CQRS.Expense.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.Validators
{
    public class CreateExpenseValidator : AbstractValidator<CreateExpenseCommand>
    {
        public CreateExpenseValidator()
        {
            RuleFor(x => x.Amount).NotEmpty().GreaterThanOrEqualTo(1).WithMessage("Amount must be greater then 1.");
            RuleFor(x => x.CurrencyId).NotEmpty().WithMessage("Currency type is required");
            RuleFor(x => x.ExpenseTypeId).NotEmpty().WithMessage("Expense type is required");
            RuleFor(x => x.Document).NotEmpty().WithMessage("File is required");
        }
    }
}
