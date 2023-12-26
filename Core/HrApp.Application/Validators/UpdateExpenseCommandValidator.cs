using FluentValidation;
using HrApp.Application.CQRS.Expense.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.Validators
{
    internal class UpdateExpenseCommandValidator : AbstractValidator<UpdateExpenseCommand>
    {

        public UpdateExpenseCommandValidator() 
        {
            RuleFor(x => x.Amount).NotEmpty().WithMessage("Amount is required");
            RuleFor(x => x.CurrencyId).NotEmpty().WithMessage("Currency is required");
            RuleFor(x => x.ExpenseTypeId).NotEmpty().WithMessage("Expense Type is required");
            RuleFor(x => x.File).NotEmpty().WithMessage("File is required");

        }
    }
}
