using MediatR;

namespace Routine.Features.Reminders.DeleteReminder
{
    public record DeleteReminderCommand(int UserId, int ReminderId) : IRequest;
}