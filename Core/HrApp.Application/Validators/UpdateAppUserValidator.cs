using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.Validators
{
    public class UpdateAppUserCommandValidator : AbstractValidator<UpdateAppUserCommand>
    {
        public UpdateAppUserCommandValidator()
        {
            RuleFor(y => y.Address).NotEmpty().WithMessage("Please enter your address.").MaximumLength(200).WithMessage("Address must be maximum of 200 characters.").MinimumLength(15).WithMessage("Address must be minimum of 15 characters.");
            RuleFor(y => y.MobileNumber).NotEmpty().WithMessage("Please enter your mobile phone number.").Length(9, 11).WithMessage("Please enter a valid phone number. Like 5325323232");
            RuleFor(y => y.UpdatedImage).NotEmpty().WithMessage("Please choose a photo.");
        }
    }

}
