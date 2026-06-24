using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Routine.Common.Persistence;

namespace Routine.Features.Reminders.GetReminderById
{
    public class GetReminderByIdHandler : IRequestHandler<GetReminderByIdQuery, ReminderDto>
    {
        private readonly RoutineDbContext _context;
        private readonly IMapper _mapper;

        public GetReminderByIdHandler(RoutineDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReminderDto> Handle(GetReminderByIdQuery request, CancellationToken cancellationToken)
        {
            var reminder = await _context.Reminders
                .Include(r => r.Schedules)
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    r => r.Id == request.ReminderId && r.UserId == request.UserId,
                    cancellationToken);

            if (reminder is null)
                throw new KeyNotFoundException($"Reminder {request.ReminderId} not found.");

            return _mapper.Map<ReminderDto>(reminder);
        }
    }
}