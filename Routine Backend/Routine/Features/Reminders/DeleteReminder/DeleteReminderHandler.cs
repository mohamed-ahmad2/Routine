using MediatR;
using Microsoft.EntityFrameworkCore;
using Routine.Common.Persistence;

namespace Routine.Features.Reminders.DeleteReminder
{
    public class DeleteReminderHandler : IRequestHandler<DeleteReminderCommand>
    {
        private readonly RoutineDbContext _context;

        public DeleteReminderHandler(RoutineDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteReminderCommand request, CancellationToken cancellationToken)
        {
            var reminder = await _context.Reminders
                .FirstOrDefaultAsync(
                    r => r.Id == request.ReminderId && r.UserId == request.UserId,
                    cancellationToken);

            if (reminder is null)
                throw new KeyNotFoundException($"Reminder {request.ReminderId} not found.");

            _context.Reminders.Remove(reminder);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}