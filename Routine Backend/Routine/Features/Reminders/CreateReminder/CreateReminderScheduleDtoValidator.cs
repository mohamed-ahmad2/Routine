using FluentValidation;
using Routine.Entities;

namespace Routine.Features.Reminders.CreateReminder
{
    public class CreateReminderScheduleDtoValidator : AbstractValidator<CreateReminderScheduleDto>
    {
        public CreateReminderScheduleDtoValidator()
        {
            RuleFor(x => x.ScheduleType)
                .IsInEnum().WithMessage("Invalid ScheduleType");

            RuleFor(x => x.FixedTime)
                .NotNull().WithMessage("FixedTime is required for Fixed schedule")
                .When(x => x.ScheduleType == ScheduleType.Fixed);

            RuleFor(x => x.IntervalMinutes)
                .NotNull().WithMessage("IntervalMinutes is required for Interval schedule")
                .GreaterThan(0).WithMessage("IntervalMinutes must be greater than 0")
                .When(x => x.ScheduleType == ScheduleType.Interval);
        }
    }
}
