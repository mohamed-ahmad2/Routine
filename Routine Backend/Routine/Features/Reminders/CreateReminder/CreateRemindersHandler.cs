using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Routine.Common.Persistence;
using Routine.Entities;

namespace Routine.Features.Reminders.CreateReminder
{
    public class CreateRemindersHandler : IRequestHandler<CreateReminderCommand, int>
    {
        private readonly RoutineDbContext _context;
        private readonly IMapper _mapper;

        public CreateRemindersHandler(RoutineDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateReminderCommand request, CancellationToken cancellationToken)
        {
            var reminder = _mapper.Map<Reminder>(request.Dto);
            reminder.UserId = request.UserId;
            _context.Reminders.Add(reminder);
            await _context.SaveChangesAsync(cancellationToken);

            return reminder.Id;
        }

    }
}
