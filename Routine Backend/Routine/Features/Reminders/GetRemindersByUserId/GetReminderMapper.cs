using Routine.Entities;

namespace Routine.Features.Reminders.GetReminders
{
    public static class GetReminderMapper
    {
            public static GetReminderDto ToDto(Reminder reminder) => new() 
            {
                Id = reminder.Id,
                UserId = reminder.UserId,
                Title = reminder.Title,
                Icon = reminder.Icon,
                Category = reminder.Category,
                Type = reminder.Type.ToString(),
                PresetKey = reminder.PresetKey,
                ActionType = reminder.ActionType.ToString(),
                Note = reminder.Note,
                IsEnabled = reminder.IsEnabled,
                IsPreset = reminder.IsPreset,
                CreatedAt = reminder.CreatedAt,
                UpdatedAt = reminder.UpdatedAt,
                Schedules = reminder.Schedules.Select(ToScheduleDto).ToList()
            };
        public static GetReminderScheduleDto ToScheduleDto(ReminderSchedule schedule) => new()
        {
            Id = schedule.Id,
            ScheduleType = schedule.ScheduleType.ToString(),
            FixedTime = schedule.FixedTime,
            IntervalMinutes = schedule.IntervalMinutes,
            DaysOfWeekMask = schedule.DaysOfWeekMask,
            IsActive = schedule.IsActive
        };
        public static List<GetReminderDto> ToDtoList(IEnumerable<Reminder> reminders) => reminders.Select(ToDto).ToList();
    }
}
