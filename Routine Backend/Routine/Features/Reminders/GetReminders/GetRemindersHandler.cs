using MediatR;
using Microsoft.EntityFrameworkCore;
using Routine.Common.Persistence;

namespace Routine.Features.Reminders.GetReminders
{
    public class GetRemindersHandler : IRequestHandler<GetRemindersQuery, List<GetReminderDto>>
    {
        private readonly RoutineDbContext _db;

        public GetRemindersHandler(RoutineDbContext db)
        {
            _db = db;
        }

        public async Task<List<GetReminderDto>> Handle(GetRemindersQuery request, CancellationToken cancellationToken)
        {
            var reminders = await _db.Reminders
                .Include(r => r.Schedules)
                .Where(r => r.UserId == request.UserId)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return GetReminderMapper.ToDtoList(reminders);
        }
    }
}