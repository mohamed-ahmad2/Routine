using MediatR;

namespace Routine.Features.Reminders.UpdateReminder
{
    public record UpdateReminderCommand(int UserId, int ReminderId, UpdateReminderDto Dto) : IRequest;
}