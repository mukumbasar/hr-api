using FluentValidation;
using HrApp.Application.CQRS.Advance.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.Validators
{
    public class CreateAdvanceValidator :AbstractValidator<CreateAdvanceCommand>
    {
        public CreateAdvanceValidator()
        {
            RuleFor(x => x.Amount).NotEmpty();
            RuleFor(x => x.CurrencyId).NotEmpty();
            RuleFor(x => x.AdvanceTypeId).NotEmpty();
            RuleFor(x => x.RequestDate).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
