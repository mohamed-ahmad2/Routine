namespace Routine.Features.Reminders.GetReminders
{
    public class GetReminderScheduleDto
    {
        public int Id { get; set; }
        public string ScheduleType { get; set; } = string.Empty;
        public TimeOnly? FixedTime { get; set; }
        public int? IntervalMinutes { get; set; }
        public int DaysOfWeekMask { get; set; }
        public bool IsActive { get; set; }
    }
}
