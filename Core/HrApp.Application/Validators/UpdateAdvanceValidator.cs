using FluentValidation;
using HrApp.Application.CQRS.Advance.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.Validators
{
    public class UpdateAdvanceValidator : AbstractValidator<UpdateAdvanceCommand>
    {
        public UpdateAdvanceValidator()
        {
            RuleFor(x => x.Amount).NotEmpty().LessThan(1);
            RuleFor(x => x.CurrencyId).NotEmpty();
            RuleFor(x => x.AdvanceTypeId).NotEmpty();
            RuleFor(x => x.RequestDate).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
