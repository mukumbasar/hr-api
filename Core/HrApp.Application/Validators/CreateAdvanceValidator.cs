﻿using FluentValidation;
using HrApp.Application.CQRS.Advance.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.Validators
{
    public class CreateAdvanceValidator : AbstractValidator<CreateAdvanceCommand>
    {
        public CreateAdvanceValidator()
        {
            RuleFor(x => x.Amount).NotEmpty().WithMessage("Amount is required").GreaterThanOrEqualTo(1).WithMessage("Amount must be greater than 0.");
            RuleFor(x => x.AdvanceTypeId).NotEmpty().WithMessage("Advance type is required.");
            RuleFor(x => x.CurrencyId).NotEmpty().WithMessage("Currency is required.");
            RuleFor(x => x.RequestDate).NotEmpty().WithMessage("Request date is required.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.").MaximumLength(100).WithMessage("Description must be maximum of 100 characters.").MinimumLength(5).WithMessage("Description must be minimum of 5 characters.");
            RuleFor(x => x.RequestDate).GreaterThan(DateTime.Today).WithMessage("Request date must be greater than today.");
        }
    }
}
