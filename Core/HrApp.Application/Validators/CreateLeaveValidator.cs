using FluentValidation;
using HrApp.Application.CQRS.Leave.Commands;

namespace HrApp.Application.Validators;

public class CreateLeaveValidator : AbstractValidator<CreateLeaveCommand>
{
    public CreateLeaveValidator()
    {
        RuleFor(x => x.StartDate).NotEmpty().WithMessage("Start date is required.");

        RuleFor(x => x.EndDate).NotEmpty().WithMessage("End date is required.");

        RuleFor(x => x.StartDate).GreaterThanOrEqualTo(DateTime.Today).WithMessage("Start date must be today or later.");

        When(x => x.LeaveTypeId == 1, () =>
        {
            RuleFor(x => x.EndDate)
                .GreaterThanOrEqualTo(DateTime.Today)
                .WithMessage("End date must be greater than today.");

            RuleFor(x => x.EndDate)
                .GreaterThanOrEqualTo(x => x.StartDate)
                .WithMessage("End date must be greater than start date.");
        });
    }
}
