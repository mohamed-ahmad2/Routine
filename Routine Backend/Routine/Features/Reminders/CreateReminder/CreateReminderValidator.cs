using FluentValidation;

namespace Routine.Features.Reminders.CreateReminder
{
    public class CreateReminderValidator : AbstractValidator<CreateReminderDto>
    {
        public CreateReminderValidator() { 
            RuleFor(x =>  x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters");

            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage("Icon is requred");

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Category is required");

            RuleFor(x => x.ActionType)
                .IsInEnum().WithMessage("Invalid ActionType");

            RuleFor(x => x.Schedules)
                .NotEmpty().WithMessage("At least one schedule is required");

            RuleForEach(x => x.Schedules)
                .SetValidator(new CreateReminderScheduleDtoValidator());
        }
    }
}
