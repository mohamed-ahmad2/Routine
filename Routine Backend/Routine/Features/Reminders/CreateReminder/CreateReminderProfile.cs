using AutoMapper;
using Routine.Entities;

namespace Routine.Features.Reminders.CreateReminder
{
    public class CreateReminderProfile : Profile
    {
        public CreateReminderProfile() {
            CreateMap<CreateReminderDto, Reminder>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(_ => ReminderType.Custom))
                .ForMember(dest => dest.PresetKey, opt => opt.MapFrom(_ => (string?)null))
                .ForMember(dest => dest.IsPreset, opt => opt.MapFrom(_ => false))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Logs, opt => opt.Ignore())
                .ForMember(dest => dest.PomodoroSessions, opt => opt.Ignore());

            CreateMap<CreateReminderScheduleDto, ReminderSchedule>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ReminderId, opt => opt.Ignore());
        }
    }
}
