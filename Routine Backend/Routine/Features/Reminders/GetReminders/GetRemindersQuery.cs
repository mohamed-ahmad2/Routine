using MediatR;

namespace Routine.Features.Reminders.GetReminders
{
    public record GetRemindersQuery(int UserId) : IRequest<List<GetReminderDto>>;
}
