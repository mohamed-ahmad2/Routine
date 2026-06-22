using Routine.DTO;
using Routine.Entities;
namespace Routine.Interface
{
    public interface IRemindersRepository
               {
        Task<List<Reminder>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default);
    }
}
