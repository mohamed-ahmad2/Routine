using Routine.DTO;

namespace Routine.Interface
{
    interface IRemindersService
    {
        Task<List<ReminderDto>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default);
    }
}
