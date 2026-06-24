using Routine.Entities;

namespace Routine.Features.Reminders.UpdateReminder
{
    public class UpdateReminderScheduleDto
    {
        public ScheduleType ScheduleType { get; set; }
        public TimeOnly? FixedTime { get; set; }
        public int? IntervalMinutes { get; set; }
        public int DaysOfWeekMask { get; set; } = (int)RoutineDayMask.All;
        public bool IsActive { get; set; } = true;
    }
}
