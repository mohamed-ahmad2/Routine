using Routine.Entities;

namespace Routine.Features.Reminders.CreateReminder
{
    public class CreateReminderScheduleDto
    {
        public ScheduleType ScheduleType { get; set; }
        public TimeOnly? FixedTime { get; set; }
        public int? IntervalMinutes { get; set; }

        public int DaysOfWeekMask { get; set; } = (int)RoutineDayMask.All;

        public bool IsActive { get; set; } = true;
    }
}