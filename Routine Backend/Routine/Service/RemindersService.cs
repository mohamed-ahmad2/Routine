using Routine.DTO;
using Routine.Interface;
using Routine.Mapper;

namespace Routine.Service
{
    public class RemindersService : IRemindersService
    {
        private readonly IRemindersRepository _repository;

        public RemindersService(IRemindersRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ReminderDto>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            var reminders = await _repository.GetByUserIdAsync(userId, cancellationToken);
            return ReminderMapper.ToDtoList(reminders);
        }

      
    }
}
