using AutoMapper;
using Routine.Entities;


namespace Routine.Features.Reminders.GetReminderById
{
    public class GetReminderByIdProfile : Profile
    {
        public GetReminderByIdProfile()
        {
            CreateMap<Reminder, ReminderDto>();
            CreateMap<ReminderSchedule, ReminderScheduleDto>();
        }
    }
}