using MediatR;

namespace Routine.Features.Reminders.GetReminderById
{
    public record GetReminderByIdQuery(int UserId, int ReminderId) : IRequest<ReminderDto>;
}