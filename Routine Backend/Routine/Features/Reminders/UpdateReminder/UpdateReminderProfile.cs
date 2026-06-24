using AutoMapper;
using Routine.Entities;

namespace Routine.Features.Reminders.UpdateReminder
{
    public class UpdateReminderProfile : Profile
    {
        public UpdateReminderProfile()
        {
            CreateMap<UpdateReminderDto, Reminder>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.Type, opt => opt.Ignore())
                .ForMember(dest => dest.PresetKey, opt => opt.Ignore())
                .ForMember(dest => dest.IsPreset, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Logs, opt => opt.Ignore())
                .ForMember(dest => dest.PomodoroSessions, opt => opt.Ignore())
                .ForMember(dest => dest.Schedules, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<UpdateReminderScheduleDto, ReminderSchedule>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ReminderId, opt => opt.Ignore())
                .ForMember(dest => dest.Reminder, opt => opt.Ignore());
        }
    }
}