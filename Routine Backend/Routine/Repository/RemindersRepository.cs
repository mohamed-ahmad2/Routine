using Microsoft.EntityFrameworkCore;
using Routine.Common.Persistence;
using Routine.Entities;
using Routine.Interface;

namespace Routine.Repository
{
    public class RemindersRepository : IRemindersRepository
    {
        private readonly RoutineDbContext _db;
        public RemindersRepository(RoutineDbContext db)
        {
            _db = db;
        }
        public async Task<List<Reminder>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            return await _db.Reminders
                .Include(r => r.Schedules)
                .Where(r => r.UserId == userId)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

    }
}
