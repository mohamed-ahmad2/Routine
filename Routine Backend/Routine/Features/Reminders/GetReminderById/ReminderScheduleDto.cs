using Routine.Entities;

namespace Routine.Features.Reminders.GetReminderById
{
    public class ReminderScheduleDto
    {
        public int Id { get; set; }
        public ScheduleType ScheduleType { get; set; }
        public TimeOnly? FixedTime { get; set; }
        public int? IntervalMinutes { get; set; }
        public int DaysOfWeekMask { get; set; }
        public bool IsActive { get; set; }
    }
}
