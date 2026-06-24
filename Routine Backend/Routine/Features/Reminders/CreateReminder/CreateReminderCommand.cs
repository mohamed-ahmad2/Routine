using MediatR;

namespace Routine.Features.Reminders.CreateReminder
{
    public record CreateReminderCommand(int UserId, CreateReminderDto Dto) : IRequest<int>;
}
