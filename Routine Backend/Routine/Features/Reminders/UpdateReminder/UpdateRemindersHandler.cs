using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Routine.Common.Persistence;
using Routine.Entities;

namespace Routine.Features.Reminders.UpdateReminder
{
    public class UpdateRemindersHandler : IRequestHandler<UpdateReminderCommand>
    {
        private readonly RoutineDbContext _context;
        private readonly IMapper _mapper;

        public UpdateRemindersHandler(RoutineDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Handle(UpdateReminderCommand request, CancellationToken cancellationToken)
        {
            var reminder = await _context.Reminders
                .Include(r => r.Schedules)
                .FirstOrDefaultAsync(r => r.Id == request.ReminderId && r.UserId == request.UserId, cancellationToken);

            if (reminder is null)
                throw new KeyNotFoundException($"Reminder {request.ReminderId} not found.");

            _mapper.Map(request.Dto, reminder);

            reminder.Schedules.Clear();
            foreach (var scheduleDto in request.Dto.Schedules)
            {
                var schedule = _mapper.Map<ReminderSchedule>(scheduleDto);
                reminder.Schedules.Add(schedule);
            }

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}